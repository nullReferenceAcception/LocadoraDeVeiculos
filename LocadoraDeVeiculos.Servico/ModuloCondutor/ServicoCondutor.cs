using FluentResults;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloCondutor
{
    public class ServicoCondutor : ServicoBase<Condutor, ValidadorCondutor>, IServicoCondutor
    {
        IRepositorioCondutor repositorioCondutor;
        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contexto, ConfiguracaoAplicacaoLocadora loc) : base(new ValidadorCondutor(), repositorioCondutor, contexto,loc)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Nome já está cadastrado";


        Result<List<Condutor>> IServicoCondutor.SelecionarTodosDoCliente(Cliente cliente)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodosDoCliente(cliente));
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar selecionar todos os  ");

                Log.Logger.Error(ex, msgErro + "{classe}", "Condutor");

                return Result.Fail(msgErro.Append("Condutor").ToString());
            }
        }
    }
}
