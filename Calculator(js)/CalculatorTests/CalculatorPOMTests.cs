using System;
using System.Drawing.Imaging;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;

namespace CalculatorTests
{
    public class CalculatorPOMTests
    {
        [TestFixture("firefox")]
        [TestFixture("chrome")]
        [TestFixture("ie")]
        public class CalculatorTest
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;
            private string browser;

            public CalculatorTest(string browser)
            {
                this.browser = browser;
            }

            [OneTimeSetUp]
            public void SetupTest()
            {
                switch (browser)
                {
                    case "firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "chrome":
                        driver = new ChromeDriver(@"C:\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Resourse");
                        break;
                    case "ie":
                        driver = new InternetExplorerDriver(@"C:\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Resourse");
                        break;
                    default: break;
                }

                baseURL = @"C:\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Calculator(js)\Calculator.html";
                verificationErrors = new StringBuilder();
            }

            [OneTimeTearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [TearDown]
            public void GetScreenShot()
            {
                if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed) return;
                var drv = (ITakesScreenshot)driver;
                var screenShotImage = drv.GetScreenshot();
                screenShotImage.SaveAsFile(@"C:\Users\Roman\Documents\Visual Studio 2015\Projects\Calculator(js)\Screenshots.jpeg", ImageFormat.Jpeg);
            }

            #region Presention
            [Test]
            public void Can_Find_Btn1()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn1 = calculator.btn1;
                Assert.IsNotNull(btn1);
            }
            [Test]
            public void Can_Find_Btn2()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn2 = calculator.btn2;
                Assert.IsNotNull(btn2);
            }

            [Test]
            public void Can_Find_Btn3()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn3 = calculator.btn3;
                Assert.IsNotNull(btn3);
            }
            [Test]
            public void Can_Find_Btn4()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn4 = calculator.btn4;
                Assert.IsNotNull(btn4);
            }
            [Test]
            public void Can_Find_Btn5()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn5 = calculator.btn5;
                Assert.IsNotNull(btn5);
            }
            [Test]
            public void Can_Find_Btn6()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn6 = calculator.btn6;
                Assert.IsNotNull(btn6);
            }
            [Test]
            public void Can_Find_Btn7()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn7 = calculator.btn7;
                Assert.IsNotNull(btn7);
            }
            [Test]
            public void Can_Find_Btn8()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn8 = calculator.btn8;
                Assert.IsNotNull(btn8);
            }
            [Test]
            public void Can_Find_Btn9()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn9 = calculator.btn9;
                Assert.IsNotNull(btn9);
            }
            [Test]
            public void Can_Find_Btn0()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn0 = calculator.btn0;
                Assert.IsNotNull(btn0);
            }
            [Test]
            public void Can_Find_BtnAdd()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btnAdd = calculator.btnAdd;
                Assert.IsNotNull(btnAdd);
            }
            [Test]
            public void Can_Find_BtnSub()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btnSub = calculator.btnSub;
                Assert.IsNotNull(btnSub);
            }
            [Test]
            public void Can_Find_Btnmul()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btnMul = calculator.btnMul;
                Assert.IsNotNull(btnMul);
            }
            [Test]
            public void Can_Find_BtnDiv()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btnDiv = calculator.btnDiv;
                Assert.IsNotNull(btnDiv);
            }
            [Test]
            public void Can_Find_BtnEqual()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btnEqual = calculator.btnEqual;
                Assert.IsNotNull(btnEqual);
            }
            #endregion

            #region Simple Check
            [Test]
            public void Can_Click_Btn1()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                var btn = calculator.btn1 as IWebElement;
                btn.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("1", actual);
            }
            [Test]
            public void Can_Click_Btn2()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn2.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("2", actual);
            }
            [Test]
            public void Can_Click_Btn3()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn3.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("3", actual);
            }
            [Test]
            public void Can_Click_Btn4()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn4.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("4", actual);
            }
            [Test]
            public void Can_Click_Btn5()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn5.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("5", actual);
            }
            [Test]
            public void Can_Click_Btn6()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn6.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("6", actual);
            }
            [Test]
            public void Can_Click_Btn7()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn7.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("7", actual);
            }
            [Test]
            public void Can_Click_Btn8()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn8.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("8", actual);
            }
            [Test]
            public void Can_Click_Btn9()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn9.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("9", actual);
            }
            [Test]
            public void Can_Click_Btn0()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn0.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("0", actual);
            }
            #endregion

            #region Complex Check
            [Test]
            public void Can_Click_Many_Btn1()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                calculator.btn1.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("111111111", actual);
            }
            [Test]
            public void Can_Click_Many_Btn2()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                calculator.btn2.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("222222222", actual);
            }
            [Test]
            public void Can_Click_Many_Btn3()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                calculator.btn3.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("333333333", actual);
            }
            [Test]
            public void Can_Click_Many_Btn4()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                calculator.btn4.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("444444444", actual);
            }
            [Test]
            public void Can_Click_Many_Btn5()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                calculator.btn5.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("555555555", actual);
            }
            [Test]
            public void Can_Click_Many_Btn6()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                calculator.btn6.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("666666666", actual);
            }
            [Test]
            public void Can_Click_Many_Btn7()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                calculator.btn7.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("777777777", actual);
            }
            [Test]
            public void Can_Click_Many_Btn8()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                calculator.btn8.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("888888888", actual);
            }
            [Test]
            public void Can_Click_Many_Btn9()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                calculator.btn9.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("999999999", actual);
            }
            [Test]
            public void Can_Click_Many_Btn0()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                calculator.btn0.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("000000000", actual);
            }
            #endregion

            #region Real Job
            [Test]
            public void Can_Do_Add_Action()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn1.Click();
                calculator.btnAdd.Click();
                calculator.btn5.Click();
                calculator.btnEqual.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("6", actual);
            }

            [Test]
            public void Can_Do_Sub_Action()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn8.Click();
                calculator.btnSub.Click();
                calculator.btn5.Click();
                calculator.btnEqual.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("3", actual);
            }

            [Test]
            public void Can_Do_Mul_Action()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn4.Click();
                calculator.btnMul.Click();
                calculator.btn5.Click();
                calculator.btnEqual.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("20", actual);
            }
            [Test]
            public void Can_Do_Div_Action()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn9.Click();
                calculator.btnDiv.Click();
                calculator.btn3.Click();
                calculator.btnEqual.Click();
                var actual = calculator.resultWindow.GetAttribute("value");
                Assert.AreEqual("3", actual);
            }
            #endregion

            [Test]
            public void Can_Get_Alert()
            {
                driver.Navigate().GoToUrl(baseURL);
                var calculator = new CalculatorPOM(driver);
                PageFactory.InitElements(driver, calculator);
                calculator.btn9.Click();
                calculator.btnDiv.Click();
                calculator.btn0.Click();
                calculator.btnEqual.Click();
                var alert = driver.SwitchTo().Alert().Text;
                Assert.AreEqual("You can't devide by zero", alert);
            }
        }
    }
}
