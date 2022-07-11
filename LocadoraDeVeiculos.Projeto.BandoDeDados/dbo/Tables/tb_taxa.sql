CREATE TABLE [dbo].[tb_taxa] (
    [guid_taxa] UNIQUEIDENTIFIER CONSTRAINT [DF_tb_taxa_guid_taxa] DEFAULT (newid()) NOT NULL,
    [descricao] VARCHAR (MAX)    NOT NULL,
    [valor]     DECIMAL (11, 2)  NOT NULL,
    [eh_diaria] BIT              NOT NULL,
    CONSTRAINT [PK_tb_taxa] PRIMARY KEY CLUSTERED ([guid_taxa] ASC)
);

