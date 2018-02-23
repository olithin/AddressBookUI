using System;
using System.Text;
using NUnit.Framework;

namespace AddressbookWebTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
        }
        public static Random rnd = new Random();

        public static string GeneraterandomString(int max)
        {       
            var l = Convert.ToInt32(rnd.NextDouble() * max);
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                stringBuilder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return stringBuilder.ToString();
        }
    }
}