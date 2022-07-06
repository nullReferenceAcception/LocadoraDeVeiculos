using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca, ValidadorPlanoCobranca>, IServicoPlanoCobranca
    {
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca) : base(new ValidadorPlanoCobranca(),repositorioPlanoCobranca)
        {
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";
    }
}
