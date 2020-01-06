using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Api.Scripts
{
    public interface IDownloader
    {
        public void Get(string Url, string FileName);
    }
}
