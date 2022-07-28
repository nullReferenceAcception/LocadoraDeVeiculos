namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracoes
{
    internal class ConfigToolboxConfiguracao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => string.Empty;
        public override string TooltipInserir => string.Empty;
        public override string TooltipEditar => string.Empty;
        public override string TooltipExcluir => string.Empty;

        public override bool InserirHabilitado => false;
        public override bool EditarHabilitado => false;
        public override bool ExcluirHabilitado => false;
        public override bool VisualizarHabilitado => false;
    }
}
