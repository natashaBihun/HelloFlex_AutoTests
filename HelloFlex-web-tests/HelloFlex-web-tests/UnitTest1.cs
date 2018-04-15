using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Net;
using System.Drawing.Imaging;

namespace HelloFlex_web_tests
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            //ChromeOptions options = new ChromeOptions();
            driver = new ChromeDriver();
            verificationErrors = new StringBuilder();
        }

        [Test]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(@"http://jobmore.gluedrecruit-test.nl/");
            // driver.GetScreenshot();//.SaveAsFile(@"screen.png", ImageFormat.Png);

            HttpStatusCode result = default(HttpStatusCode);

            var request = HttpWebRequest.Create(@"http://jobmore.gluedrecruit-test.nl/");
            using (var response = request.GetResponse() as HttpWebResponse) {
                if (response != null) {
                    result = response.StatusCode;
                    response.Close();
                }
            }
             
            Assert.AreEqual(result, HttpStatusCode.OK);
        }

        [TearDown]
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
    }
}
