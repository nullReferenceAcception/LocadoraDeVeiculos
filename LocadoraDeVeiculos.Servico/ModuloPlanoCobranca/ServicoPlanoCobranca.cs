using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca, ValidadorPlanoCobranca>, IServicoPlanoCobranca
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca) : base(new ValidadorPlanoCobranca(),repositorioPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";


        protected override bool HaDuplicidade(PlanoCobranca registro)
        {
            if (base.HaDuplicidade(registro))
                return true;

            if (TiverDuplicidadePlano(registro))
                return true;

            return false;
        }

        private bool TiverDuplicidadePlano(PlanoCobranca registro)
        {
            return repositorioPlanoCobranca.VerificarDuplicidade(repositorioPlanoCobranca.SqlDuplicidadePlano(registro));
        }
    }
}
