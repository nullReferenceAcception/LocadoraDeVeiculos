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
        protected override string SqlMensagemDeErroDeDuplicidade => "Nome já está cadastrado";
    }
}
