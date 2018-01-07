using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Storage
{
    public interface IStorage
    {
        /// <summary>
        /// saves the file uploaded in a form to the storage
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="path">Absolute path where the file should be stored</param>
        /// <returns></returns>
        Task<bool> SaveAsync(IFormFile formFile, string path);

        void CreateFolder(string path);

        bool Delete(string absolutePath);
    }
}
