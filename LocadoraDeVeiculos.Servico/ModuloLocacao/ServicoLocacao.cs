using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloLocacao
{
    public class ServicoLocacao : ServicoBase<Locacao, ValidadorLocacao>, IServicoLocacao
    {
        IRepositorioLocacao repositorioLocacao;
        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContextoPersistencia contexto) : base(new ValidadorLocacao(), repositorioLocacao, contexto)
        {
            this.repositorioLocacao= repositorioLocacao;
        }
        
        public void RemoverTaxas(Locacao locacao,List<Taxa> taxas)
        {

            try
            {
                Log.Logger.Information("Removendo taxa de {locacao}", locacao);
                repositorioLocacao.RemoverTaxas(locacao, taxas);
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("erro ao remover taxa de ");

                Log.Logger.Error(ex, msgErro + "{locacao}", locacao);
            }

            
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Veiculo já está alocado";
    }
}
