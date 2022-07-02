using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca, ValidadorPlanoCobranca>, IServicoPlanoCobranca
    {
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorio) : base(new ValidadorPlanoCobranca(),repositorio)
        {

        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";
    }
}
