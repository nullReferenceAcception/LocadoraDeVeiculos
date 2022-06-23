using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ConfigToolboxGrupoVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Grupo de veiculos";

        public override string TooltipInserir => "Inserir uma novo Grupo de veiculos";

        public override string TooltipEditar => "Editar um Grupo de veiculos existente";

        public override string TooltipExcluir => "Excluir um Grupo de veiculos existente";
    }
}
