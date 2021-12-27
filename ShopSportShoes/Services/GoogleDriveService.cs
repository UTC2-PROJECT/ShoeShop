using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
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

        public string UploadFIle(string path)
        {
            var service = GetDriveServiceInstance();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "image/jpeg";
            FilesResource.CreateMediaUpload request;
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
                return file.Id;
            }
            catch(Exception e)
            {
                return null;
            }
        }

    }
}
