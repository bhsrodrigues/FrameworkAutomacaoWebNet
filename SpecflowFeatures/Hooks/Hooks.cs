using BoDi;
using Framework.PageObjects;
using Framework.SeleniumFactory.DriverFactory;
using TechTalk.SpecFlow;

namespace SpecflowFeatures.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static GestaoDriver gestao;

        private static IObjectContainer container;

        [BeforeFeature]
        public static void Teste(GestaoDriver gestao)
        {
            gestao = gestao;
            container = new ObjectContainer();
            container.RegisterInstanceAs(gestao);
        }


        [AfterFeature]
        public static void AfterFeature()
        {
            gestao = container.Resolve<GestaoDriver>();
            gestao.Fechar();
        }
    }
}