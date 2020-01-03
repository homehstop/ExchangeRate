using System;
using NUnit.Framework;
using System.IO;
using Infrastructure.Api.FileSystem;

namespace Infrastructure.Tests
{
    class DirectoryManagerTest
    {
        [Test]
        public void Create_Directory()
        {
            try
            {
                DirectoryManager dm = DirectoryManager.Create(Directory.GetCurrentDirectory());
                dm.CreateDirectory("tmp");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.ToString());
            }
        }
    }
}
