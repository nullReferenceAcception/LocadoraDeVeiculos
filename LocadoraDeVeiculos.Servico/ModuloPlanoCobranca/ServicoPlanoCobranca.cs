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


        protected override ValidationResult HaDuplicidade(PlanoCobranca registro, ValidationResult resultadoValidacao)
        {
           base.HaDuplicidade(registro,resultadoValidacao);

            if (TiverDuplicidadePlano(registro))
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Plano já está cadastrado"));


            return resultadoValidacao;
        }

        private bool TiverDuplicidadePlano(PlanoCobranca registro)
        {
            return repositorioPlanoCobranca.VerificarDuplicidade(repositorioPlanoCobranca.SqlDuplicidadePlano(registro));
        }
    }
}
