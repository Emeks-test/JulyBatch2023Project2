
using OpenQA.Selenium.Edge;

namespace JulyBatch2023Project2.BaseHooks
{
    public enum Btype 
    {
        Chrome,
        Firefox,
        Edge,
        Chromium


    
    }
        
    public class BasePage
    {
        public IWebDriver driver;
        [SetUp] 
        public void Start() 
        {
            chooseFromTheList(Btype.Chrome);

        }
        public void chooseFromTheList(Btype btype)
        {
            var browsers = btype == Btype.Chrome
                 ? driver = new ChromeDriver()
                 : driver = btype == Btype.Firefox
                 ? driver = new FirefoxDriver()
                 : driver = btype == Btype.Edge
                 ? driver = new EdgeDriver()
                 : throw new Exception("No such browser");
        }

        [TearDown]

        public void End() 
        {
            driver.Quit();

        }


       

       
       

       

    }
}
