using System;
using System.Collections.Generic;
using System.Text;
using SikuliSharp;
using Framework.SikuliFactory.FuncoesComuns;

namespace Framework.SikuliFactory.SikuliPattern
{
    public class GooglePatterns : PatternsFuncoesBase
    {

        protected IPattern BarraPesquisaGoogle()
        {
            string caminho = String.Concat(
                Caminho, "\\GoogleGlobo\\barraPesquisaGoogle.png");

            return DefineElemento(caminho);

        }

        protected IPattern BotaoPesquisarGoogle()
        {

            string caminho = String.Concat(
                Caminho, "\\GoogleGlobo\\botaoPesquisarGoogle.png");

            return DefineElemento(caminho);

        }


        protected IPattern BarraPesquisaGoogleNoturno()
        {
            string caminho = String.Concat(
                Caminho, "\\GoogleGlobo\\barraPesquisaGoogleNoturno.png");

            return DefineElemento(caminho);

        }

        protected IPattern BotaoPesquisarGoogleNoturno()
        {

            string caminho = String.Concat(
                Caminho, "\\GoogleGlobo\\botaoPesquisarGoogleNoturno.png");

            return DefineElemento(caminho);

        }

        protected IPattern LogoGlobo()
        {

            string caminho = String.Concat(
                Caminho, "\\GoogleGlobo\\logoGlobo.png");

            return DefineElemento(caminho);

        }



        public void PesquisarSite(string site)
        {

            using (var session = Sikuli.CreateSession())
            {

                if (session.Exists(BarraPesquisaGoogle()))
                {


                    session.Click(BarraPesquisaGoogle());
                    session.Type(site + @"\t");
                    session.Click(BotaoPesquisarGoogle());
                }
                else if (session.Exists(BarraPesquisaGoogleNoturno()))
                {
                    session.Click(BarraPesquisaGoogleNoturno());
                    session.Type(site + @"\t");
                    session.Click(BotaoPesquisarGoogleNoturno());
                }
                
            }
        }

        public bool ContemLogo()
        {
            using (var session = Sikuli.CreateSession())
            {
                return session.Exists(LogoGlobo());
            }
        }
    }
}