using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulyBatch2023Project2.PageObjects
{
    public class ContactUsPage
    {
        IWebDriver driver;
        public ContactUsPage(IWebDriver _driver)
        {
            driver = _driver;
                          
        }

        IWebElement name =>  driver.FindElement(By.CssSelector("input[name='name']"));
        IWebElement email=>  driver.FindElement(By.CssSelector("input[name='email']"));
        IWebElement subject =>  driver.FindElement(By.CssSelector("input[name='subject']"));
        IWebElement msg =>  driver.FindElement(By.CssSelector("textarea[name='message']"));
        IWebElement submitbtn =>  driver.FindElement(By.CssSelector("input[name='submit']"));


        public void FillContactUsForm(string Name, string Email, string Subject, string Msg) 
        {
            name.SendKeys(Name);
            email.SendKeys(Email);
            subject.SendKeys(Subject);
            msg.SendKeys(Msg);
            submitbtn.Click();
            driver.SwitchTo().Alert().Accept();

            


        }




    }
}
