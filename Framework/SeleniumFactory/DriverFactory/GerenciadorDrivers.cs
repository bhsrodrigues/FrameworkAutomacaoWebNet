using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using static Framework.SeleniumFactory.DriverFactory.DriverList;

namespace Framework.SeleniumFactory.DriverFactory
{
    public class GerenciadorDrivers
    {

        private string Caminho = "@..\\..\\..\\..\\..\\..\\Framework\\SeleniumFactory\\Drivers";

        public WebDriver DefineDriver(DriverList.Drivers driver)
        {
            var teste = System.IO.Path.GetFullPath(Caminho);
            Console.Write(teste);
            if (driver.Equals(DriverList.Drivers.Firefox)) return SetUpFirefox();
            if (driver.Equals(DriverList.Drivers.Chrome)) return SetUpChrome();
            if (driver.Equals(DriverList.Drivers.Edge)) return SetUpEdge();
            return null;
        }

        private FirefoxDriver SetUpFirefox()
        {
            return new FirefoxDriver(Caminho);
        }

        private ChromeDriver SetUpChrome()
        {
            return new ChromeDriver(Caminho);
        }

        private EdgeDriver SetUpEdge()
        {
            return new EdgeDriver(Caminho);
        
        }

    }
}
