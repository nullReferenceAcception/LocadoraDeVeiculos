using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private IServicoCondutor servicocondutor;
        private TabelaCondutorControl? _tabelacondutor;
        private IServicoCliente servicoCliente;

        public ControladorCondutor(IServicoCondutor ser, IServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
            servicocondutor = ser;
        }

        public override void Inserir()
        {
            if (servicoCliente.QuantidadeRegistro() == 0)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Cadastre no mínimo uma empresa para cadastrar um veículo",CorParaRodape.Yellow);
                return;
            }

            TelaCadastroCondutorForm tela = new(servicoCliente);

            tela.Condutor = new();


            tela.GravarRegistro = servicocondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                Carregarcondutor();
        }

        public override void Editar()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para editar",CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroCondutorForm(servicoCliente);

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicocondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                Carregarcondutor();
        }
  
        public override void Excluir()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
               "Exclusão de condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            ValidationResult validationResult;


            if (resultado == DialogResult.OK)
            {
                validationResult = servicocondutor.Excluir(condutorSelecionado);
                Carregarcondutor();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia!.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro",CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para visualizar",CorParaRodape.White);
                return;
            }

            var tela = new TelaCadastroCondutorForm(servicoCliente);

            tela.Condutor = condutorSelecionado;

            tela.EstadoDeAbilitacao(false);
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
            if (_tabelacondutor == null)
                _tabelacondutor = new TabelaCondutorControl();

            Carregarcondutor();

            return _tabelacondutor;
        }

        private void Carregarcondutor()
        {
            List<Condutor> condutors = servicocondutor.SelecionarTodos();

            _tabelacondutor!.AtualizarRegistros(condutors);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {condutors.Count} {(condutors.Count == 1 ? "condutor" : "condutores")}",CorParaRodape.White);
        }
    }
}
