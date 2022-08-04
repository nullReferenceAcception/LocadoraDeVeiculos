using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public interface IGeradorRelatorioDevolucao
    {
        public string GerarRelatorioPDF(Devolucao devolucao);
    }
}
