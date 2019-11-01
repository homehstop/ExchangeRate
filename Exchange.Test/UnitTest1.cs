using NUnit.Framework;
using Exchange.Private.DataTypes;
using Exchange.Private.Scripts;

namespace Exchange.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void JsonReaderTest()
        {
            JsonReader s = new JsonReader(new ExchangeRate());
            s.Read("test.json");
            ExchangeRate a = s.GetExchangeRate();
            Assert.IsNotNull(a == null);
        }
    }
}