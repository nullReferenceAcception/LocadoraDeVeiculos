using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloTaxa
{
    public class ServicoTaxa : ServicoBase<Taxa, ValidadorTaxa>, IServicoTaxa
    {
        public ServicoTaxa(IRepositorioTaxa repositorio) : base(new ValidadorTaxa(), repositorio)
        {
        }

        public override ValidationResult HaDuplicidadeFilha(Taxa registro, ValidationResult resultadoValidacao)
        {
            return HaDuplicidadeMae("Descricao já está cadastrado", registro, resultadoValidacao);
        }
    }
}
