using BoDi;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObjects
{
    public class AmazonPage : PageBase
    {
        private string livro;
        public AmazonPage(IObjectContainer container) : base(container)
        {

        }

        private IWebElement BarraPesquisa()
        {
            return _driver.FindElement(By.Id("twotabsearchtextbox"));
        }

        private IWebElement PrimeiroResultadoLivro()
        {
            string XpathLivro = String.Format(
                "//*[@data-component-type='s-search-result'][1]//a[contains(.,'{0}')]", livro);
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XpathLivro)));
        }

        private IWebElement LabelEdicaoBrasileira()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-component-type='s-search-result'][1]//span[contains(.,'Português')]")));
        }

        private IWebElement BotaoCarrinho()
        {
            return _driver.FindElement(By.Id("add-to-cart-button"));
        }

        private IWebElement BotaoFecharCompra()
        {
            return _driver.FindElement(By.Name("proceedToRetailCheckout"));
        }


        private IWebElement CampoEmail()
        {
            return _driver.FindElement(By.Id("ap_email"));
        }
        private IWebElement BotaoContinuarLogin()
        {
            return _driver.FindElement(By.Id("continue"));
        }
        private IWebElement CampoSenha()
        {
            try
            {
                return _driver.FindElement(By.Id("ap_password"));
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        private IWebElement BotaoEfetuarLogin()
        {
            return _driver.FindElement(By.Id("signInSubmit"));
        }
        private IWebElement LabelUsuarioSenhaIncorretos()
        {

            return _wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("a-list-item")));
        }

        public void AcessaDetalheProduto()
        {
            PrimeiroResultadoLivro().Click();
        }

        public void AdicionaProdutoAoCarrinho()
        {
            BotaoCarrinho().Click();
        }

        public void EfetuarLogin(string login, string senha)
        {
            BotaoFecharCompra().Click();
            CampoEmail().SendKeys(login);
            BotaoContinuarLogin().Click();
            if (CampoSenha()!=null)
            {
                CampoSenha().SendKeys(senha);
                BotaoEfetuarLogin().Click();
            }
        }

        public void PesquisaLivro(string p0)
        {
            livro = p0;
            BarraPesquisa().Click();
            BarraPesquisa().SendKeys(p0 + Keys.Enter);
        }

        public bool ValidaElemento()
        {
            return ComparaTexto(LabelUsuarioSenhaIncorretos(),
                "Não encontramos uma conta associada a este endereço de e-mail") || 
                ComparaTexto(LabelUsuarioSenhaIncorretos(),
                "Sua senha está incorreta");
        }

        public bool ValidaResultadoPesquisa()
        {
            return !PrimeiroResultadoLivro().Equals(null) &&
                !LabelEdicaoBrasileira().Equals(null);
        }
    }
}
