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
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para editar");
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
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para excluir");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
               "Exclusão de condutor", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                Servicocondutor.Excluir(condutorSelecionado);
                Carregarcondutor();
            }
        }

        public override void Visualizar()
        {
            var numero = _tabelacondutor!.ObtemNumeroCondutorSelecionado();

            Condutor condutorSelecionado = Servicocondutor.SelecionarPorID(numero);

            if (condutorSelecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um condutor para visualizar");
                return;
            }

            var tela = new TelaCadastroCondutorForm(servicoCliente);

            tela.Condutor = condutorSelecionado;

            tela.Enable(false);
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

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {condutors.Count} {(condutors.Count == 1 ? "condutor" : "condutores")}");
        }
    }

}
