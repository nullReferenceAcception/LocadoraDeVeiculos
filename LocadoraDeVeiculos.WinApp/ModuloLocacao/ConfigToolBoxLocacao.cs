namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ConfigToolBoxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Locação";
        public override string TooltipInserir => "Inserir uma nova locação";
        public override string TooltipEditar => "Editar uma locação existente";
        public override string TooltipGerarPdf => "Gerar um PDF de locação";
        public override bool GerarPdfHabilitado => true;
        public override string TooltipExcluir => "Inativar uma locação existente";
        public override string? ToolTipDesabilitados => "Visualizar locação Inativado ou Finalizado";
        public override bool Desabilitados => true;
    }
}
