using BoDi;
using Framework.PageObjects;
using Framework.SeleniumFactory.DriverFactory;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecflowFeatures.StepDefinitions
{
    [Binding]
    public class CompraLivroAmazonSemSucessoStepDefinitions
    {
        private static AmazonPage amazon;
        GestaoDriver gestao;
        IObjectContainer container;

        public CompraLivroAmazonSemSucessoStepDefinitions(IObjectContainer container)
        {
            this.container = container;
        }

        [Given(@"que esteja no site da Amazon")]
        public void GivenQueEstejaNoSiteDaAmazon()
        {
            amazon = new AmazonPage(container);
            amazon.AcessarSite("https://www.amazon.com.br");
        }

        [When(@"pesquiso pelo livro ""([^""]*)""")]
        public void WhenPesquisoPeloLivro(string p0)
        {
            amazon.PesquisaLivro(p0);
        }

        [Then(@"será exibido o livro nos resultados")]
        public void ThenSeraExibidoOLivroNosResultados()
        {
            Assert.True(amazon.ValidaResultadoPesquisa());
        }


        [Given(@"que esteja na tela do produto")]
        public void GivenQueEstejaNaTelaDoProduto()
        {
            amazon.AcessaDetalheProduto();
        }

        [When(@"adiciono o produto ao carrinho")]
        public void WhenAdicionoOProdutoAoCarrinho()
        {
            amazon.AdicionaProdutoAoCarrinho();
        }

        [When(@"vou efetuar login")]
        public void WhenVouEfetuarLogin(Table table)
        {
            string login, senha;

            var DataTableDicionario = new Dictionary<string, string>();
            
            foreach (var row in table.Rows)
            {
                DataTableDicionario.Add(row[0], row[1]);
            }

            login = DataTableDicionario["Login"];
            senha = DataTableDicionario["Senha"];

            amazon.EfetuarLogin(login, senha);
        }

        [Then(@"será exibida mensagem de login e/ou senha inválido")]
        public void ThenSeraExibidaMensagemDeLoginEOuSenhaInvalido()
        {
            amazon.ValidaElemento();
        }
    }
}
