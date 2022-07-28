using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos
{
    public class ServicoGrupoVeiculos : ServicoBase<GrupoVeiculos, ValidadorGrupoVeiculos>, IServicoGrupoVeiculos
    {
        IRepositorioGrupoVeiculos repositorioGrupoVeiculos;
        public ServicoGrupoVeiculos(IRepositorioGrupoVeiculos repositorioGrupoVeiculos, IContextoPersistencia contexto) : base(new ValidadorGrupoVeiculos(), repositorioGrupoVeiculos, contexto)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Nome já está cadastrado";

        public Result<GrupoVeiculos> SelecionarGrupoDoPlano(PlanoCobranca p)
        {
            try
            {
                return Result.Ok(repositorioGrupoVeiculos.SelecionarGrupoDoPlano(p));
            }
            catch (Exception ex)
            {

                StringBuilder msgErro = new StringBuilder("Selecionado o ");

                Log.Logger.Error(ex, msgErro + "{classe}", "GrupoVeiculos");

                return Result.Fail(msgErro.Append("GrupoVeiculos").ToString());
            }
        }
    }
}
