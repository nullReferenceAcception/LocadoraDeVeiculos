using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor, ValidadorCondutor>, IServicoCondutor
    {
        public ServicoCondutor(IRepositorioCondutor repositorio) : base(new ValidadorCondutor(), repositorio)
        {
            
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já cadastrado";
    }
}
