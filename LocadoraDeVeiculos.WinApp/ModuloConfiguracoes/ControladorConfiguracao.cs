using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloConfiguracoes
{
    public class ControladorConfiguracao : ControladorBase
    {
        private TabelaConfiguracoesControl _tabelaConfiguracoes;

        public ControladorConfiguracao()
        {

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
            if (_tabelaConfiguracoes == null)
                _tabelaConfiguracoes = new TabelaConfiguracoesControl();

            return _tabelaConfiguracoes;
        }
    }
}
