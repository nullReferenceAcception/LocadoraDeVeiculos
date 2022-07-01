using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ConfigToolBoxCondutor : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Condutor";
        public override string TooltipInserir => "Inserir um novo Condutor";
        public override string TooltipEditar => "Editar um Condutor existente";
        public override string TooltipExcluir => "Excluir um Condutor existente";
        public override string TooltipVisualizar => "Vizualizar um Condutor existente";
    }
}
