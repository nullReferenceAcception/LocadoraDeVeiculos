namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ConfigToolBoxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Locação";
        public override string TooltipInserir => "Inserir uma nova locação";
        public override string TooltipEditar => "Editar uma locação existente";
        public override string TooltipExcluir => "Inativar uma locação existente";
    }
}
