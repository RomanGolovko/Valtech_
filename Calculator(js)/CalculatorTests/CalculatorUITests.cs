//using System;
//using System.Drawing.Imaging;
//using System.Text;
//using NUnit.Framework;
//using NUnit.Framework.Interfaces;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.IE;

//namespace SeleniumTests
//{
//    [TestFixture("firefox")]
//    [TestFixture("chrome")]
//    [TestFixture("ie")]
//    public class CalculatorUITests
//    {
//        private IWebDriver driver;
//        private StringBuilder verificationErrors;
//        private string baseURL;
//        private bool acceptNextAlert = true;
//        private string browser;

//        public CalculatorUITests(string browser)
//        {
//            this.browser = browser;
//        }

//        [OneTimeSetUp]
//        public void SetupTest()
//        {
//            switch (browser)
//            {
//                case "firefox":
//                    driver = new FirefoxDriver();
//                    break;
//                case "chrome":
//                    driver = new ChromeDriver(@"C:\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Resourse");
//                    break;
//                case "ie":
//                    driver = new InternetExplorerDriver(@"C:\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Resourse");
//                    break;
//                default: break;
//            }

//            baseURL = @"C:\Users\Roman\Documents\Visual Studio 2015\WebSite\Calculator(js)\Calculator.html";
//            verificationErrors = new StringBuilder();
//        }

//        [OneTimeTearDown]
//        public void TeardownTest()
//        {
//            try
//            {
//                driver.Quit();
//            }
//            catch (Exception)
//            {
//                // Ignore errors if unable to close the browser
//            }
//        }

//        [TearDown]
//        public void GetScreenShot()
//        {
//            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
//            var drv = (ITakesScreenshot)driver;
//            var screenShotImage = drv.GetScreenshot();
//            screenShotImage.SaveAsFile(@"C:\\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Screenshots.jpeg", ImageFormat.Jpeg);
//        }

//        [Test]
//        public void Can_Press_Single_Buttons([Range(0, 9)]int value)
//        {
//            var expected = value;
//            driver.Navigate().GoToUrl(baseURL);
//            driver.FindElement(By.Id("btn" + value)).Click();
//            var actual = driver.FindElement(By.Id("resultWindow")).GetAttribute("value");
//            Assert.AreEqual(expected.ToString(), actual);
//        }

//        [Test]
//        public void Can_Press_Many_Buttons([Range(0, 9)]int value)
//        {
//            var expected = $"{value}{value}{value}{value}{value}{value}{value}{value}{value}{value}";
//            driver.Navigate().GoToUrl(baseURL);
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            var actual = driver.FindElement(By.Id("resultWindow")).GetAttribute("value");
//            Assert.AreEqual(expected, actual);
//        }

//        [Test]
//        public void Can_Do_Action([Range(1, 9)]int num, [Values("Add", "Sub", "Mul", "Div")]string value)
//        {
//            var expected = 0;
//            switch (value)
//            {
//                case "Add": expected = num + num; break;
//                case "Sub": expected = num - num; break;
//                case "Mul": expected = num * num; break;
//                case "Div":
//                    {
//                        if (num == 0)
//                        {
//                            return;
//                        }

//                        expected = num / num;
//                    }
//                    break;

//                default:
//                    break;
//            }

//            driver.Navigate().GoToUrl(baseURL);
//            driver.FindElement(By.Id("btn" + num)).Click();
//            driver.FindElement(By.Id("btn" + value)).Click();
//            driver.FindElement(By.Id("btn" + num)).Click();
//            driver.FindElement(By.Id("btnEqual")).Click();
//            var actual = driver.FindElement(By.Id("resultWindow")).GetAttribute("value");
//            Assert.AreEqual($"{expected}", actual);
//        }

//        [Test]
//        public void Can_Get_Alert([Range(0, 9)]int num)
//        {
//            driver.Navigate().Refresh();
//            driver.Navigate().GoToUrl(baseURL);
//            driver.FindElement(By.Id("btn" + num)).Click();
//            driver.FindElement(By.Id("btnDiv")).Click();
//            driver.FindElement(By.Id("btn0")).Click();
//            driver.FindElement(By.Id("btnEqual")).Click();
//            var alert = driver.SwitchTo().Alert().Text;
//            Assert.AreEqual("You can't devide by zero", alert);
//            driver.Navigate().Refresh();
//        }

//        private bool IsElementPresent(By by)
//        {
//            try
//            {
//                driver.FindElement(by);
//                return true;
//            }
//            catch (NoSuchElementException)
//            {
//                return false;
//            }
//        }

//        private bool IsAlertPresent()
//        {
//            try
//            {
//                driver.SwitchTo().Alert();
//                return true;
//            }
//            catch (NoAlertPresentException)
//            {
//                return false;
//            }
//        }

//        private string CloseAlertAndGetItsText()
//        {
//            try
//            {
//                IAlert alert = driver.SwitchTo().Alert();
//                string alertText = alert.Text;
//                if (acceptNextAlert)
//                {
//                    alert.Accept();
//                }
//                else
//                {
//                    alert.Dismiss();
//                }
//                return alertText;
//            }
//            finally
//            {
//                acceptNextAlert = true;
//            }
//        }
//    }
//}
