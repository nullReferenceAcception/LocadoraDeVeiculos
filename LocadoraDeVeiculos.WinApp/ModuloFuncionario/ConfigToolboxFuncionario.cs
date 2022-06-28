namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfigToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Funcionário";
        public override string TooltipInserir => "Inserir novo funcionário";
        public override string TooltipEditar => "Editar funcionário existente";
        public override string TooltipExcluir => "Excluir funcionário existente";
        public override string? TooltipVisualizar => "Vizualisar funcionãrio existente";
    }
}
