using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using SautinSoft.Document;
using System;

namespace LocadoraDeVeiculos.Infra.PDF.sautinsoftDocument.Modulolocacao
{
    public class GeradorRelatorioLocacao : IGeradorRelatorioLocacao
    {
        public string GerarRelatorioPDF(Locacao locacaoSelecionada)
        {
            DocumentCore dc = new();

            dc.Content.End.Insert("Locação: " + locacaoSelecionada.Id.ToString() + "\n");
            dc.Content.End.Insert("Data da locação: " + locacaoSelecionada.DataLocacao + "\n");
            dc.Content.End.Insert("Data prevista da devolução: " + locacaoSelecionada.DataDevolucaoPrevista + "\n");
            dc.Content.End.Insert("------------------------------------------------- \n");
            dc.Content.End.Insert("Cliente: " + locacaoSelecionada.Cliente.Nome + "\n");

            if (locacaoSelecionada.Cliente.PessoaFisica == true)
            {
                dc.Content.End.Insert("CPF: " + locacaoSelecionada.Cliente.CPF + "\n");
            }
            else
            {
                dc.Content.End.Insert("CNPJ: " + locacaoSelecionada.Cliente.CNPJ + "\n");
            }

                dc.Content.End.Insert("-------------------------------------------------\n ");
                dc.Content.End.Insert("Condutor: " + locacaoSelecionada.Condutor.Nome + "\n");
                dc.Content.End.Insert("CNH do condutor: " + locacaoSelecionada.Condutor.CNH + "\n");
            

            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Veiculo: " + locacaoSelecionada.Veiculo.Modelo + "\n");
            dc.Content.End.Insert("Placa: " + locacaoSelecionada.Veiculo.Placa + "\n");
            dc.Content.End.Insert("Cor: " + locacaoSelecionada.Veiculo.Cor + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Plano de cobrança: " + locacaoSelecionada.PlanoCobranca.ToString() + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Taxas: \n");

            foreach (var taxa in locacaoSelecionada.Taxas)
                dc.Content.End.Insert(taxa.ToString() + "\n");

            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Funcionario responsável: " + locacaoSelecionada.Funcionario.Nome + "\n");

            dc.Content.End.Insert("Valor total previsto: R$" + locacaoSelecionada.ValorTotalPrevisto);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Locação"
                + locacaoSelecionada.Id.ToString() + ".pdf";

            dc.Save(path, new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A1a,
                PreserveFormFields = true
            });

            return path;
        }
    }
}
