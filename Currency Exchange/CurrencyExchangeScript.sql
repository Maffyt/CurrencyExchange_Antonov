USE [master]
GO
/****** Object:  Database [CurrencyExchange]    Script Date: 4/24/2023 11:44:22 PM ******/
CREATE DATABASE [CurrencyExchange]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CurrencyExchange', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\CurrencyExchange.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CurrencyExchange_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS02\MSSQL\DATA\CurrencyExchange_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CurrencyExchange] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CurrencyExchange].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CurrencyExchange] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CurrencyExchange] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CurrencyExchange] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CurrencyExchange] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CurrencyExchange] SET ARITHABORT OFF 
GO
ALTER DATABASE [CurrencyExchange] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CurrencyExchange] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CurrencyExchange] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CurrencyExchange] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CurrencyExchange] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CurrencyExchange] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CurrencyExchange] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CurrencyExchange] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CurrencyExchange] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CurrencyExchange] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CurrencyExchange] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CurrencyExchange] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CurrencyExchange] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CurrencyExchange] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CurrencyExchange] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CurrencyExchange] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CurrencyExchange] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CurrencyExchange] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CurrencyExchange] SET  MULTI_USER 
GO
ALTER DATABASE [CurrencyExchange] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CurrencyExchange] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CurrencyExchange] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CurrencyExchange] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CurrencyExchange] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CurrencyExchange] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CurrencyExchange] SET QUERY_STORE = OFF
GO
USE [CurrencyExchange]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 4/24/2023 11:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [nvarchar](8) NOT NULL,
	[Fullname] [nvarchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Passport] [nvarchar](20) NULL,
	[Email] [nvarchar](30) NULL,
	[NumberPhone] [nvarchar](12) NOT NULL,
	[Address] [nvarchar](30) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 4/24/2023 11:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](3) NOT NULL,
	[Quantity] [nvarchar](20) NULL,
	[PurchaseRate] [money] NULL,
	[SellingRate] [money] NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CurrencyExchange]    Script Date: 4/24/2023 11:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyExchange](
	[Number] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[ClientId] [int] NOT NULL,
	[CurrencyId (Sell)] [int] NOT NULL,
	[CurrencyId (Buy)] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[QuantitySold] [nvarchar](20) NOT NULL,
	[Sold] [money] NOT NULL,
	[QuantityBought] [nvarchar](20) NOT NULL,
	[Bought] [money] NOT NULL,
	[Cost] [money] NULL,
	[Revenue] [money] NULL,
 CONSTRAINT [PK_CurrencyExchange] PRIMARY KEY CLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/24/2023 11:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Passport] [nvarchar](20) NULL,
	[Post] [nvarchar](25) NULL,
	[NumberPhone] [nvarchar](12) NOT NULL,
	[Address] [nvarchar](30) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/24/2023 11:44:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[AdminStatus] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([Id], [AccountNumber], [Fullname], [DateOfBirth], [Passport], [Email], [NumberPhone], [Address]) VALUES (1, N'00003421', N'Geffer Scott', CAST(N'1993-02-08' AS Date), N'392341 43 22', N'gefscott@gmail.com', N'+79225112111', N'St. Croule, H. 34')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Currency] ON 

INSERT [dbo].[Currency] ([Id], [Name], [Quantity], [PurchaseRate], [SellingRate]) VALUES (1, N'USD', N'500', 28.4500, 25.5000)
INSERT [dbo].[Currency] ([Id], [Name], [Quantity], [PurchaseRate], [SellingRate]) VALUES (2, N'EUR', N'450', 48.6000, 45.5000)
INSERT [dbo].[Currency] ([Id], [Name], [Quantity], [PurchaseRate], [SellingRate]) VALUES (4, N'JPY', N'200', 0.5540, 0.5330)
INSERT [dbo].[Currency] ([Id], [Name], [Quantity], [PurchaseRate], [SellingRate]) VALUES (5, N'UAH', N'3443.22', 2.4000, 2.1000)
INSERT [dbo].[Currency] ([Id], [Name], [Quantity], [PurchaseRate], [SellingRate]) VALUES (6, N'CNY', N'6443.12', 11.8500, 11.2200)
SET IDENTITY_INSERT [dbo].[Currency] OFF
GO
SET IDENTITY_INSERT [dbo].[CurrencyExchange] ON 

INSERT [dbo].[CurrencyExchange] ([Number], [Date], [ClientId], [CurrencyId (Sell)], [CurrencyId (Buy)], [EmployeeId], [QuantitySold], [Sold], [QuantityBought], [Bought], [Cost], [Revenue]) VALUES (2, CAST(N'2023-04-11' AS Date), 1, 2, 2, 2, N'20', 400.0000, N'3', 340.0000, 200.0000, -443.0000)
SET IDENTITY_INSERT [dbo].[CurrencyExchange] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [FullName], [DateOfBirth], [Passport], [Post], [NumberPhone], [Address]) VALUES (1, N'Aiden Scott', CAST(N'1993-04-23' AS Date), N'755432 93 12', N'Admin', N'+79121321101', N'St. Ulker 12')
INSERT [dbo].[Employee] ([Id], [FullName], [DateOfBirth], [Passport], [Post], [NumberPhone], [Address]) VALUES (2, N'Linda Settler', CAST(N'1992-10-30' AS Date), N'543321 83 44', N'Cashier', N'+79124453122', NULL)
INSERT [dbo].[Employee] ([Id], [FullName], [DateOfBirth], [Passport], [Post], [NumberPhone], [Address]) VALUES (4, N'Андрей Викторович Байден', CAST(N'1993-03-15' AS Date), N'543852 21 22', N'Кассир', N'+79121019112', N'St. Fguxdvd')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [AdminStatus]) VALUES (1, N'AIden', N'1930rr', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [AdminStatus]) VALUES (2, N'Selest', N'5511', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[CurrencyExchange]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyExchange_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[CurrencyExchange] CHECK CONSTRAINT [FK_CurrencyExchange_Client]
GO
ALTER TABLE [dbo].[CurrencyExchange]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyExchange_Currency] FOREIGN KEY([CurrencyId (Sell)])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[CurrencyExchange] CHECK CONSTRAINT [FK_CurrencyExchange_Currency]
GO
ALTER TABLE [dbo].[CurrencyExchange]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyExchange_Currency1] FOREIGN KEY([CurrencyId (Buy)])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[CurrencyExchange] CHECK CONSTRAINT [FK_CurrencyExchange_Currency1]
GO
ALTER TABLE [dbo].[CurrencyExchange]  WITH CHECK ADD  CONSTRAINT [FK_CurrencyExchange_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[CurrencyExchange] CHECK CONSTRAINT [FK_CurrencyExchange_Employee]
GO
USE [master]
GO
ALTER DATABASE [CurrencyExchange] SET  READ_WRITE 
GO
