using Autofac;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCliente;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloTaxa;
using LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.ModuloTaxa;
using LocadoraDeVeiculos.Servico.Compartilhado;
using LocadoraDeVeiculos.Servico.ModuloCliente;
using LocadoraDeVeiculos.Servico.ModuloCondutor;
using LocadoraDeVeiculos.Servico.ModuloFuncionario;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Servico.ModuloTaxa;
using LocadoraDeVeiculos.Servico.ModuloVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraDeVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using System.Configuration;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();



            builder.RegisterInstance(new LocadoraDbContext(Db.conexaoComBanco.ConnectionString)).As<IContextoPersistencia>().AsSelf();


            builder.RegisterType<RepositorioCliente>().As<IRepositorioCliente>();
            builder.RegisterType<RepositorioCondutor>().As<IRepositorioCondutor>();
            builder.RegisterType<RepositorioFuncionario>().As<IRepositorioFuncionario>();
            builder.RegisterType<RepositorioGrupoVeiculos>().As<IRepositorioGrupoVeiculos>();
            builder.RegisterType<RepositorioPlanoCobranca>().As<IRepositorioPlanoCobranca>();
            builder.RegisterType<RepositorioTaxaOrm>().As<IRepositorioTaxa>();

            builder.RegisterType<ServicoCliente>().As<IServicoCliente>();
            builder.RegisterType<ServicoCondutor>().As<IServicoCondutor>();
            builder.RegisterType<ServicoFuncionario>().As<IServicoFuncionario>();
            builder.RegisterType<ServicoGrupoVeiculos>().As<IServicoGrupoVeiculos>();
            builder.RegisterType<ServicoPlanoCobranca>().As<IServicoPlanoCobranca>();
            builder.RegisterType<ServicoTaxa>().As<IServicoTaxa>();
            builder.RegisterType<ServicoVeiculo>().As<IServicoVeiculo>();

            builder.RegisterType<ControladorCliente>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorPlanoCobranca>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}
