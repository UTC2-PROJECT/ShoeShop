using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSportShoes.Services
{
    public class ImageFileService
    {
        string _rootFolder = "./wwwroot/images/Shoes";
        public async Task<bool> AddImageFile(IBrowserFile browserFile, string imageName)
        {
            if (Directory.Exists(_rootFolder))
            {
                string filePath = Path.Combine(_rootFolder, imageName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await browserFile.OpenReadStream(10240000).CopyToAsync(stream);
                }
                return true;
            }
            return false;
        }

        public bool DeleteImage(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                string filePath = Path.Combine(_rootFolder, imageName);

                using (var stream = File.Open(filePath, FileMode.Open))
                {
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            File.Delete(filePath);
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        public void DeleteRangeImage(List<string> imageNames)
        {
            foreach (var imageName in imageNames)
            {
                DeleteImage(imageName);
            }
        }
    }
}
