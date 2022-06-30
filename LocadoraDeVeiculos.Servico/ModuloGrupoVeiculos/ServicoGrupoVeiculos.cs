using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos : ServicoBase<GrupoVeiculos, ValidadorGrupoVeiculos>, IServicoGrupoVeiculos
    {
        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorio) : base(new ValidadorGrupoVeiculos(), repositorio)
        {
        }

        public override ValidationResult HaDuplicidadeFilha(GrupoVeiculos registro, ValidationResult resultadoValidacao)
        {
            return HaDuplicidadeMae("Nome já está cadastrado", registro, resultadoValidacao);
        }
    }
}
