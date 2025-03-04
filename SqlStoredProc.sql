USE [master]
GO
/****** Object:  Database [CarsTest]    Script Date: 08/04/2024 10:29:53 ******/
CREATE DATABASE [CarsTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarsTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarsTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarsTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarsTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarsTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarsTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarsTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarsTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarsTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarsTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarsTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarsTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarsTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarsTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarsTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarsTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarsTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarsTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarsTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarsTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarsTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarsTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarsTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarsTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarsTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarsTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarsTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarsTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarsTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarsTest] SET  MULTI_USER 
GO
ALTER DATABASE [CarsTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarsTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarsTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarsTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarsTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarsTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CarsTest] SET QUERY_STORE = OFF
GO
USE [CarsTest]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 08/04/2024 10:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[CarNumber] [nvarchar](20) NULL,
	[Model] [nvarchar](50) NULL,
	[Color] [nvarchar](10) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 08/04/2024 10:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[FeedbackDate] [datetime2](7) NULL,
	[FeedbackType] [nvarchar](5) NULL,
	[Comment] [nvarchar](150) NULL,
 CONSTRAINT [PK_FeedBack] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackType]    Script Date: 08/04/2024 10:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackType](
	[Type] [nvarchar](5) NULL,
	[Description] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 08/04/2024 10:29:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[CompanyHp] [nvarchar](10) NULL,
	[Date] [datetime2](7) NULL,
	[Comment] [nvarchar](500) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CarsTest] SET  READ_WRITE 
GO
