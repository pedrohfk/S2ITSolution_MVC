USE [ControleEmprestimos]
GO
/****** Object:  Table [dbo].[Amigo]    Script Date: 03/06/2018 23:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Amigo](
	[ID_Amigo] [int] IDENTITY(1,1) NOT NULL,
	[NM_Amigo] [varchar](80) NOT NULL,
 CONSTRAINT [XPKAmigo] PRIMARY KEY CLUSTERED 
(
	[ID_Amigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Amigo] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Emprestimo]    Script Date: 03/06/2018 23:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emprestimo](
	[ID_Emprestimo] [int] IDENTITY(1,1) NOT NULL,
	[ID_Jogo] [int] NULL,
	[ID_Amigo] [int] NULL,
	[DH_Emprestimo] [datetime] NOT NULL,
	[DH_Devolucao] [datetime] NULL,
 CONSTRAINT [XPKEmprestimo] PRIMARY KEY CLUSTERED 
(
	[ID_Emprestimo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER AUTHORIZATION ON [dbo].[Emprestimo] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[Jogo]    Script Date: 03/06/2018 23:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Jogo](
	[ID_Jogo] [int] IDENTITY(1,1) NOT NULL,
	[NM_Jogo] [varchar](80) NOT NULL,
 CONSTRAINT [XPKJogo] PRIMARY KEY CLUSTERED 
(
	[ID_Jogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER AUTHORIZATION ON [dbo].[Jogo] TO  SCHEMA OWNER 
GO
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [fk_Amigo_Emprestimo] FOREIGN KEY([ID_Amigo])
REFERENCES [dbo].[Amigo] ([ID_Amigo])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [fk_Amigo_Emprestimo]
GO
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [fk_Jogo_Emprestimo] FOREIGN KEY([ID_Jogo])
REFERENCES [dbo].[Jogo] ([ID_Jogo])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [fk_Jogo_Emprestimo]
GO
