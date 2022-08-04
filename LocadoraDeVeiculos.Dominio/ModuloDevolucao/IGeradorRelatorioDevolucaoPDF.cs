using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public interface IGeradorRelatorioDevolucaoPDF
    {
        public string GerarRelatorio(Devolucao devolucao);
    }
}
