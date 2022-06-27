using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfigToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cliente";

        public override string TooltipInserir => "Inserir uma nova Cliente";

        public override string TooltipEditar => "Editar uma Cliente existente";

        public override string TooltipExcluir => "Excluir uma Cliente existente";
    }
    
    
}
