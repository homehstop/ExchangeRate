using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Infrastructure.Api.FileSystem
{
    public class DirectoryManager
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="DirectoryPath"> Directory.GetCurrentDirectory() </param>
        DirectoryManager(string DirectoryPath)
        {
            if (Directory.Exists(DirectoryPath))
                Directory.SetCurrentDirectory(DirectoryPath);
            else
                CreateDirectory(DirectoryPath);
        }
        
        public void SetDirectoryPath(string DirectoryPath)
        {
            Directory.SetCurrentDirectory(DirectoryPath);
        }

        /// <summary>
        /// Create directory in current directory path
        /// </summary>
        /// <param name="DirectoryName"></param>
        public void CreateDirectory(string DirectoryName)
        {
            Directory.CreateDirectory(DirectoryName);
        }

        public IEnumerable<string> GetFilesInDirectory()
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
            return files;
        }

        public static DirectoryManager Create(string DirectoryPath)
        {
            return new DirectoryManager(DirectoryPath);
        }
    }
}
