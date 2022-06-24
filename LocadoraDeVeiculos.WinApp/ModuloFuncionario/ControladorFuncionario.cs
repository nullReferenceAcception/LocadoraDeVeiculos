using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IRepositorioFuncionario? _repositorioFuncionario;
        private TabelaFuncionarioControl? _tabelaFuncionario;

        public ControladorFuncionario(IRepositorioFuncionario rep)
        {
            _repositorioFuncionario = rep;
        }
        public override void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new();

            tela.Funcionario = new();

            tela.GravarRegistro = _repositorioFuncionario!.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
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
            return new ConfigToolboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaFuncionario == null)
                _tabelaFuncionario = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return _tabelaFuncionario;
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = _repositorioFuncionario!.SelecionarTodos();

            _tabelaFuncionario!.AtualizarRegistros(funcionarios);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {funcionarios.Count} funcionários");
        }
    }
}
