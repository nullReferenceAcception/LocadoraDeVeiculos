using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.PDF.ModuloDevolucao
{
    public class GeradorRelatorioDevolucao : IGeradorRelatorioDevolucaoPDF
    {
        public string GerarRelatorio(Devolucao devolucaoSelecionada)
        {
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

            foreach (var taxarAdicionais in devolucaoSelecionada.TaxasAdicionais)
                dc.Content.End.Insert(taxarAdicionais.ToString() + "\n");

            dc.Content.End.Insert("-------------------------------------------------\n ");
            dc.Content.End.Insert("Tanque: " + devolucaoSelecionada.Tanque.ToString() + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");

            dc.Content.End.Insert("KmRodado: " + devolucaoSelecionada.kMRodados + "\n");
            dc.Content.End.Insert("-------------------------------------------------\n ");

            dc.Content.End.Insert("Valor total real: R$" + devolucaoSelecionada.ValorTotalReal);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Devolução - "
                + devolucaoSelecionada.Id.ToString() + ".pdf";

            dc.Save(path, new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A1a,
                PreserveFormFields = true
            });

            return path;
        }
    }
}
