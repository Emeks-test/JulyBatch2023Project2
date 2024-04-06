
namespace JulyBatch2023Project2.NewTestModules
{
    public class NewPracticalTest : BasePage
    {
        [Test]

        public void NewPracticalTest01() 
        {
            var inputElements = driver.FindElements(By.XPath("//input"));
            Actions action =new Actions(driver);
            action.Click(inputElements[4]).Perform();
            action.Click(inputElements[7]).Perform();

            var firstName = driver.FindElement(By.CssSelector("input[placeholder=\"First Name\"]"));
            action
                .Click(firstName)
                .SendKeys("Emeka")
                .Build()
                .Perform();





        }

    }
}
