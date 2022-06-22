CREATE TABLE [dbo].[tb_grupo_veiculo] (
    [id_grupo_veiculo] INT           IDENTITY (1, 1) NOT NULL,
    [nome]             VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_tb_grupo_veiculo] PRIMARY KEY CLUSTERED ([id_grupo_veiculo] ASC)
);

