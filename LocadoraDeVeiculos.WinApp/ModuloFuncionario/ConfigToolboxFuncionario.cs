namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfigToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Funcionário";
        public override string TooltipInserir => "Inserir um novo funcionário";
        public override string TooltipEditar => "Editar um funcionário existente";
        public override string TooltipExcluir => "Excluir um funcionário existente";
        public override string? TooltipVisualizar => "Visualizar um funcionário existente";
    }
}
