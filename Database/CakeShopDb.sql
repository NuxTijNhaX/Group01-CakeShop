USE [master]
GO
/****** Object:  Database [CakeShopDb]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE DATABASE [CakeShopDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CakeShopDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CakeShopDb.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CakeShopDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CakeShopDb_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CakeShopDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CakeShopDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CakeShopDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CakeShopDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CakeShopDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CakeShopDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CakeShopDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CakeShopDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CakeShopDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CakeShopDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CakeShopDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CakeShopDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CakeShopDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CakeShopDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CakeShopDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CakeShopDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CakeShopDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CakeShopDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CakeShopDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CakeShopDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CakeShopDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CakeShopDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CakeShopDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CakeShopDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CakeShopDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CakeShopDb] SET  MULTI_USER 
GO
ALTER DATABASE [CakeShopDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CakeShopDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CakeShopDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CakeShopDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CakeShopDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CakeShopDb]
GO
/****** Object:  Schema [Person]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE SCHEMA [Person]
GO
/****** Object:  Schema [Production]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE SCHEMA [Production]
GO
/****** Object:  Schema [Sales]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE SCHEMA [Sales]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Person].[Users]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[BirthDay] [datetime2](7) NULL,
	[Email] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Production].[ProductCategories]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Production].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Production].[Products]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Production].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [float] NOT NULL,
	[ProductCategoryId] [int] NOT NULL,
	[AvgRating] [float] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Photos] [nvarchar](max) NOT NULL,
	[DateRealease] [datetime2](7) NOT NULL,
	[NumberOfPurchases] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Production].[Sizes]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Production].[Sizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sales].[Invoices]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime2](7) NOT NULL,
	[OrderGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sales].[OrderLines]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[OrderLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sales].[Orders]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[Orders](
	[guidOrder] [uniqueidentifier] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
	[TotalCost] [float] NOT NULL,
	[PaymentMethodId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[guidOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Sales].[PaymentMethods]    Script Date: 5/25/2022 1:43:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sales].[PaymentMethods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517082207_DbInit', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517083340_v0.0.1', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517085638_v0.0.2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517152723_v0.0.3', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517160525_v0.0.4', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517160657_v0.0.5', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517161047_v0.0.6', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220517161401_v0.0.7', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220518060514_v0.0.8', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220519170519_v0.0.9', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520165740_v1.0.0', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220521073425_v1.1.0', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220521074213_v1.1.1', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220522171433_delete-customer-contact-table', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220523023033_update-user-table', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220523095158_refactor-order-table', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524085238_change-orderlines-table', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220524085740_change-invoice-fk', N'5.0.17')
GO
SET IDENTITY_INSERT [Person].[Users] ON 

INSERT [Person].[Users] ([Id], [Password], [Address], [BirthDay], [Email], [IsAdmin], [Name], [PhoneNumber]) VALUES (1, N'admin', N'P. Bình Hưng Hòa A, Q. Bình Tân, TP. Hồ Chí Minh', NULL, N'nhanguyen7901@gmail.com', 1, N'Nguyễn Thiện Nhã', N'0394070901')
SET IDENTITY_INSERT [Person].[Users] OFF
GO
SET IDENTITY_INSERT [Production].[ProductCategories] ON 

INSERT [Production].[ProductCategories] ([Id], [Name]) VALUES (1, N'Birthday Cake')
INSERT [Production].[ProductCategories] ([Id], [Name]) VALUES (2, N'Mousse Cake')
INSERT [Production].[ProductCategories] ([Id], [Name]) VALUES (3, N'Kids Cake')
SET IDENTITY_INSERT [Production].[ProductCategories] OFF
GO
SET IDENTITY_INSERT [Production].[Products] ON 

INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (1, N'Forever Love Cake', 380000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/khong_co_tieu_de__1080___1080_px___300___60_px___1080___1080_px__54feb474eabd4397b62cd86f517d712f_master.png', CAST(N'2022-05-02T00:00:00.0000000' AS DateTime2), 150)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (2, N'Uniform Cake', 800000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'http://ec2-54-179-116-76.ap-southeast-1.compute.amazonaws.com/images/product-1.jpg', CAST(N'2022-05-22T00:00:00.0000000' AS DateTime2), 100)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (3, N'Chocolate Cake Rectangle', 300000, 1, 2.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'http://ec2-54-179-116-76.ap-southeast-1.compute.amazonaws.com/images/product-2.jpg', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), 25)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (4, N'Naked Wedding Cake', 950000, 1, 3.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'http://ec2-54-179-116-76.ap-southeast-1.compute.amazonaws.com/images/product-3.jpg', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), 50)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (5, N'Mango Cake', 250000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'http://ec2-54-179-116-76.ap-southeast-1.compute.amazonaws.com/images/product-4.jpg', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), 500)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (6, N'Rossie Love Cake', 350000, 1, 4, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/khong_co_tieu_de__1080___1080_px___300___60_px___1080___1080_px___1__bc5488e8f75d4803acb3e664d238a29a_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 200)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (7, N'Endless Love Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__2__1a347d5dcec84651904d29b9a1bb9146_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 250)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (8, N'Sweet Love Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/khong_co_tieu_de__1080___1080_px___300___60_px___1080___1080_px___5__03abed4a43be4e0f96ab5bd11a338cd2_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 300)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (9, N'Sweet Cream Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/banh-kem-sweet-cream_b81f1298bd3d4c698360be3c70bbaf5e_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 250)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (10, N'Flower Cake Cake', 300000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/banh-kem-flower-cake_0e0692b01e594c589e06db1893bd25cf_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 100)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (11, N'Chocolate Love Cake', 280000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__9__728bf616bf4344f59622eefe552a33df_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 150)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (12, N'Chocolate Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__8__a97d075014c646f4a36e04ed79523749_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 200)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (13, N'Winter Flower Cake', 320000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__10__eccc6e2813c645699dbf7db2450a129e_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 250)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (14, N'Spring Flower Cake', 320000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__11__6cae7e1e253e4f77a98648346b35cf6e_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 300)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (15, N'Autumn Flower Cake', 320000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/hh2___1__516071e6ba18498ab409a00ec29d622e_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 250)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (16, N'Summer Flower Cake', 320000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__23__9d0fdbf5fdf7498c8605451ebcbc180d_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 100)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (17, N'Icing Lollipop Cake', 380000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__21__11b52c57c5114331b60f0b4988c5ae84_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 1000)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (18, N'Sweet Cloudy Cake', 350000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/banh-kem-sweet-cloudy_e4cf4ce0673a4e45b39c44d488ab47a2_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 870)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (19, N'Flower Fruit Cake', 300000, 1, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__22__34284503ee7645828fb4505eeb061136_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 830)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (20, N'Flower Of Love Cake', 300000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/banh-kem-flower-of-love_97cf1bd68f944b0ba6cd30f8bf43d47e_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 770)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (21, N'Macaron Delight Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__26__183b8b11eaf243b2b725ae895595a06f_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 880)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (22, N'Seasonal Fruit Cake', 380000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__14__90c06a89e8c44efe853828b4eb5362f4_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 400)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (23, N'Strawberry Sweet', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2022/04/Website_StrawberryCake.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 500)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (24, N'Banana Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2021/04/Banana-Cake.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 1000)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (25, N'Confetti Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2020/08/confetti-cake.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 870)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (26, N'Red Velvet Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2019/12/Red-Velvet-Cake.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 830)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (27, N'Heart Chocolate Cake', 350000, 1, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2020/01/butter-cakes-48.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 770)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (28, N'Taro Mousse Cake', 380000, 2, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2021/08/TaroMousse.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 500)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (29, N'Cheesecake', 380000, 2, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2021/01/Cakes-48.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 1000)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (30, N'Chocolate Truffle Cake', 380000, 2, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2022/04/Website_ChocoTruffleCake.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 870)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (31, N'Tiramisu', 380000, 2, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2020/08/Tiramisu.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 830)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (32, N'Sweet Potato Mousse Cake', 380000, 2, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2019/12/cake-29_2.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 770)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (33, N'Triple Chocolatemousse Cake', 380000, 2, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2019/12/cake-23.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 880)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (34, N'Vanilla Chocolateheart Mousse Cake', 380000, 2, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2019/12/Vanilla-Chocolate-Heart-Mousse.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 400)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (35, N'Mango Cake', 380000, 2, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__3__7899d2bdbec44f51b2fac69ef76a8f72_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 500)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (36, N'Among Us Impostor Cake', 300000, 3, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2022/03/AmongUsImpostor.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 500)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (37, N'Among Us Choco Crunch Cake', 300000, 3, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2021/10/AmongUs.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 1000)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (38, N'Jungle Party', 300000, 3, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2021/06/JungleParty.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 870)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (39, N'Choo Choo Train', 300000, 3, 4.5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2021/03/ChooChooTrain.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 830)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (40, N'Train Village', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2020/05/TitipoCake_778_778-1.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 770)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (41, N'Party Bear', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2020/09/party-bear.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 880)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (42, N'Piggy Cake', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://www.tljus.com/wp-content/uploads/2020/06/PiggyCake.jpg', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 400)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (43, N'3D Car Cake', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__16__cf5a661d14ef492592f1775ecc1ba6c2_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 770)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (44, N'Blue Ocean Cake', 380000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__18__62de33df194346809d4ae6f1b681c572_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 880)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (45, N'Happy Farm Cake', 380000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__17__233283ecb4624d518677d6789c7d3579_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 400)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (46, N'Teddy Bear Cake', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__19__3b6b82354d894717a28251e5857df895_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 500)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (47, N'Lion Cake ', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__7__f038adcf53a04d0fa3ea4b224fe1a71a_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 1000)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (48, N'Sheep Cake', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__6__7bc665d01d6f46bbb0b4f71bd2036c65_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 870)
INSERT [Production].[Products] ([Id], [Name], [Price], [ProductCategoryId], [AvgRating], [Description], [Photos], [DateRealease], [NumberOfPurchases]) VALUES (49, N'Cat Cake', 300000, 3, 5, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis metus eget tellus auctor, nec consequat ipsum semper. Praesent dui velit, malesuada ac scelerisque vel, imperdiet sit amet massa. Integer sit amet accumsan augue. Suspendisse malesuada ex quis massa lobortis tempor. In hac habitasse platea dictumst. Vestibulum dictum nisl dolor, at porta sapien bibendum at. Proin quis ligula enim. Praesent quis nulla id mauris feugiat pellentesque nec vitae turpis.', N'https://product.hstatic.net/200000411281/product/thiet_ke_chua_co_ten__4__a9b66c62bddf4cfc90b011b75b4652de_master.png', CAST(N'2022-05-01T07:09:01.0000000' AS DateTime2), 830)
SET IDENTITY_INSERT [Production].[Products] OFF
GO
SET IDENTITY_INSERT [Production].[Sizes] ON 

INSERT [Production].[Sizes] ([Id], [Name]) VALUES (1, N'small')
INSERT [Production].[Sizes] ([Id], [Name]) VALUES (2, N'medium')
INSERT [Production].[Sizes] ([Id], [Name]) VALUES (3, N'large')
SET IDENTITY_INSERT [Production].[Sizes] OFF
GO
SET IDENTITY_INSERT [Sales].[PaymentMethods] ON 

INSERT [Sales].[PaymentMethods] ([Id], [Name]) VALUES (1, N'momo')
INSERT [Sales].[PaymentMethods] ([Id], [Name]) VALUES (2, N'cod')
SET IDENTITY_INSERT [Sales].[PaymentMethods] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_PhoneNumber]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_PhoneNumber] ON [Person].[Users]
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ProductCategoryId]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_ProductCategoryId] ON [Production].[Products]
(
	[ProductCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Invoices_OrderGuid]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_Invoices_OrderGuid] ON [Sales].[Invoices]
(
	[OrderGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderLines_OrderGuid]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderLines_OrderGuid] ON [Sales].[OrderLines]
(
	[OrderGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderLines_ProductId]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderLines_ProductId] ON [Sales].[OrderLines]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderLines_SizeId]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_OrderLines_SizeId] ON [Sales].[OrderLines]
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_PaymentMethodId]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_PaymentMethodId] ON [Sales].[Orders]
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 5/25/2022 1:43:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [Sales].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Person].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsAdmin]
GO
ALTER TABLE [Person].[Users] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [Person].[Users] ADD  DEFAULT (N'') FOR [PhoneNumber]
GO
ALTER TABLE [Production].[Products] ADD  DEFAULT ((0)) FOR [ProductCategoryId]
GO
ALTER TABLE [Production].[Products] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [Production].[Products] ADD  DEFAULT (N'') FOR [Photos]
GO
ALTER TABLE [Production].[Products] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DateRealease]
GO
ALTER TABLE [Production].[Products] ADD  DEFAULT ((0)) FOR [NumberOfPurchases]
GO
ALTER TABLE [Sales].[OrderLines] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [OrderGuid]
GO
ALTER TABLE [Sales].[Orders] ADD  DEFAULT ((0.000000000000000e+000)) FOR [TotalCost]
GO
ALTER TABLE [Sales].[Orders] ADD  DEFAULT ((0)) FOR [PaymentMethodId]
GO
ALTER TABLE [Production].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories_ProductCategoryId] FOREIGN KEY([ProductCategoryId])
REFERENCES [Production].[ProductCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Production].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories_ProductCategoryId]
GO
ALTER TABLE [Sales].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Orders_OrderGuid] FOREIGN KEY([OrderGuid])
REFERENCES [Sales].[Orders] ([guidOrder])
ON DELETE CASCADE
GO
ALTER TABLE [Sales].[Invoices] CHECK CONSTRAINT [FK_Invoices_Orders_OrderGuid]
GO
ALTER TABLE [Sales].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Orders_OrderGuid] FOREIGN KEY([OrderGuid])
REFERENCES [Sales].[Orders] ([guidOrder])
ON DELETE CASCADE
GO
ALTER TABLE [Sales].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Orders_OrderGuid]
GO
ALTER TABLE [Sales].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [Production].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Sales].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Products_ProductId]
GO
ALTER TABLE [Sales].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Sizes_SizeId] FOREIGN KEY([SizeId])
REFERENCES [Production].[Sizes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Sales].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Sizes_SizeId]
GO
ALTER TABLE [Sales].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentMethods_PaymentMethodId] FOREIGN KEY([PaymentMethodId])
REFERENCES [Sales].[PaymentMethods] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Sales].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentMethods_PaymentMethodId]
GO
ALTER TABLE [Sales].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [Person].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Sales].[Orders] CHECK CONSTRAINT [FK_Orders_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [CakeShopDb] SET  READ_WRITE 
GO
