using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using LocadoraDeVeiculos.Servico.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Servico.ModuloPlanoCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoEmBancoDados : BaseTestRepositorio
    {
        Random random = new();
        IServiceLocator locator;
        IServicoPlanoCobranca ServicoPlanoCobranca;

        public RepositorioLocacaoEmBancoDados()
        {
            locator = new ServiceLocatorComAutofac();
            ServicoPlanoCobranca = locator.GetServico<PlanoCobranca, ServicoPlanoCobranca, ValidadorPlanoCobranca>();
        }

        [TestMethod]
        public void Deve_inserir_locacao()
        {
            Locacao planoCobranca = CriarPlanoCobranca();

            _servicoPlanoCobranca.Inserir(planoCobranca);

            PlanoCobranca planoCobrancaEncontrado = _servicoPlanoCobranca.SelecionarPorGuid(planoCobranca.Id).Value;

            Assert.AreEqual(planoCobranca, planoCobrancaEncontrado);
        }



        #region Criações

        private PlanoCobranca CriarPlanoCobranca()
        {
            GrupoVeiculos grupoVeiculos = new GrupoVeiculos("grupo");
            locator.GetServico<PlanoCobranca,ServicoPlanoCobranca,ValidadorPlanoCobranca>().Inserir(grupoVeiculos);
            return new PlanoCobranca(GerarNovaStringAleatoria(), random.Next(1, 200), random.Next(1, 200), random.Next(1, 200), PlanoEnum.KmControlado, grupoVeiculos);
        }



        #endregion

    }
}


