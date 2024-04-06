
using JulyBatch2023Project2.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace JulyBatch2023Project2.TestModules
{
    public class AutomationBasics: BasePage
    {

        [Test]
        public void TestAutomation101()
        {
            
            
            //saving actual value
            var myurl = driver.Url;

            //Assert.AreEqual(Environments.AutomationUrl, driver.Url);

            Assert.That(myurl, Is.EqualTo(Environments.AutomationUrl));

            //fluentassertion
            driver.Url.Should().Be(Environments.AutomationUrl);
            Console.WriteLine(driver.Title);

            //driver.FindElement(By.Id("firstpassword")).SendKeys("Emeka");
            //var = firstName = driver.FindElement(By.Id("firstpassword"));
            //firstName..SendKeys("Emeka");

            Thread.Sleep(10000);

            //driver.FindElement(By.CssSelector("input[placeholder='First Name']")).SendKeys("Emeka");


            //driver.FindElement(By.XPath("//input[@placeholder='First Name']")).SendKeys("Emeka");
            driver.FindElements(By.TagName("input"))[0].SendKeys("Emeka");
            driver.FindElements(By.TagName("input"))[1].SendKeys("Ekebere");

            //driver.FindElement(By.LinkText("WebTable")).Click();

            //driver.FindElement(By.ClassName("")).SendKeys("");

            Thread.Sleep(5000);
            driver.Quit();



        }

        [Test]
        public void TestAutomation102()
        {
            

            var address = driver.FindElement(By.XPath("//textarea[contains(@class,'form-control')]"));
            address.SendKeys("A to Z");

            var firstName = driver.FindElement(By.CssSelector("input[placeholder=\"First Name\"]"));
            firstName.SendKeys("Emeka");

            var lastName = driver.FindElement(By.XPath("//input[@placeholder=\'Last Name\']"));
            lastName.SendKeys("Ekebere");

            var phoneNo = driver.FindElement(By.XPath("//input[@type=\"tel\"]"));
            phoneNo.SendKeys("0753997855");

            var inputElements = driver.FindElements(By.XPath("//input"));
            inputElements[4].Click();
            inputElements[7].Click();

            Thread.Sleep(3000);

            driver.Quit();

           

        }

        [Test]
        public void IJavaScriptEample()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Environments.AutomationUrl);



            //iJavaScript Example
            var inputElements = driver.FindElements(By.XPath("//input"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguements[0].click()", inputElements[4]);
            js.ExecuteScript("arguements[0].click()", inputElements[6]);

            driver.Quit();



        }
        [Test]

        public void ActionsExamle() 
        {
            

            var inputElements = driver.FindElements(By.XPath("//input"));
            Actions action = new Actions(driver);
            action.Click(inputElements[4]).Perform();
            action.Click(inputElements[7]).Perform();

            var firstName = driver.FindElement(By.CssSelector("input[placeholder=\"First Name\"]"));
            action
                .Click(firstName)
                .SendKeys("Emeka")
                .Build()
                .Perform();

            //Drop down 

            var year = driver.FindElement(By.Id("yearbox"));
            SelectElement yeardropdown = new SelectElement(year);
            yeardropdown.SelectByText("1925");

            var month = driver.FindElement(By.CssSelector("[ng-model='monthbox']"));
            SelectElement monthdropdown = new SelectElement(month);
            monthdropdown.SelectByText("February");

            var day = driver.FindElement(By.Id("daybox"));
            SelectElement daydropdown = new SelectElement(day);
            daydropdown.SelectByText("1");

            Console.WriteLine(driver.FindElement(By.XPath("//h2")).Text);
            Assert.That(driver.FindElement(By.XPath("//h2")).Text, Is.EqualTo("Register"));

            //var headText = driver.FindElement(By.XPath("//h2")).Text;

            var textFile = driver.FindElement(By.CssSelector("#imagesrc"));
            textFile.SendKeys("\"C:\\Users\\Toshiba\\Desktop\\New Text Document.txt\"");


            Thread.Sleep(3000);
            driver.Quit();

        }

        [Test]

        public void ExplicitWaitTest() 
        {
            driver.Navigate().GoToUrl(Environments.DemoqaUrlAlertsPage);
            driver.FindElement(By.Id("timerAlertButton")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            Console.WriteLine(driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("confirmButton")).Click();
            driver.SwitchTo().Alert().Dismiss();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("confirmResult")));
            Console.WriteLine(driver.FindElement(By.Id("confirmResult")).Text); 

                       
        }
        //custom wait method

        public void WaitForElementBy() 
        { 
        
        }




        [Test]

        public void SwitchTabTest() 
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Environments.DemoqaUrl);

            driver.FindElement(By.CssSelector("#tabButton")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine(driver.FindElement(By.Id("sampleHeading")).Text);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.CssSelector("#windowButton")).Click();

            Thread.Sleep(3000);
            driver.Quit();

        }

        [Test]

        public void POMTest() 
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickContactUs();
            ContactUsPage contactUsPage = new ContactUsPage(driver);
            contactUsPage.FillContactUsForm("emekka", "emeka@abc", "my querry", "to be resolved");


        
        }
    }
}
