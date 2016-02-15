using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Phoneebook.Tests.WebUI.Tests.UI
{
    public class PhonebookIndexPOM
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id)]
        public IWebElement form0 { get; private set; }

        [FindsBy(How = How.Name)]
        public IWebElement str { get; set; }

        [FindsBy(How = How.Id)]
        public IWebElement list { get; set; }

        [FindsBy(How = How.Id)]
        public IWebElement item_UserId { get; set; }

        [FindsBy(How = How.Id)]
        public IWebElement item_StreetId { get; set; }

        public PhonebookIndexPOM(IWebDriver driver)
        {
            this.driver = driver;

            if (driver.Title != "Phonebook - My ASP.NET Application")
            {
                throw new NoSuchWindowException("This is not the Index page");
            }
        }
    }
}
