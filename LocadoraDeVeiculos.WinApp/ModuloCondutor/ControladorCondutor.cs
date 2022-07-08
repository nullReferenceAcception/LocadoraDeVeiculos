using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private IServicoCondutor _servicoCondutor;
        private TabelaCondutorControl _tabelaCondutor;
        private IServicoCliente _servicoCliente;

        public ControladorCondutor(IServicoCondutor servicoCondutor, IServicoCliente servicoCliente)
        {
            this._servicoCliente = servicoCliente;
            _servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            if (_servicoCliente.QuantidadeRegistro() == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo uma empresa para cadastrar um veículo", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroCondutorForm tela = new(_servicoCliente);

            tela.Condutor = new();


            tela.GravarRegistro = _servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                Carregarcondutor();
        }

        public override void Editar()
        {
            var numero = _tabelaCondutor.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = _servicoCondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um condutor para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroCondutorForm(_servicoCliente);

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = _servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                Carregarcondutor();
        }
  
        public override void Excluir()
        {
            var numero = _tabelaCondutor.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = _servicoCondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um condutor para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
               "Exclusão de condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            ValidationResult validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoCondutor.Excluir(condutorSelecionado);
                Carregarcondutor();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro", CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelaCondutor.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = _servicoCondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione um condutor para visualizar", CorParaRodape.White);
                return;
            }

            var tela = new TelaCadastroCondutorForm(_servicoCliente);

            tela.Condutor = condutorSelecionado;

            tela.EstadoDeHabilitacao(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolBoxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaCondutor == null)
                _tabelaCondutor = new TabelaCondutorControl();

            Carregarcondutor();

            return _tabelaCondutor;
        }

        private void Carregarcondutor()
        {
            List<Condutor> condutores = _servicoCondutor.SelecionarTodos();

            _tabelaCondutor.AtualizarRegistros(condutores);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} {(condutores.Count == 1 ? "condutor" : "condutores")}", CorParaRodape.White);
        }
    }
}
