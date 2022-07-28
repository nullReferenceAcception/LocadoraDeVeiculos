using FluentResults;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocadoraDeVeiculos.Servico.ModuloVeiculos
{
    public class ServicoVeiculo : ServicoBase<Veiculo, ValidadorVeiculo>, IServicoVeiculo
    {
        IRepositorioVeiculo _repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo, IContextoPersistencia contexto) : base(new ValidadorVeiculo(), repositorioVeiculo, contexto)
        {
            this._repositorioVeiculo = repositorioVeiculo;
        }

        Result<List<Veiculo>> IServicoVeiculo.SelecionarTodosDoGrupo(GrupoVeiculos grupo)
        {
            try
            {
                return Result.Ok(_repositorioVeiculo.SelecionarTodosDoGrupo(grupo));
            }
            catch (Exception ex)
            {
                StringBuilder msgErro = new StringBuilder("Falha no sistema ao tentar selecionar todos os  ");

                Log.Logger.Error(ex, msgErro + "{classe}", "Veiculo");

                return Result.Fail(msgErro.Append("Veiculo").ToString());
            }
        }

        protected override string MensagemDeErroSeTiverDuplicidade { get; set; } = "Placa já cadastrada";
    }
}
