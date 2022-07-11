CREATE TABLE [dbo].[tb_grupo_veiculo] (
    [guid_grupo_veiculo] UNIQUEIDENTIFIER CONSTRAINT [DF_tb_grupo_veiculo_guid_grupo_veiculo] DEFAULT (newid()) NOT NULL,
    [nome]               VARCHAR (MAX)    NOT NULL,
    CONSTRAINT [PK_tb_grupo_veiculo_1] PRIMARY KEY CLUSTERED ([guid_grupo_veiculo] ASC)
);

