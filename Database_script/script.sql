USE [master]
GO
/****** Object:  Database [Inventario-final]    Script Date: 2/1/2024 6:30:16 PM ******/
CREATE DATABASE [Inventario-final]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventario-final', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Inventario-final.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventario-final_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Inventario-final_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Inventario-final] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventario-final].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventario-final] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventario-final] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventario-final] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventario-final] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventario-final] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventario-final] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Inventario-final] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventario-final] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventario-final] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventario-final] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventario-final] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventario-final] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventario-final] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventario-final] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventario-final] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Inventario-final] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventario-final] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventario-final] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventario-final] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventario-final] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventario-final] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventario-final] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventario-final] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Inventario-final] SET  MULTI_USER 
GO
ALTER DATABASE [Inventario-final] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventario-final] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventario-final] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventario-final] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventario-final] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Inventario-final] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Inventario-final] SET QUERY_STORE = OFF
GO
USE [Inventario-final]
GO
/****** Object:  Table [dbo].[bodega]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bodega](
	[id_bodega] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[hora_de_apertura] [time](7) NOT NULL,
	[hora_de_cierre] [time](7) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_bodega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[primer_nombre] [varchar](20) NOT NULL,
	[segundo_nombre] [varchar](20) NULL,
	[primer_apellido] [varchar](20) NOT NULL,
	[segundo_apellido] [varchar](20) NOT NULL,
	[correo] [varchar](30) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[contrasena_encriptada] [varchar](100) NOT NULL,
	[salt] [binary](16) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[compra]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[id_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[valor_total] [decimal](30, 2) NOT NULL,
	[hora_de_compra] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_compra]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_compra](
	[id_detalle_compra] [int] IDENTITY(1,1) NOT NULL,
	[id_producto] [int] NULL,
	[cantidad] [int] NOT NULL,
	[total_detalle] [decimal](30, 2) NOT NULL,
	[id_compra] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[disponibilidad]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[disponibilidad](
	[id_producto] [int] NOT NULL,
	[id_bodega] [int] NOT NULL,
	[unidad] [varchar](10) NOT NULL,
	[unidades_disponibles] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[descripcion] [text] NOT NULL,
	[id_categoria] [int] NULL,
	[unidad] [varchar](10) NOT NULL,
	[precio_unitario] [decimal](10, 2) NOT NULL,
	[id_proveedor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 2/1/2024 6:30:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id_proveedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre_proveedor] [varchar](20) NOT NULL,
	[nombre_empresa] [varchar](20) NOT NULL,
	[email] [varchar](20) NOT NULL,
	[ciudad] [varchar](20) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[detalle_compra]  WITH CHECK ADD FOREIGN KEY([id_compra])
REFERENCES [dbo].[compra] ([id_compra])
GO
ALTER TABLE [dbo].[detalle_compra]  WITH CHECK ADD FOREIGN KEY([id_compra])
REFERENCES [dbo].[compra] ([id_compra])
GO
ALTER TABLE [dbo].[detalle_compra]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[detalle_compra]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[disponibilidad]  WITH CHECK ADD FOREIGN KEY([id_bodega])
REFERENCES [dbo].[bodega] ([id_bodega])
GO
ALTER TABLE [dbo].[disponibilidad]  WITH CHECK ADD FOREIGN KEY([id_bodega])
REFERENCES [dbo].[bodega] ([id_bodega])
GO
ALTER TABLE [dbo].[disponibilidad]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[disponibilidad]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[producto] ([id_producto])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_categoria])
REFERENCES [dbo].[categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_categoria])
REFERENCES [dbo].[categoria] ([id_categoria])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id_proveedor])
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD FOREIGN KEY([id_proveedor])
REFERENCES [dbo].[proveedor] ([id_proveedor])
GO
USE [master]
GO
ALTER DATABASE [Inventario-final] SET  READ_WRITE 
GO
