using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.Tests.ModuloLocacao
{
    [TestClass]
    public class RepositorioLocacaoEmBancoDados : BaseTestRepositorio
    {

        [TestMethod]
        public void Deve_inserir_locacao()
        {
            Locacao locacao = CriarLocacao();

            _servicoLocacao.Inserir(locacao);

            PlanoCobranca locacaoEncontrado = _servicoPlanoCobranca.SelecionarPorGuid(locacao.Id).Value;

            Assert.AreEqual(locacao, locacaoEncontrado);
        }

    }
}


