namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfigToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cliente";
        public override string TooltipInserir => "Inserir um novo cliente";
        public override string TooltipEditar => "Editar um cliente existente";
        public override string TooltipExcluir => "Excluir um cliente existente";
        public override string TooltipVisualizar => "Vizualizar um cliente existente";
    }
}
