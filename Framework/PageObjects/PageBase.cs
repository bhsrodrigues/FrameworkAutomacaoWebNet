using BoDi;
using Framework.SeleniumFactory.DriverFactory;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static Framework.SeleniumFactory.DriverFactory.DriverList;

namespace Framework.PageObjects
{
    [Binding]
    public class PageBase
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;


        /*public PageBase(WebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }*/

        public PageBase(IObjectContainer container)
        {
            var resultContainer = container.Resolve<GestaoDriver>();
            _driver = resultContainer.GetDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void AcessarSite(string site)
        {
            _driver.Navigate().GoToUrl(site);
        }

        protected bool ComparaTexto(IWebElement element, string texto)
        {
            return element.Text.ToLower().Equals(texto.ToLower());
        }

    }
}
