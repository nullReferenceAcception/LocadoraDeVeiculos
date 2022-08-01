using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using SautinSoft.Document;
using System;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using Locadora.Infra.Configs;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ControladorDevolucao : ControladorBase
    {
        private IServicoDevolucao _servicoDevolucao;
        private IServicoLocacao _servicoLocacao;
        private IServicoTaxa _servicoTaxa;
        private IServicoVeiculo _servicoVeiculo;
        private ConfiguracaoAplicacaoLocadora _configuracao;
        private TabelaDevolucaoControl _tabelaDevolucao;

        public ControladorDevolucao(IServicoDevolucao servicoDevolucao, IServicoLocacao servicoLocacao, IServicoTaxa servicoTaxa, IServicoVeiculo servicoVeiculo, ConfiguracaoAplicacaoLocadora configuracao)
        {
            _servicoDevolucao = servicoDevolucao;
            _servicoLocacao = servicoLocacao;
            _servicoTaxa = servicoTaxa;
            _servicoVeiculo = servicoVeiculo;
            this._configuracao = configuracao;
        }

        public override void Inserir()
        {
            if (_servicoLocacao.QuantidadeRegistro().Value == 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Cadastre no mínimo 1 'Locação' para registrar uma devolução", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroDevolucaoForm tela = new(_servicoDevolucao, _servicoLocacao, _servicoTaxa, _servicoVeiculo, _configuracao);

            tela.Devolucao = new();

            tela.GravarRegistro = _servicoDevolucao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDevolucoes();
        }

        public override void Editar()
        {
            var numero = _tabelaDevolucao.ObtemGuidDevolucaoSelecionada();

            var devolucaoSelecionada = _servicoDevolucao.SelecionarPorGuid(numero);

            if (devolucaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma devolução para editar", CorParaRodape.Yellow);
                return;
            }

            TelaCadastroDevolucaoForm tela = new(_servicoDevolucao, _servicoLocacao, _servicoTaxa, _servicoVeiculo, _configuracao);

            tela.Devolucao = devolucaoSelecionada.Value;

            tela.GravarRegistro = _servicoDevolucao.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarDevolucoes();
        }

        public override void Excluir()
        {
            var numero = _tabelaDevolucao.ObtemGuidDevolucaoSelecionada();

            Devolucao devolucaoSelecionada = _servicoDevolucao.SelecionarPorGuid(numero).Value;

            if (devolucaoSelecionada == null)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape($"Selecione uma devolução para excluir", CorParaRodape.Yellow);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a devolução?",
               "Exclusão de Devolução", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            Result validationResult;

            if (resultado == DialogResult.OK)
            {
                validationResult = _servicoDevolucao.Excluir(devolucaoSelecionada);
                CarregarDevolucoes();

                if (validationResult.Errors.Count > 0)
                    TelaPrincipalForm.Instancia.AtualizarRodape(validationResult.Errors[0].Message, CorParaRodape.Red);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigToolBoxDevolucao();
        }

        public override UserControl ObtemListagem()
        {
            if (_tabelaDevolucao == null)
                _tabelaDevolucao = new();

            CarregarDevolucoes();

            return _tabelaDevolucao;
        }

        private void CarregarDevolucoes()
        {
            List<Devolucao> devolucoes = _servicoDevolucao.SelecionarTodos().Value;

            _tabelaDevolucao.AtualizarRegistros(devolucoes);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} {(devolucoes.Count == 1 ? "devolução" : "devoluções")}", CorParaRodape.White);
        }

        public override void GerarPdf()
        {
            var numero = _tabelaDevolucao.ObtemGuidDevolucaoSelecionada();

            Devolucao devolucaoSelecionada = _servicoDevolucao.SelecionarPorGuid(numero).Value;

            if (devolucaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma devolução primeiro",
                "Geração de PDF de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DocumentCore dc = new();

            dc.Content.End.Insert("Informaçoes da devolução: " + devolucaoSelecionada.Locacao.Id.ToString() + "\n");
            dc.Content.End.Insert("Data da locação: " + devolucaoSelecionada.Locacao.DataLocacao.ToShortDateString() + "\n");
            dc.Content.End.Insert("------------------------------------------------- \n");
            dc.Content.End.Insert("Cliente: " + devolucaoSelecionada.Locacao.Cliente.Nome + "\n");

            if (devolucaoSelecionada.Locacao.Cliente.PessoaFisica == true)
            {
                dc.Content.End.Insert("CPF: " + devolucaoSelecionada.Locacao.Cliente.CPF + "\n");
                dc.Content.End.Insert("CNH: " + devolucaoSelecionada.Locacao.Cliente.CNH + "\n");
            }
            else
            {
                dc.Content.End.Insert("CNPJ: " + devolucaoSelecionada.Locacao.Cliente.CNPJ + "\n");
                dc.Content.End.Insert("Condutor: " + devolucaoSelecionada.Locacao.Condutor.Nome + "\n");
                dc.Content.End.Insert("CNH do condutor: " + devolucaoSelecionada.Locacao.Condutor.CNH + "\n");
            }

            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Veiculo: " + devolucaoSelecionada.Locacao.Veiculo.Modelo + "\n");
            dc.Content.End.Insert("Placa: " + devolucaoSelecionada.Locacao.Veiculo.Placa + "\n");
            dc.Content.End.Insert("Cor: " + devolucaoSelecionada.Locacao.Veiculo.Cor + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Plano de cobrança: " + devolucaoSelecionada.Locacao.PlanoCobranca.ToString() + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Taxas: \n");

            foreach (var taxa in devolucaoSelecionada.Locacao.Taxas)
                dc.Content.End.Insert(taxa.ToString() + "\n");

            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Funcionario responsável: " + devolucaoSelecionada.Locacao.Funcionario.Nome + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Data da devolucao: " + devolucaoSelecionada.DataDevolucaoReal + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Taxas adicionais:" + "\n");

            foreach(var taxarAdicionais in devolucaoSelecionada.TaxasAdicionais)
                dc.Content.End.Insert(taxarAdicionais.ToString() + "\n");

            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Tanque: " + devolucaoSelecionada.Tanque.ToString() + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");

            dc.Content.End.Insert("Valor total real: R$" + devolucaoSelecionada.ValorTotalReal);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Devolução - "
                + devolucaoSelecionada.Id.ToString() + ".pdf";

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
