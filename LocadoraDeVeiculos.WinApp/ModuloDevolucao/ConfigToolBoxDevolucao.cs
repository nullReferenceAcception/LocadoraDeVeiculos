namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ConfigToolBoxDevolucao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Devolução";
        public override string TooltipInserir => "Inserir uma nova devolução";
        public override string TooltipEditar => "Editar uma devolução???";
        public override string TooltipExcluir => "Excluir uma devolução!?";
        public override string TooltipGerarPdf => "Gerar PDF da devolução";
        public override bool GerarPdfHabilitado => true;
    }
}
