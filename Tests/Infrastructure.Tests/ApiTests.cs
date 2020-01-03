using NUnit.Framework;
using System.IO;
using Infrastructure.Api;

namespace Infrastructure.Tests
{
    class ApiTests
    {
        [Test]
        public void Test_API()
        {
            var i = Api.Api.Create();
            i.Init();
        }
    }
}
