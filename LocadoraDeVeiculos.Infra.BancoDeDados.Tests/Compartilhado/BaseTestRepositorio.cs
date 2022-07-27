using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraDeVeiculos.Infra.ORM.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using System;

namespace LocadoraDeVeiculos.Infra.BancoDados.Tests.ModuloCompartilhado
{
    public class BaseTestRepositorio
    {
        protected LocadoraDbContext DbContext;

        Random random = new();
        protected IServicoVeiculo _servicoVeiculo;
        protected IServicoGrupoVeiculos _servicoGrupoVeiculo;
        protected IServicoCliente _servicoCliente;

        protected BaseTestRepositorio()
        {

            MigradorBancoDadosLocadora.AtualizarBancoDados();

            DbContext = new(Db.conexaoComBanco.ConnectionString);
            //colocar aqui sua tabela de acrodo com os exemplos

            Db.ExecutarSql("DELETE FROM TB_PLANO_COBRANCA");
            Db.ExecutarSql("DELETE FROM TB_CONDUTOR");
            Db.ExecutarSql("DELETE FROM TB_CLIENTE");
            Db.ExecutarSql("DELETE FROM TB_TAXA");
            Db.ExecutarSql("DELETE FROM TB_VEICULO");
            Db.ExecutarSql("DELETE FROM TB_GRUPO_VEICULO");
            Db.ExecutarSql("DELETE FROM TB_FUNCIONARIO");
        }

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

        protected Veiculo CriarVeiculoSemGrupo()
        {
            byte[] array = { 0, 100, 120, 210, 255 };
            return new("Uno", GerarNovaPlaca(), "Fiat", 2005, 29.50m, 200000.00m, CorEnum.Azul, CombustivelEnum.Gasolina, array);
        }

        protected string GerarNovaPlaca()
        {
            const int qtdeNumeros = 3;
            const int qtdeLetras = 4;

            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";
            string novaPlaca = "";
            Random random = new();

            for (int i = 0; i < qtdeNumeros; i++)
                novaPlaca += letras[random.Next(letras.Length)];

            for (int i = 0; i < qtdeLetras; i++)
                novaPlaca += numeros[random.Next(numeros.Length)];

            return novaPlaca;
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
    }
}
