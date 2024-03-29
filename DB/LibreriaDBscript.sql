USE [Libreria]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 9/10/2023 9:44:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](500) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[CiudadProcedencia] [nvarchar](250) NOT NULL,
	[CorreoElectronico] [nvarchar](250) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Autor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 9/10/2023 9:44:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 9/10/2023 9:44:04 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](250) NOT NULL,
	[Año] [int] NOT NULL,
	[IdGenero] [int] NOT NULL,
	[NumeroPaginas] [int] NOT NULL,
	[IdAutor] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Autor] ON 

INSERT [dbo].[Autor] ([Id], [NombreCompleto], [FechaNacimiento], [CiudadProcedencia], [CorreoElectronico], [FechaCreacion]) VALUES (5, N'Mario Mendoza', CAST(N'1980-01-01' AS Date), N'Bogotá', N'mario@correo.com', CAST(N'2023-10-08T19:16:20.110' AS DateTime))
INSERT [dbo].[Autor] ([Id], [NombreCompleto], [FechaNacimiento], [CiudadProcedencia], [CorreoElectronico], [FechaCreacion]) VALUES (6, N'andres hernandez', CAST(N'2023-10-09' AS Date), N'cali', N'aroh89@gmail.com', CAST(N'2023-10-08T20:02:56.983' AS DateTime))
SET IDENTITY_INSERT [dbo].[Autor] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([Id], [Nombre], [FechaCreacion]) VALUES (2, N'Drama', CAST(N'2023-10-08T20:32:38.567' AS DateTime))
INSERT [dbo].[Genero] ([Id], [Nombre], [FechaCreacion]) VALUES (3, N'terror', CAST(N'2023-10-08T21:10:12.060' AS DateTime))
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Libros] ON 

INSERT [dbo].[Libros] ([Id], [Titulo], [Año], [IdGenero], [NumeroPaginas], [IdAutor], [FechaCreacion]) VALUES (2, N'Satanas', 2014, 2, 500, 5, CAST(N'2023-10-08T20:34:52.930' AS DateTime))
INSERT [dbo].[Libros] ([Id], [Titulo], [Año], [IdGenero], [NumeroPaginas], [IdAutor], [FechaCreacion]) VALUES (3, N'Titulo 2', 1988, 2, 250, 6, CAST(N'2023-10-08T21:02:57.603' AS DateTime))
INSERT [dbo].[Libros] ([Id], [Titulo], [Año], [IdGenero], [NumeroPaginas], [IdAutor], [FechaCreacion]) VALUES (4, N'Titulo 3', 1850, 3, 2500, 6, CAST(N'2023-10-08T21:11:00.870' AS DateTime))
INSERT [dbo].[Libros] ([Id], [Titulo], [Año], [IdGenero], [NumeroPaginas], [IdAutor], [FechaCreacion]) VALUES (5, N'Titulo 4', 1865, 2, 2000, 5, CAST(N'2023-10-08T22:46:52.723' AS DateTime))
SET IDENTITY_INSERT [dbo].[Libros] OFF
GO
ALTER TABLE [dbo].[Autor] ADD  CONSTRAINT [DF_Autor_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Genero] ADD  CONSTRAINT [DF_Genero_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Libros] ADD  CONSTRAINT [DF_Libros_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Autor] FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Autor]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Genero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Genero]
GO
