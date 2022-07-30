using FluentValidation.Results;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca : ServicoBase<PlanoCobranca, ValidadorPlanoCobranca>, IServicoPlanoCobranca
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        public ServicoPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, IContextoPersistencia contexto, ConfiguracaoAplicacaoLocadora loc) : base(new ValidadorPlanoCobranca(),repositorioPlanoCobranca, contexto,loc)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Nome já está cadastrado";

        protected override bool HaDuplicidade(PlanoCobranca registro)
        {
            if (base.HaDuplicidade(registro))
                return true;

       else if (TiverDuplicidadePlano(registro))
            {
                MensagemDeErroSeTiverDuplicidade = "Plano já está cadastrado";
                return true;
            }

            return false;
        }

        private bool TiverDuplicidadePlano(PlanoCobranca registro)
        {
            return repositorioPlanoCobranca.VerificarDuplicidadePlano(registro);
        }
    }
}
