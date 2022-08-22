using System;
using TechTalk.SpecFlow;
using Framework.SeleniumFactory.DriverFactory;
using Framework.SikuliFactory.SikuliPattern;
using Framework.PageObjects;
using BoDi;
using NUnit.Framework;

namespace SpecflowFeatures.StepDefinitions
{
    
    [Binding]
    class PesquisaGloboGoogleStepDefinitions
    {
        GooglePage googlePage;
        IObjectContainer container;
        GooglePatterns googlePatterns;

        public PesquisaGloboGoogleStepDefinitions(IObjectContainer container)
        {
            this.container = container;
        }

        [Given(@"que eu acesse o site ""([^""]*)""")]
        public void GivenQueEuAcesseOSite(string p0)
        {
            googlePage = new GooglePage(container);
            googlePage.AcessarSite(p0);
        }

        [When(@"pesquiso por ""([^""]*)""")]
        public void WhenPesquisoPor(string p0)
        {
            googlePatterns = new GooglePatterns();

            googlePatterns.PesquisarSite(p0);
        }

        [Then(@"acesso o site da globo\.com")]
        public void ThenAcessoOSiteDaGlobo_Com()
        {

            googlePage.AcessaResultado();
            Assert.IsTrue(googlePatterns.ContemLogo());
            //if (googlePatterns.ContemLogo()) Assert.Pass(); else Assert.Fail();
            
        }
    }
}
