namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ConfigToolBoxDevolucao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Devolução";
        public override string TooltipInserir => "Inserir uma nova devolução";
        public override string TooltipEditar => string.Empty;
        public override string TooltipExcluir => string.Empty;
        public override bool EditarHabilitado => false;
        public override bool ExcluirHabilitado => false;
    }
}
