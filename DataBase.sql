USE [ApuestasM]
GO
/****** Object:  Table [dbo].[Apuesta]    Script Date: 12/01/2021 6:09:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apuesta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Apuesta] [varchar](50) NOT NULL,
	[ValorApuesta] [money] NOT NULL,
	[IdRuleta] [int] NOT NULL,
	[FechaApuesta] [datetime] NULL,
	[Activa] [bit] NULL,
 CONSTRAINT [PK_Apuesta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResultadoApuesta]    Script Date: 12/01/2021 6:09:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResultadoApuesta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRuleta] [int] NOT NULL,
	[IdApuestaGanadora] [int] NULL,
 CONSTRAINT [PK_ResultadoApuesta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ruleta]    Script Date: 12/01/2021 6:09:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruleta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Apuestas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioApostador]    Script Date: 12/01/2021 6:09:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioApostador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Credito] [money] NOT NULL,
 CONSTRAINT [PK_UsuarioApostador] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ruleta] ON 

INSERT [dbo].[Ruleta] ([Id], [Nombre], [Activo]) VALUES (1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Ruleta] OFF
SET IDENTITY_INSERT [dbo].[UsuarioApostador] ON 

INSERT [dbo].[UsuarioApostador] ([Id], [Nombre], [Credito]) VALUES (1, N'Juan', 1000000.0000)
INSERT [dbo].[UsuarioApostador] ([Id], [Nombre], [Credito]) VALUES (2, N'Pedro', 2000000.0000)
SET IDENTITY_INSERT [dbo].[UsuarioApostador] OFF
ALTER TABLE [dbo].[Apuesta]  WITH CHECK ADD  CONSTRAINT [FK_Apuesta_UsuarioApostador] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[UsuarioApostador] ([Id])
GO
ALTER TABLE [dbo].[Apuesta] CHECK CONSTRAINT [FK_Apuesta_UsuarioApostador]
GO
ALTER TABLE [dbo].[ResultadoApuesta]  WITH CHECK ADD  CONSTRAINT [FK_ResultadoApuesta_Apuesta] FOREIGN KEY([IdApuestaGanadora])
REFERENCES [dbo].[Apuesta] ([Id])
GO
ALTER TABLE [dbo].[ResultadoApuesta] CHECK CONSTRAINT [FK_ResultadoApuesta_Apuesta]
GO
ALTER TABLE [dbo].[ResultadoApuesta]  WITH CHECK ADD  CONSTRAINT [FK_ResultadoApuesta_Ruleta] FOREIGN KEY([IdRuleta])
REFERENCES [dbo].[Ruleta] ([Id])
GO
ALTER TABLE [dbo].[ResultadoApuesta] CHECK CONSTRAINT [FK_ResultadoApuesta_Ruleta]
GO
