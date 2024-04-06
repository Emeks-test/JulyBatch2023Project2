using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulyBatch2023Project2.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver _driver)
        {
                driver = _driver;
        }

        IWebElement contactUs => driver.FindElement(By.LinkText("Contact us"));

    }
}
