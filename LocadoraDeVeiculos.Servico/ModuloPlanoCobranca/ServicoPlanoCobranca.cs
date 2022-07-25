using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca, ValidadorPlanoCobranca>, IServicoPlanoCobranca
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IContextoPersistencia contexto) : base(new ValidadorPlanoCobranca(),repositorioPlanoCobranca, contexto)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        protected override string MensagemDeErroSeTiverDuplicidade => "Nome já está cadastrado";


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
            return repositorioPlanoCobranca.VerificarDuplicidade(registro);
        }
    }
}
