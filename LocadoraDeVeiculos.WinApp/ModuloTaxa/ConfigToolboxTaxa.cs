namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ConfigToolboxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Taxa";
        public override string TooltipInserir => "Inserir uma nova taxa";
        public override string TooltipEditar => "Editar uma taxa existente";
        public override string TooltipExcluir => "Excluir uma taxa existente";
        public override string? TooltipVisualizar => "Visualizar uma taxa existente";
    }
}
