using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CalculatorTests
{
    public class CalculatorPOM
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id)]
        public IWebElement resultWindow { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn1 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn2 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn3 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn4 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn5 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn6 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn7 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn8 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn9 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btn0 { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btnAdd { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btnSub { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btnMul { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btnDiv { get; private set; }

        [FindsBy(How = How.Id)]
        public IWebElement btnEqual { get; private set; }


        public CalculatorPOM(IWebDriver driver)
        {
            this.driver = driver;

            if (driver.Title != "Calculator")
            {
                throw new NoSuchWindowException("This is not the Calculator page");
            }
        }
    }
}
