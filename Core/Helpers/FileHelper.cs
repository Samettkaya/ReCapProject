using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            string newGuıd = CreateGuid() + extension;
            var directory = Directory.GetCurrentDirectory() + "\\wwwroot";
            var path = directory + @"\Images";
            var webpath = "/Images/" + newGuıd;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string imagePath;
            using (FileStream fileStream = File.Create(path + "\\" + newGuıd))
            {
                file.CopyTo(fileStream);
                imagePath = path + "\\" + newGuıd;
                fileStream.Flush();
            }
            return webpath;
        }
        public static void Update(IFormFile file, string OldPath)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            using (FileStream fileStream = File.Open(OldPath.Replace("/", "\\"), FileMode.Open))
            {
                file.CopyToAsync(fileStream);
                fileStream.Flush();
            }
        }
        public static void Delete(string ImagePath)
        {
            if (File.Exists(ImagePath.Replace("/", "\\")) && Path.GetFileName(ImagePath) != "default.jpg")
            {
                File.Delete(ImagePath.Replace("/", "\\"));
            }
        }

        private static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}