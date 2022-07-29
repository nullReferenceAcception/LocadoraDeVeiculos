using Locadora.Infra.Configs;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracoes
{
    public class ControladorConfiguracao : ControladorBase
    {
        private TabelaConfiguracoesControl _tabelaConfiguracoes;
        private readonly ConfiguracaoAplicacaoLocadora configuracao;

        public ControladorConfiguracao(ConfiguracaoAplicacaoLocadora configuracao)
        {
            this.configuracao = configuracao;
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxConfiguracao();
        }

        public override UserControl ObtemListagem()
        {
            return new TabelaConfiguracoesControl(configuracao);
        }
    }
}
