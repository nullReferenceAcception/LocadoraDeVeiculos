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

        protected override string sqlEditar
        {
            get => @"UPDATE
                        TB_VEICULO
                            SET
                                MODELO = @MODELO,
                                PLACA = @PLACA,
                                MARCA = @MARCA
                                ANO = @ANO
                                CAPACIDADE_TANQUE = @CAPACIDADE_TANQUE,
                                KM_PERCORRIDO = @KM_PERCORRIDO,
                                COR = @COR
                                COMBUSTIVEL = @COMBUSTIVEL,
                                FOTO = @FOTO,
                                GRUPO_DE_VEICULO_ID = @GRUPO_DE_VEICULO_ID
                            WHERE
                                VEICULO_ID = @ID";
        }

        protected override string sqlExcluir
        {
            get => @"DELETE FROM
                        TB_VEICULO
                    WHERE
                        ID_VEICULO = @ID";
        }

        protected override string sqlSelecionarTodos
        {
            get => @"SELECT
                        VEICULO.ID_VEICULO AS ID_VEICULO,
                        VEICULO.MODELO AS MODELO,
                        VEICULO.PLACA AS PLACA,
                        VEICULO.MARCA AS MARCA,
                        VEICULO.ANO AS ANO,
                        VEICULO.CAPACIDADE_TANQUE AS CAPACIDADE_TANQUE,
                        VEICULO.KM_PERCORRIDO AS KM_PERCORRIDO,
                        VEICULO.COR AS COR,
                        VEICULO.COMBUSTIVEL AS COMBUSTIVEL,
                        VEICULO.FOTO AS FOTO,
                        VEICULO.GRUPO_DE_VEICULO_ID AS GRUPO_DE_VEICULO_ID,

                        GRUPO_VEICULO.ID_GRUPO_VEICULO AS ID_GRUPO_VEICULO,
                        GRUPO_VEICULO.NOME_GRUPO_VEICULO AS NOME_GRUPO_VEICULO
                    FROM
                        TB_VEICULO AS VEICULO
                        INNER JOIN TB_GRUPO_VEICULO AS GRUPO_VEICULO
                        ON GRUPO_VEICULO.ID_GRUPO_VEICULO = VEICULO.GRUPO_DE_VEICULO_ID";
        }

        protected override string sqlSelecionarPorID
        {
            get => @"SELECT
                        VEICULO.ID_VEICULO AS ID_VEICULO,
                        VEICULO.MODELO AS MODELO,
                        VEICULO.PLACA AS PLACA,
                        VEICULO.MARCA AS MARCA,
                        VEICULO.ANO AS ANO,
                        VEICULO.CAPACIDADE_TANQUE AS CAPACIDADE_TANQUE,
                        VEICULO.KM_PERCORRIDO AS KM_PERCORRIDO,
                        VEICULO.COR AS COR,
                        VEICULO.COMBUSTIVEL AS COMBUSTIVEL,
                        VEICULO.FOTO AS FOTO,
                        VEICULO.GRUPO_DE_VEICULO_ID AS GRUPO_DE_VEICULO_ID,

                        GRUPO_VEICULO.ID_GRUPO_VEICULO AS ID_GRUPO_VEICULO,
                        GRUPO_VEICULO.NOME_GRUPO_VEICULO AS NOME_GRUPO_VEICULO
                    FROM
                        TB_VEICULO AS VEICULO
                        INNER JOIN TB_GRUPO_VEICULO AS GRUPO_VEICULO
                        ON GRUPO_VEICULO.ID_GRUPO_VEICULO = VEICULO.GRUPO_DE_VEICULO_ID
                    WHERE
                        VEICULO.ID_VEICULO = @ID";
        }

        #endregion

        public string SqlDuplicidadePlaca(Veiculo registro)
        {
            return "SELECT * FROM TB_VEICULO WHERE ([PLACA] = '" + registro.Placa + "')" + $"AND [ID_VEICULO] != {registro.Id}";
        }
    }
}
