using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private IServicoCondutor Servicocondutor;
        private TabelaCondutorControl? _tabelacondutor;
        private IServicoCliente servicoCliente;

        public ControladorCondutor(IServicoCondutor ser, IServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
            Servicocondutor = ser;
        }



        public override void Inserir()
        {


            if (servicoCliente.QuantidadeRegistro() == 0)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Cadastre no mínimo uma empresa para cadastrar um veículo",TelaPrincipalForm.Cor.Yellow);
                return;
            }

            TelaCadastroCondutorForm tela = new(servicoCliente);

            tela.Condutor = new();


            tela.GravarRegistro = Servicocondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                Carregarcondutor();
        }
        public override void Editar()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = Servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para editar",TelaPrincipalForm.Cor.Yellow);
                return;
            }

            var tela = new TelaCadastroCondutorForm(servicoCliente);

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = Servicocondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                Carregarcondutor();
        }
  
        public override void Excluir()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = Servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para excluir", TelaPrincipalForm.Cor.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
               "Exclusão de condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            ValidationResult validationResult;


            if (resultado == DialogResult.OK)
            {
                validationResult = Servicocondutor.Excluir(condutorSelecionado);
                Carregarcondutor();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia!.AtualizarRodape($"Esse registro esta sendo usado por outro cadastro deletar aquele primeiro",TelaPrincipalForm.Cor.Red);
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = Servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para visualizar",TelaPrincipalForm.Cor.White);
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
            List<Condutor> condutors = Servicocondutor.SelecionarTodos();

            _tabelacondutor!.AtualizarRegistros(condutors);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {condutors.Count} {(condutors.Count == 1 ? "condutor" : "condutores")}",TelaPrincipalForm.Cor.White);
        }
    }

}
