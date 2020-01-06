using NUnit.Framework;
using System.IO;
using Infrastructure.Api.Scripts;

namespace Infrastructure.Tests
{
    class FIleDownloaderTest
    {
        [Test]
        public void Test_Download()
        {
            var downloader = FileDownloader.Create();
            Assert.IsTrue(downloader != null);
            downloader.Get("https://www.alphavantage.co/query?function=FX_MONTHLY&from_symbol=USD&to_symbol=EUR&apikey=JIM07LC18T4I2AHC", "tmp/test.json");
            Assert.IsFalse(File.Exists("tmp/text.json"));
        }
    }
}
