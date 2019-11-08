using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRate.Scripts
{
    class StringParserToInt
    {
        public static float Parse(string text)
        {

            float x;

            if (float.TryParse(text, out x))
            {
                return x = float.Parse(text);
            }
            else
            {
                throw new Exception("Canno't parse string");
            }
        }
    }
}
