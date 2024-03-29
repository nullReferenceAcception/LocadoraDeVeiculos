﻿using Autofac;
using FluentValidation;
using Locadora.Infra.Configs;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloCliente;
using LocadoraDeVeiculos.Infra.ORM.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ORM.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.ORM.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ORM.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.Infra.ORM.ModuloLocacao;
using LocadoraDeVeiculos.Infra.ORM.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.ORM.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ORM.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.PDF.sautinsoftDocument.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.PDF.sautinsoftDocument.Modulolocacao;
using LocadoraDeVeiculos.Servico.Compartilhado;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloDevolucao;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloLocacao;
using LocadoraDeVeiculos.Servico.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.ModuloTaxa;
using LocadoraDeVeiculos.Servico.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloConfiguracoes;
using LocadoraDeVeiculos.WinApp.ModuloDevolucao;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();


            builder.Register((x) => new ConfiguracaoAplicacaoLocadora().ConnectionStrings)
             .As<ConnectionStrings>()
             .SingleInstance(); //Singleton

            builder.RegisterType<ConfiguracaoAplicacaoLocadora>()
                .SingleInstance(); //Singleton

            builder.RegisterType<LocadoraDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope(); //Scoped



            builder.RegisterType<GeradorRelatorioDevolucao>().As<IGeradorRelatorioDevolucao>();
            builder.RegisterType<GeradorRelatorioLocacao>().As<IGeradorRelatorioLocacao>();



            builder.RegisterType<RepositorioClienteOrm>().As<IRepositorioCliente>();
            builder.RegisterType<RepositorioCondutorOrm>().As<IRepositorioCondutor>();
            builder.RegisterType<RepositorioFuncionarioOrm>().As<IRepositorioFuncionario>();
            builder.RegisterType<RepositorioGrupoVeiculoOrm>().As<IRepositorioGrupoVeiculos>();
            builder.RegisterType<RepositorioPlanoCobrancaOrm>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxa>();
            builder.RegisterType<RepositorioVeiculoOrm>().As<IRepositorioVeiculo>();
            builder.RegisterType<RepositorioLocacaoOrm>().As<IRepositorioLocacao>();
            builder.RegisterType<RepositorioDevolucaoOrm>().As<IRepositorioDevolucao>();

            builder.RegisterType<ServicoCliente>().As<IServicoCliente>().AsSelf();
            builder.RegisterType<ServicoCondutor>().As<IServicoCondutor>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().As<IServicoFuncionario>().AsSelf();
            builder.RegisterType<ServicoGrupoVeiculos>().As<IServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ServicoPlanoCobranca>().As<IServicoPlanoCobranca>().AsSelf();
            builder.RegisterType<ServicoTaxa>().As<IServicoTaxa>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().As<IServicoVeiculo>().AsSelf();
            builder.RegisterType<ServicoLocacao>().As<IServicoLocacao>().AsSelf();
            builder.RegisterType<ServicoDevolucao>().As<IServicoDevolucao>().AsSelf();

            builder.RegisterType<ControladorCliente>();
            builder.RegisterType<ControladorCondutor>();
            builder.RegisterType<ControladorFuncionario>();
            builder.RegisterType<ControladorGrupoVeiculos>();
            builder.RegisterType<ControladorPlanoCobranca>();
            builder.RegisterType<ControladorTaxa>();
            builder.RegisterType<ControladorVeiculo>();
            builder.RegisterType<ControladorLocacao>();
            builder.RegisterType<ControladorDevolucao>();
            builder.RegisterType<ControladorConfiguracao>();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }

        public Servico GetServico<Entidade,Servico,Tvalidador>() 
            where Servico : ServicoBase<Entidade, Tvalidador>
            where Entidade : EntidadeBase<Entidade>
            where Tvalidador : AbstractValidator<Entidade>
        {
            return container.Resolve<Servico>();
        }
    }
}
