using System;
using System.Collections.Generic;
using System.Text;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace Framework.PageObjects
{
    [Binding]
    public class GooglePage : PageBase
    {

        public GooglePage(IObjectContainer container) : base(container)
        {

        }

        private IWebElement ResultadoPesquisa()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath
                ("//a[contains(.,'globo.com')]")));
            //return _driver.FindElement(By.XPath("//a[contains(.,'globo.com')]"));
        }

        public void AcessaResultado()
        {
            ResultadoPesquisa().Click();
        }

    }
}
