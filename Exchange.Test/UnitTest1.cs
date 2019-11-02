using NUnit.Framework;
using Exchange.Private.DataTypes;
using Exchange.Private.Scripts;
using System.Collections.Generic;

namespace Exchange.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReadJsonObject()
        {
            List<ChartModel> test = new List<ChartModel>();
            JsonReader.ChartJsonReader("test.json", test);
            Assert.IsTrue(test != null);
        }
    }
}