using FluentValidation;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Servico.Compartilhado;

namespace LocadoraDeVeiculos.Servico.ModuloDevolucao
{
    public class ServicoDevolucao : ServicoBase<Devolucao, ValidadorDevolucao>, IServicoDevolucao
    {
        public ServicoDevolucao(AbstractValidator<Devolucao> validationRules, IRepositorio<Devolucao> repositorio, IContextoPersistencia contexto) : base(validationRules, repositorio, contexto)
        {
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "zXy";
    }
}
