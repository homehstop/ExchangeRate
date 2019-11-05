using NUnit.Framework;

using Exchange.Private;
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
        public void ApiTest()
        {
            Api test = new Api();
            ExchangeDataList s = new ExchangeDataList();
            s = test.Init();
        }
    }
}