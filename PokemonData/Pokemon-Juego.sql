USE [master]
GO
/****** Object:  Database [Pokemon-Juego]    Script Date: 2/11/2023 15:56:25 ******/
CREATE DATABASE [Pokemon-Juego]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pokemon-Juego', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Pokemon-Juego.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pokemon-Juego_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\Pokemon-Juego_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Pokemon-Juego] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pokemon-Juego].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pokemon-Juego] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pokemon-Juego] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pokemon-Juego] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Pokemon-Juego] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pokemon-Juego] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Pokemon-Juego] SET  MULTI_USER 
GO
ALTER DATABASE [Pokemon-Juego] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pokemon-Juego] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pokemon-Juego] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pokemon-Juego] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pokemon-Juego] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pokemon-Juego] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Pokemon-Juego] SET QUERY_STORE = ON
GO
ALTER DATABASE [Pokemon-Juego] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Pokemon-Juego]
GO
/****** Object:  Table [dbo].[Ataque]    Script Date: 2/11/2023 15:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ataque](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](20) NOT NULL,
	[IdPokemon] [int] NULL,
 CONSTRAINT [PK_Ataque] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pokemon]    Script Date: 2/11/2023 15:56:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pokemon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nchar](20) NULL,
	[Vida] [int] NULL,
	[Imagen] [ntext] NULL,
 CONSTRAINT [PK_Pokemon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ataque] ON 

INSERT [dbo].[Ataque] ([Id], [Nombre], [IdPokemon]) VALUES (1, N'modificar           ', 1)
INSERT [dbo].[Ataque] ([Id], [Nombre], [IdPokemon]) VALUES (2, N'Nuevo ataque        ', NULL)
INSERT [dbo].[Ataque] ([Id], [Nombre], [IdPokemon]) VALUES (4, N'Nuevo ataque2       ', NULL)
SET IDENTITY_INSERT [dbo].[Ataque] OFF
GO
SET IDENTITY_INSERT [dbo].[Pokemon] ON 

INSERT [dbo].[Pokemon] ([Id], [Nombre], [Vida], [Imagen]) VALUES (1, N'Pikachu             ', 100, N'https://www.pkparaiso.com/imagenes/espada_escudo/sprites/animados-gigante/pikachu.gif')
INSERT [dbo].[Pokemon] ([Id], [Nombre], [Vida], [Imagen]) VALUES (2, N'Bulbasaur           ', 100, N'https://www.pkparaiso.com/imagenes/espada_escudo/sprites/animados-gigante/bulbasaur.gif')
INSERT [dbo].[Pokemon] ([Id], [Nombre], [Vida], [Imagen]) VALUES (3, N'Charmander          ', 100, N'https://www.pkparaiso.com/imagenes/espada_escudo/sprites/animados-gigante/charmander-s.gif')
SET IDENTITY_INSERT [dbo].[Pokemon] OFF
GO
ALTER TABLE [dbo].[Pokemon] ADD  CONSTRAINT [DF_Pokemon_Vida]  DEFAULT ((100)) FOR [Vida]
GO
ALTER TABLE [dbo].[Ataque]  WITH CHECK ADD  CONSTRAINT [FK_Ataque_Pokemon] FOREIGN KEY([IdPokemon])
REFERENCES [dbo].[Pokemon] ([Id])
GO
ALTER TABLE [dbo].[Ataque] CHECK CONSTRAINT [FK_Ataque_Pokemon]
GO
USE [master]
GO
ALTER DATABASE [Pokemon-Juego] SET  READ_WRITE 
GO
