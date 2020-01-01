using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Infrastructure.Api.Scripts
{
    public class FileDownloader : IDownloader
    {
        public void Get(string Url, string FileName)
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(Url, FileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public static IDownloader Create()
        {
            return new FileDownloader();
        }
    }
}
