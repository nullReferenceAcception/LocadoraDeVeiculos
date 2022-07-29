﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.Logging.Log;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloLocacao;
using LocadoraDeVeiculos.Servico.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.ModuloTaxa;
using LocadoraDeVeiculos.Servico.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado
{
    public class BaseTestRepositorio
    {
        protected LocadoraDbContext DbContext;

        protected Random random = new();
        protected IServiceLocator locator;
        protected IServicoPlanoCobranca _servicoPlanoCobranca;
        protected IServicoVeiculo _servicoVeiculo;
        protected IServicoGrupoVeiculos _servicoGrupoVeiculos;
        protected IServicoCondutor _servicoCondutor;
        protected IServicoCliente _servicoCliente;
        protected IServicoFuncionario _servicoFuncionario;
        protected IServicoTaxa _servicoTaxa;
        protected IServicoLocacao _servicoLocacao;
        protected BaseTestRepositorio()
        {
           
            Log.Logger.ConfigurarLogEmWeb();



            locator = new ServiceLocatorComAutofac();
            _servicoPlanoCobranca = locator.GetServico<PlanoCobranca, ServicoPlanoCobranca, ValidadorPlanoCobranca>();
            _servicoVeiculo = locator.GetServico<Veiculo, ServicoVeiculo, ValidadorVeiculo>();
            _servicoGrupoVeiculos = locator.GetServico<GrupoVeiculos, ServicoGrupoVeiculos, ValidadorGrupoVeiculos>();
            _servicoCondutor = locator.GetServico<Condutor, ServicoCondutor, ValidadorCondutor>();
            _servicoCliente = locator.GetServico<Cliente, ServicoCliente, ValidadorCliente>();
            _servicoFuncionario = locator.GetServico<Funcionario, ServicoFuncionario, ValidadorFuncionario>();
            _servicoGrupoVeiculos = locator.GetServico<GrupoVeiculos, ServicoGrupoVeiculos, ValidadorGrupoVeiculos>();
            _servicoTaxa = locator.GetServico<Taxa, ServicoTaxa, ValidadorTaxa>();
            _servicoLocacao = locator.GetServico<Locacao, ServicoLocacao, ValidadorLocacao>();


            MigradorBancoDadosLocadora.AtualizarBancoDados();

            DbContext = new(Db.conexaoComBanco.ConnectionString);
            //colocar aqui sua tabela de acrodo com os exemplos

            Db.ExecutarSql("DELETE FROM TB_LOCACAO");
            Db.ExecutarSql("DELETE FROM TB_DEVOLUCAO");
            Db.ExecutarSql("DELETE FROM TB_PLANO_COBRANCA");
            Db.ExecutarSql("DELETE FROM TB_CONDUTOR");
            Db.ExecutarSql("DELETE FROM TB_CLIENTE");
            Db.ExecutarSql("DELETE FROM TB_TAXA");
            Db.ExecutarSql("DELETE FROM TB_VEICULO");
            Db.ExecutarSql("DELETE FROM TB_GRUPO_VEICULO");
            Db.ExecutarSql("DELETE FROM TB_FUNCIONARIO");
        }


        #region Metodos
        protected string GerarNovaStringAleatoria()
        {
            const int qtdeLetras = 10;

            const string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ";

            string stringAleatoria = "";
            Random random = new();

            for (int i = 0; i < qtdeLetras; i++)
                stringAleatoria += letras[random.Next(letras.Length)];

            return stringAleatoria;
        }

        protected Veiculo CriarVeiculo()
        {
            byte[] array = { 0, 100, 120, 210, 255 };

            Veiculo veiculo = new(GerarNovaStringAleatoria(), GerarNovaPlaca(), GerarNovaStringAleatoria(), 2005, 29.50m, 200000.00m, CorEnum.Azul, CombustivelEnum.Gasolina, array);
            veiculo.GrupoVeiculos = CriarGrupoVeiculos();
            _servicoGrupoVeiculos.Inserir(veiculo.GrupoVeiculos);
            return veiculo;
        }

        protected Cliente CriarClienteComCPF()
        {
            return new Cliente(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "12345678900", "joao@joao.com", "49989090909", true, GerarCpfAleatorio(), null!, DateTime.Today);
        }

        protected Cliente CriarClienteComCNPJ()
        {
            return new Cliente(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "12345678900", "joao@joao.com", "49989090909", false, null!, GerarCnpjAleatorio(), DateTime.Today);
        }

        protected string GerarCpfAleatorio()
        {
            return random.Next(1000, 9000).ToString() + random.Next(1000, 9000).ToString() + random.Next(100, 900).ToString();
        }

        protected string GerarCnpjAleatorio()
        {
            return random.Next(1000, 9000).ToString() + random.Next(1000, 9000).ToString() + random.Next(1000, 9000).ToString() + random.Next(10, 90).ToString();
        }
        
        protected Condutor CriarCondutor()
        {
            return new Condutor(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "12345678901", "guimotorista@gmail.com", "49998765432", "11111111111", DateTime.Today);
        }

        protected Funcionario CriarFuncionario()
        {
            return new(GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), "e@e.e", "49991113939", GerarNovaStringAleatoria(), GerarNovaStringAleatoria(), new DateTime(2020,02,02), 12, true, GerarNovaStringAleatoria(), true);
        }

        protected string GerarNovaPlaca()
        {
            const int qtdeLetras = 7;
            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string novaPlaca = "";
            Random random = new();

            for (int i = 0; i < qtdeLetras; i++)
                novaPlaca += letras[random.Next(letras.Length)];

            return novaPlaca;
        }

        protected GrupoVeiculos CriarGrupoVeiculos()
        {
            return new GrupoVeiculos(GerarNovaStringAleatoria());
        }

        protected PlanoCobranca CriarPlanoCobranca()
        {
            GrupoVeiculos grupoVeiculos = CriarGrupoVeiculos();
            _servicoGrupoVeiculos.Inserir(grupoVeiculos);
            return new PlanoCobranca(GerarNovaStringAleatoria(), random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), PlanoEnum.KmControlado, grupoVeiculos);
        }

        protected Locacao CriarLocacao()
        {
            List<Taxa> taxas = new List<Taxa> { CriarTaxa(), CriarTaxa() };
            foreach (var item in taxas)
            {
                _servicoTaxa.Inserir(item);
            }

            Locacao locacao = new Locacao(CriarFuncionario(),CriarClienteComCPF(),CriarCondutor(),CriarVeiculo(),CriarPlanoCobranca(),DateTime.Today,DateTime.Today.AddDays(8),taxas,StatusEnum.Ativo);
            locacao.Condutor.Cliente = locacao.Cliente;
            _servicoFuncionario.Inserir(locacao.Funcionario);
            _servicoCliente.Inserir(locacao.Cliente);
            _servicoCondutor.Inserir(locacao.Condutor);
            _servicoVeiculo.Inserir(locacao.Veiculo);
            _servicoPlanoCobranca.Inserir(locacao.PlanoCobranca);


           
            return locacao;
        }

        protected Taxa CriarTaxa()
        {
            return new Taxa(GerarNovaStringAleatoria(), (random.Next(0, 100) + (decimal)Math.Round(random.NextDouble(), 2)), true,true);
        }
        #endregion
    }
}
