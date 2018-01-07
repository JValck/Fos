using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Fos.Storage
{
    public class DiskStorage : IStorage
    {
        public void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool Delete(string absolutePath)
        {
            if (File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }
            return false;
        }

        public async Task<bool> SaveAsync(IFormFile formFile, string path)
        {
            CreateFolder(Path.GetDirectoryName(path));
            using(var stream = File.Create(path))
            {
                await formFile.CopyToAsync(stream);
            }
            return true;
        }
    }
}
