using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ConfigToolBoxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Plano de Cobranca";
        public override string TooltipInserir => "Inserir um nova Plano de Cobranca";
        public override string TooltipEditar => "Editar um Plano de Cobranca existente";
        public override string TooltipExcluir => "Excluir um Plano de Cobranca existente";
        public override string TooltipVisualizar => "Visualizar um Plano de Cobranca existente";
    }
}
