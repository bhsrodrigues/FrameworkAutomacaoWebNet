using SikuliSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.SikuliFactory.FuncoesComuns
{
    public class PatternsFuncoesBase
    {
        protected string Caminho = "@..\\..\\..\\..\\..\\..\\Framework\\SikuliFactory\\Imagens";

        protected IPattern DefineElemento(string caminho)
        {
            var teste = System.IO.Path.GetFullPath(caminho);

            var elemento = Patterns.FromFile(System.IO.Path.GetFullPath(teste));

            return elemento;
            //return ValidaExistenciaElemento(elemento, timeout) ? elemento : null;
        }

        /*protected bool ValidaExistenciaElemento(IPattern pattern, int timeout)
        {
            using (var session = Sikuli.CreateSession())
            {
                return session.Exists(pattern,timeout);

            }
        }*/

    }
}
