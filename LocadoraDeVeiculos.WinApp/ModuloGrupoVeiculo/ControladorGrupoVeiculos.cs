using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ControladorGrupoVeiculos : ControladorBase
    {
        private IServicoGrupoVeiculos servico;
        private TabelaGrupoVeiculoControl? tabela;

        public ControladorGrupoVeiculos(IServicoGrupoVeiculos rep)
        {
            servico = rep;
        }
        
        public override void Inserir()
        {
            TelaCadastroGrupoVeiculoForm tela = new();
            tela.GrupoVeiculos = new();

            tela.GravarRegistro = servico.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                carregarGrupoVeiculos();
        }

        public override void Editar()
        {
            var numero = tabela!.ObtemNumeroSelecionada();

            GrupoVeiculos Selecionada = servico.SelecionarPorID(numero);

            if (Selecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um grupo de veículos para editar");
                return;
            }

            var tela = new TelaCadastroGrupoVeiculoForm();

            tela.GrupoVeiculos = Selecionada;

            tela.GravarRegistro = servico.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                carregarGrupoVeiculos();
        }

        public override void Excluir()
        {
            var numero = tabela!.ObtemNumeroSelecionada();

            GrupoVeiculos Selecionada = servico.SelecionarPorID(numero);

            if (Selecionada == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um grupo de veículos para excluir");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Grupo de Veiculos?",
               "Exclusão de Grupo de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                servico.Excluir(Selecionada);
                carregarGrupoVeiculos();
            }
        }

        public override void Visualizar()
        {
            var numero = tabela!.ObtemNumeroSelecionada();

            GrupoVeiculos Selecionado = servico.SelecionarPorID(numero);

            if (Selecionado == null)
            {
                TelaPrincipalForm.Instancia!.AtualizarRodape($"Selecione um grupo de veículos para visualizar");
                return;
            }

            var tela = new TelaCadastroGrupoVeiculoForm();

            tela.GrupoVeiculos = Selecionado;

            tela.Enable(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolboxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (tabela == null)
                tabela = new TabelaGrupoVeiculoControl();

            carregarGrupoVeiculos();

            return tabela;
        }

        private void carregarGrupoVeiculos()
        {
            List<GrupoVeiculos> registros = servico.SelecionarTodos();

            tabela!.AtualizarRegistros(registros);

            TelaPrincipalForm.Instancia!.AtualizarRodape($"Visualizando {registros.Count} {(registros.Count == 1 ? "grupo de veículos" : "grupos de veículos")}");
        }
    }
}
