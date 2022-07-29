namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfigToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Funcionário";
        public override string TooltipInserir => "Inserir um novo funcionário";
        public override string TooltipEditar => "Editar um funcionário existente";
        public override string TooltipExcluir => "Desabilitar um funcionário existente";
        public override string? TooltipVisualizar => "Visualizar um funcionário existente";
        public override string? ToolTipDesabilitados => "Visualizar funcionários desabilitados";
        public override bool Desabilitados => true;
    }
}
