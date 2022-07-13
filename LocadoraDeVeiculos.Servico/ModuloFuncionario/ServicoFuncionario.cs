using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.Compartilhado;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Servico.ModuloFuncionario
{
    public class ServicoFuncionario : ServicoBase<Funcionario, ValidadorFuncionario>, IServicoFuncionario
    {
        IRepositorioFuncionario _repositorioFuncionario;
        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario) : base(new ValidadorFuncionario(), repositorioFuncionario)
        {
            this._repositorioFuncionario = repositorioFuncionario;
        }

        public Result<List<Funcionario>> SelecionarDesativados()
        {
            try
            {
                return Result.Ok(_repositorioFuncionario.SelecionarDesativados());
            }
            catch (Exception ex)
            {
                string msgErro = $"Falha no sistema ao tentar selecionar todos os funcionarios desativados";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        protected override string SqlMensagemDeErroSeTiverDuplicidade => "Login já está cadastrado";
    }
}
