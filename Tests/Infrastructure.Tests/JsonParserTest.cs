using NUnit.Framework;
using Infrastructure.Api.Parser;

namespace Infrastructure.Tests
{
    public class JsonParserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Json_Parser()
        {
            var par = JsonParser.Create();
            par.Parse("tmp/test.json", Api.EntityType.Monthly);

            

            Assert.Pass();
        }
    }
}
