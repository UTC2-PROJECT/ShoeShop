using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopSportShoes.Services
{
    public class GoogleDriveService
    {
        private string[] Scopes = { DriveService.Scope.Drive };

        string _folderId = "1f-d7LnTDd63UyoCW3Iy2UnPU5Ylq1K5n";

        public GoogleDriveService()
        {

        }
        private DriveService GetDriveServiceInstance()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("wwwroot/credentials/credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                credPath = Path.Combine(credPath, "wwwroot/credentials/credentials.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "ShoeShop",
            });

            return service;
        }

        public async Task<string> UploadFIleAsync(IBrowserFile browserFile, string imageName)
        {
            var service = GetDriveServiceInstance();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = imageName;
            fileMetadata.MimeType = browserFile.ContentType;
            fileMetadata.Parents = new List<string>() { _folderId };

            FilesResource.CreateMediaUpload request;

            try
            {
                using (var stream = browserFile.OpenReadStream(10240000))
                {
                    request = service.Files.Create(fileMetadata, stream, browserFile.ContentType);
                    request.Fields = "id, name, parents, createdTime, modifiedTime, mimeType, thumbnailLink, webViewLink, webContentLink";
                    request.IncludePermissionsForView = "published";
                    await request.UploadAsync();
                }
                var file = request.ResponseBody;
                return file?.Id;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> GetFileMetadataAsync(string imageName)
        {
            var service = GetDriveServiceInstance();
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = "parents in '" + _folderId + "'";
            listRequest.Fields = "nextPageToken, files(id, name, thumbnailLink, webViewLink, webContentLink)";
            var files = await listRequest.ExecuteAsync();
            var file = files?.Files?.FirstOrDefault(x => x.Name == imageName)?.ThumbnailLink;

            return files?.Files?.FirstOrDefault(x => x.Name == imageName)?.ThumbnailLink;
        }
        public async Task GetFileById(string id)
        {
            var service = GetDriveServiceInstance();
            FilesResource.GetRequest filesResource = service.Files.Get(id);
            filesResource.Fields = "thumbnailLink, webContentLink, name, webViewLink, mimeType";
            Google.Apis.Drive.v3.Data.File file = new();
            file = await filesResource.ExecuteAsync();

            Console.WriteLine("Id: " + file.Id);
            Console.WriteLine("ThumbnailLink: " + file.ThumbnailLink);
            Console.WriteLine("WebContentLink: " + file.WebContentLink);
            Console.WriteLine("WebViewLink: " + file.WebViewLink);

        }
        public async Task<bool> DeleteFileAsync(string imageName)
        {
            var service = GetDriveServiceInstance();
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.Q = $"parents in '{_folderId}'";
            listRequest.Fields = "nextPageToken, files(id, name)";
            try
            {
                var files = await listRequest.ExecuteAsync();
                var id = files?.Files?.FirstOrDefault(x => x.Name == imageName)?.Id;
                var request = service.Files.Delete(id);
                await request.ExecuteAsync();
                return true;
            }
            catch (GoogleApiException)
            {
                return false;
            }
        }

        public async Task DeleteRangeAsync(List<string> imageNames)
        {
            List<Task> tasks = new();
            foreach (var item in imageNames)
            {
                var task = DeleteFileAsync(item);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }
    }
}
