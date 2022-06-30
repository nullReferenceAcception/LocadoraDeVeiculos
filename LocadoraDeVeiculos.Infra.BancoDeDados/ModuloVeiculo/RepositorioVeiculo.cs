using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.BancoDeDados.ModuloVeiculo
{
    public class RepositorioVeiculo : RepositorioBaseEmBancoDeDados<Veiculo, ValidadorVeiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo() : base(new MapeadorVeiculo())
        {
        }

        #region SQL Queries
        protected override string sqlInserir
        {
            get => @"INSERT INTO
                        TB_VEICULO
                            (
                            MODELO,
                            PLACA,
                            MARCA,
                            ANO,
                            CAPACIDADE_TANQUE,
                            KM_PERCORRIDO,
                            COR,
                            COMBUSTIVEL,
                            FOTO,
                            GRUPO_DE_VEICULO_ID
                            )
                        VALUES
                            (
                            @MODELO,
                            @PLACA,
                            @MARCA,
                            @ANO,
                            @CAPACIDADE_TANQUE,
                            @KM_PERCORRIDO,
                            @COR,
                            @COMBUSTIVEL,
                            @FOTO,
                            @GRUPO_DE_VEICULO_ID
                            ); SELECT SCOPE_IDENTITY();";
        }

        protected override string sqlEditar => throw new System.NotImplementedException();

        protected override string sqlExcluir => throw new System.NotImplementedException();

        protected override string sqlSelecionarTodos => throw new System.NotImplementedException();

        protected override string sqlSelecionarPorID => throw new System.NotImplementedException();

        #endregion
        public string SqlDuplicidadePlaca(Veiculo registro)
        {
            return "SELECT * FROM TB_VEICULO WHERE ([PLACA] = '" + registro.Placa + "')" + $"AND [ID_VEICULO] != {registro.Id}";
        }
    }
}
