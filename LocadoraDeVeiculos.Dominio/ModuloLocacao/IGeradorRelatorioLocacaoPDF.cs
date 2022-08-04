using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public interface IGeradorRelatorioLocacaoPDF
    {
        public string GerarRelatorio(Locacao locacao);
    }
}
