using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor, ValidadorCondutor>, IServicoCondutor
    {
        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contexto) : base(new ValidadorCondutor(), repositorioCondutor, contexto)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Nome já está cadastrado";
    }
}
