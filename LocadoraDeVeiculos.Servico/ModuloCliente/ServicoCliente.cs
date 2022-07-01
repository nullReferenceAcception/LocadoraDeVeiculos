using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloCliente
{
    public class ServicoCliente : ServicoBase<Cliente, ValidadorCliente>, IServicoCliente
    {
        public ServicoCliente(IRepositorioCliente repositorio) : base(new ValidadorCliente(), repositorio)
        {
        }

        public override string SqlMensagemDeErro => "Nome já está cadastrado";

    }
}
