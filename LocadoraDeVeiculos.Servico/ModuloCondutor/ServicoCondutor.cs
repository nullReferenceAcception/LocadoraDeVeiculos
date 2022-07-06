using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor, ValidadorCondutor>, IServicoCondutor
    {
        public ServicoCondutor(IRepositorioCondutor repositorioCondutor) : base(new ValidadorCondutor(), repositorioCondutor)
        {
            
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Nome já cadastrado";
    }
}
