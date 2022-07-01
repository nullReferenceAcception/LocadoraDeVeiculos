namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ConfigToolboxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Veículos";
        public override string TooltipInserir => "Inserir um novo veículo";
        public override string TooltipEditar => "Editar um veículo existente";
        public override string TooltipExcluir => "Excluir um veículo existente";
    }
}
