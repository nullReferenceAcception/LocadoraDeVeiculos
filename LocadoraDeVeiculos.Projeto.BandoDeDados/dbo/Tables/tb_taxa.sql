CREATE TABLE [dbo].[tb_taxa] (
    [id_taxa]   INT             IDENTITY (1, 1) NOT NULL,
    [descricao] VARCHAR (MAX)   NOT NULL,
    [valor]     DECIMAL (11, 2) NOT NULL,
    CONSTRAINT [PK__tb_taxa__C1D310DC6BA29561] PRIMARY KEY CLUSTERED ([id_taxa] ASC)
);

