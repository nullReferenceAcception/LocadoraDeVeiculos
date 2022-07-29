using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ControladorBase
    {
        private IServicoLocacao _servicoLocacao;
        private IServicoPlanoCobranca _planoCobranca;
        private IServicoCliente _servicoCliente;
        private IServicoVeiculo _servicoVeiculo;
        private IServicoFuncionario _servicoFuncionario;
        private IServicoGrupoVeiculos _servicoGrupoVeiculo;
        private IServicoCondutor _servicoCondutor;
        private IServicoTaxa _servicoTaxa;
        private TabelaLocacaoControl _tabelaLocacao;
        private bool estadoLocacao = true;


        public ControladorLocacao(IServicoLocacao servicoLocacao,IServicoPlanoCobranca planoCobranca, IServicoCliente servicoCliente, IServicoVeiculo servicoVeiculo, IServicoFuncionario servicoFuncionario, IServicoGrupoVeiculos servicoGrupoVeiculo, IServicoCondutor servicoCondutor, IServicoTaxa servicoTaxa)
        {
            _servicoLocacao = servicoLocacao;
            _planoCobranca = planoCobranca;
            _servicoCliente = servicoCliente;
            _servicoVeiculo = servicoVeiculo;
            _servicoFuncionario = servicoFuncionario;
            _servicoGrupoVeiculo = servicoGrupoVeiculo;
            _servicoCondutor = servicoCondutor;
            _servicoTaxa = servicoTaxa;
        }
        public override void Inserir()
        {

            if (_servicoGrupoVeiculo.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Grupo de Veículos' para cadastrar uma Locaçáo", CorParaRodape.Yellow);

                return;
            }

            if (_servicoCliente.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Cliente' para cadastrar uma Locaçáo", CorParaRodape.Yellow);

                return;
            }

            if (_servicoFuncionario.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Funcionario' para cadastrar uma Locaçáo", CorParaRodape.Yellow);

                return;
            }

            if (_servicoVeiculo.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Veiculo' para cadastrar uma Locaçáo", CorParaRodape.Yellow);

                return;
            }

            if (_planoCobranca.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Plano de cobranca' para cadastrar uma Locaçáo", CorParaRodape.Yellow);

                return;
            }

            if (_servicoCondutor.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Condutor' para cadastrar uma Locaçáo", CorParaRodape.Yellow);

                return;
            }


            TelaCadastroLocacaoForm tela = new(_planoCobranca,_servicoCliente, _servicoVeiculo, _servicoFuncionario, _servicoGrupoVeiculo, _servicoCondutor, _servicoTaxa);

            tela.Locacao = new();

            tela.GravarRegistro = _servicoLocacao.Inserir;

            tela.RemoverTaxas = _servicoLocacao.RemoverTaxas;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacaoAtivos();
        }
        public override void Editar()
        {
            var guid = _tabelaLocacao.ObtemGuidLocacaoSelecionado();

            Locacao locacaoSelecionada = _servicoLocacao.SelecionarPorGuid(guid).Value;

            if (locacaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma locacao para editar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroLocacaoForm(_planoCobranca, _servicoCliente, _servicoVeiculo, _servicoFuncionario, _servicoGrupoVeiculo, _servicoCondutor, _servicoTaxa);

            tela.Locacao = locacaoSelecionada;

            tela.GravarRegistro = _servicoLocacao.Editar;

            tela.RemoverTaxas = _servicoLocacao.RemoverTaxas;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarLocacaoAtivos();
        }

        public override void Excluir()
        {
            var guid = _tabelaLocacao.ObtemGuidLocacaoSelecionado();

            Locacao locacaoSelecionada = _servicoLocacao.SelecionarPorGuid(guid).Value;

            if (locacaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma locacao para Inativar", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente Inativar a Locacao?",
               "Inativar Locacao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoLocacao.Excluir(locacaoSelecionada);
                CarregarLocacaoAtivos();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape(validationResult.Errors[0].Message, CorParaRodape.Red);
            }
        }

        public override void Visualizar()
        {
            var guid = _tabelaLocacao.ObtemGuidLocacaoSelecionado();

            Locacao locacaoSelecionada = _servicoLocacao.SelecionarPorGuid(guid).Value;

            if (locacaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma locacao para visualizar", CorParaRodape.Yellow);
                return;
            }

            var tela = new TelaCadastroLocacaoForm(_planoCobranca, _servicoCliente, _servicoVeiculo, _servicoFuncionario, _servicoGrupoVeiculo, _servicoCondutor, _servicoTaxa);

            tela.Locacao = locacaoSelecionada;

            tela.Habilitar(false);
            tela.buttonCancelar.Enabled = true;
            tela.buttonCancelar.Text = "Voltar";
            tela.ShowDialog();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolBoxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaLocacao == null)
                _tabelaLocacao = new TabelaLocacaoControl();

            CarregarLocacaoAtivos();

            return _tabelaLocacao;
        }


        public override bool VisualizarDesativados()
        {
            if (estadoLocacao == false)
            {
                CarregarLocacaoAtivos();
                estadoLocacao = true;
            }
            else
            {
                CarregarLocacaoInativos();
                estadoLocacao = false;
            }

            return estadoLocacao;
        }

        private void CarregarLocacaoInativos()
        {
            List<Locacao> locacoesDesativados = _servicoLocacao.SelecionarDesativados().Value;

            _tabelaLocacao.AtualizarRegistros(locacoesDesativados);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoesDesativados.Count} {(locacoesDesativados.Count == 1 ? "locacao desativada" : "locacoes desativadas")}", CorParaRodape.White);
        }


        private void CarregarLocacaoAtivos()
        {
            List<Locacao> locacaos = _servicoLocacao.SelecionarTodos().Value;

            _tabelaLocacao.AtualizarRegistros(locacaos);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacaos.Count} {(locacaos.Count == 1 ? "locacao" : "locacoes")}", CorParaRodape.White);
        }

        public override void GerarPdf()
        {
            var guid = _tabelaLocacao.ObtemGuidLocacaoSelecionado();


            Locacao locacaoSelecionada = _servicoLocacao.SelecionarPorGuid(guid).Value;

            if (locacaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DocumentCore dc = new DocumentCore();

            dc.Content.End.Insert("Locação: " + locacaoSelecionada.Id.ToString() + "\n");
            dc.Content.End.Insert("Data da locação: " + locacaoSelecionada.DataLocacao + "\n");
            dc.Content.End.Insert("------------------------------------------------- \n");
            dc.Content.End.Insert("Cliente: " + locacaoSelecionada.Cliente.Nome + "\n");
            
            if(locacaoSelecionada.Cliente.PessoaFisica == true )
            {
                dc.Content.End.Insert("CPF: " + locacaoSelecionada.Cliente.CPF + "\n");
                dc.Content.End.Insert("CNH: " + locacaoSelecionada.Cliente.CNH + "\n");
            }
            else
            {
                dc.Content.End.Insert("CNPJ: " + locacaoSelecionada.Cliente.CNPJ + "\n");
                dc.Content.End.Insert("Condutor: " + locacaoSelecionada.Condutor.Nome + "\n");
                dc.Content.End.Insert("CNH do condutor: " + locacaoSelecionada.Condutor.CNH + "\n");
            }
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Veiculo: " + locacaoSelecionada.Veiculo.Modelo + "\n");
            dc.Content.End.Insert("Placa: " + locacaoSelecionada.Veiculo.Placa + "\n");
            dc.Content.End.Insert("Cor: " + locacaoSelecionada.Veiculo.Cor + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Plano de cobrança: " + locacaoSelecionada.PlanoCobranca.ToString() + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Taxas: \n");
            foreach(var taxa in locacaoSelecionada.Taxas)
            {
                dc.Content.End.Insert(taxa.ToString() + "\n");
            }
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Funcionario responsável: " + locacaoSelecionada.Funcionario.Nome + "\n");





            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Locação"
                + locacaoSelecionada.Id.ToString() + ".pdf";

            dc.Save(path, new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A1a,
                PreserveFormFields = true
            });



            if (MessageBox.Show("Salvo em documentos, deseja abrir o PDF?", "Devolução", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var p = new Process();
                p.StartInfo = new ProcessStartInfo(path)
                {
                    UseShellExecute = true
                };
                p.Start();
            }
            
        }

    }
}
