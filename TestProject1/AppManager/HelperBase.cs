using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class HelperBase
    {
        protected IWebDriver driver;

        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}