using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.Compartilhado
{
    public static class FuncoesTeste
    {

        public static string GerarNovaStringAleatoria()
        {
            const int qtdeLetras = 8;

            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string novaPlaca = "";
            Random random = new();

            for (int i = 0; i < qtdeLetras; i++)
                novaPlaca += letras[random.Next(letras.Length)];

            return novaPlaca;
        }

    }
}
