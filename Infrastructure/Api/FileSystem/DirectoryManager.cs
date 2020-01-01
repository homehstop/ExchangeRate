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
        public DirectoryManager(string DirectoryPath)
        {
            Directory.SetCurrentDirectory(DirectoryPath);
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
    }
}
