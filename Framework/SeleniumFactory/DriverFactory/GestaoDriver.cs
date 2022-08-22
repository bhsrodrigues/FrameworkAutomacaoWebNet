using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Framework.SeleniumFactory.DriverFactory
{
    [Binding]
    public class GestaoDriver
    {
        WebDriver driver;
        GerenciadorDrivers gerenciadorDrivers;
        public GestaoDriver()
        {
            gerenciadorDrivers = new GerenciadorDrivers();
            IniciarBrowser();
        }

        public void Navegar(string site)
        {
            driver.Navigate().GoToUrl(site);
        }

        public void IniciarBrowser()
        {
            driver = gerenciadorDrivers.DefineDriver(DriverList.Drivers.Firefox);
        }

        public void Fechar()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }


        public WebDriver GetDriver()
        {
            return driver;
        }
    }
}
