using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using System.Collections.Generic;

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
            repositorioLocacao.RemoverTaxas(locacao,taxas);
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Veiculo já está alocado";
    }
}
