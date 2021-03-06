USE [master]
GO
/****** Object:  Database [lyl_db_Sales]    Script Date: 16.10.2020 10:52:57 ******/
CREATE DATABASE [lyl_db_Sales]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lyl_db_Sales', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\lyl_db_Sales.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'lyl_db_Sales_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\lyl_db_Sales_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lyl_db_Sales].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lyl_db_Sales] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET ARITHABORT OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lyl_db_Sales] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lyl_db_Sales] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET  DISABLE_BROKER 
GO
ALTER DATABASE [lyl_db_Sales] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lyl_db_Sales] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET RECOVERY FULL 
GO
ALTER DATABASE [lyl_db_Sales] SET  MULTI_USER 
GO
ALTER DATABASE [lyl_db_Sales] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lyl_db_Sales] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lyl_db_Sales] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lyl_db_Sales] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [lyl_db_Sales] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'lyl_db_Sales', N'ON'
GO
ALTER DATABASE [lyl_db_Sales] SET QUERY_STORE = OFF
GO
USE [lyl_db_Sales]
GO
/****** Object:  Table [dbo].[tbl_material]    Script Date: 16.10.2020 10:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_material](
	[materialId] [bigint] NOT NULL,
	[materialName] [nchar](10) NOT NULL,
	[longText] [nvarchar](50) NULL,
	[isVariant] [int] NOT NULL,
	[size] [nchar](10) NULL,
	[color] [nchar](10) NULL,
	[unit] [nchar](10) NOT NULL,
	[pUnit] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[currency] [nchar](10) NOT NULL,
	[stockquantity] [bigint] NOT NULL,
 CONSTRAINT [PK_tbl_material] PRIMARY KEY CLUSTERED 
(
	[materialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sal_head]    Script Date: 16.10.2020 10:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sal_head](
	[docNum] [bigint] NOT NULL,
	[docType] [nchar](10) NOT NULL,
	[docChar] [smallint] NOT NULL,
	[customerId] [bigint] NOT NULL,
	[custName1] [nchar](50) NOT NULL,
	[custName2] [nchar](50) NOT NULL,
	[currency] [nchar](10) NOT NULL,
	[hCurrency] [nchar](10) NOT NULL,
	[docDate] [datetime] NOT NULL,
	[exRate] [decimal](18, 0) NOT NULL,
	[country] [nchar](50) NOT NULL,
	[city] [nchar](50) NOT NULL,
	[address] [nchar](50) NULL,
	[phone] [bigint] NULL,
	[email] [nchar](50) NULL,
	[grandTotal] [decimal](18, 0) NOT NULL,
	[discount] [decimal](18, 0) NOT NULL,
	[subTotal] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_tbl_sal_head] PRIMARY KEY CLUSTERED 
(
	[docType] ASC,
	[docNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_sal_item]    Script Date: 16.10.2020 10:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_sal_item](
	[docNum] [bigint] NOT NULL,
	[docType] [nchar](10) NOT NULL,
	[itemNum] [bigint] NOT NULL,
	[material] [nchar](10) NOT NULL,
	[quantity] [decimal](18, 0) NOT NULL,
	[unit] [nchar](10) NOT NULL,
	[currency] [nchar](10) NOT NULL,
	[grandTotal] [decimal](18, 0) NOT NULL,
	[discount] [decimal](18, 0) NOT NULL,
	[subTotal] [decimal](18, 0) NOT NULL,
	[variantOptions] [nvarchar](250) NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_tbl_sal_item] PRIMARY KEY CLUSTERED 
(
	[docNum] ASC,
	[docType] ASC,
	[itemNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 16.10.2020 10:52:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[Name] [nchar](10) NOT NULL,
	[Password] [nchar](10) NOT NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_material] ([materialId], [materialName], [longText], [isVariant], [size], [color], [unit], [pUnit], [price], [currency], [stockquantity]) VALUES (10, N'Atkı      ', N' çoçuk atkısı', 1, N's         ', N'kırmızı   ', N'AD        ', 1, CAST(15 AS Decimal(18, 0)), N'TL        ', 5000)
INSERT [dbo].[tbl_material] ([materialId], [materialName], [longText], [isVariant], [size], [color], [unit], [pUnit], [price], [currency], [stockquantity]) VALUES (20, N'Çorap     ', N'uzun çorap', 1, N'M         ', N'Mavi      ', N'AD        ', 1, CAST(5 AS Decimal(18, 0)), N'TL        ', 8052)
INSERT [dbo].[tbl_material] ([materialId], [materialName], [longText], [isVariant], [size], [color], [unit], [pUnit], [price], [currency], [stockquantity]) VALUES (30, N'Bere      ', N' yuvarlak bere', 1, N'L         ', N'Sarı      ', N'AD        ', 1, CAST(20 AS Decimal(18, 0)), N'TL        ', 3506)
INSERT [dbo].[tbl_material] ([materialId], [materialName], [longText], [isVariant], [size], [color], [unit], [pUnit], [price], [currency], [stockquantity]) VALUES (40, N'Kulaklık  ', N'kablosuz', 0, N'          ', N'          ', N'AD        ', 1, CAST(50 AS Decimal(18, 0)), N'USD       ', 350)
INSERT [dbo].[tbl_material] ([materialId], [materialName], [longText], [isVariant], [size], [color], [unit], [pUnit], [price], [currency], [stockquantity]) VALUES (50, N'Kumaş     ', N'döşemelik', 1, N'std       ', N'düz       ', N'M         ', 1, CAST(25 AS Decimal(18, 0)), N'Eur       ', 2000)
GO
INSERT [dbo].[tbl_sal_head] ([docNum], [docType], [docChar], [customerId], [custName1], [custName2], [currency], [hCurrency], [docDate], [exRate], [country], [city], [address], [phone], [email], [grandTotal], [discount], [subTotal]) VALUES (100000000, N'F1        ', 0, 100000000, N'leyla                                             ', N'akmancı                                           ', N'TL        ', N'TL        ', CAST(N'2020-10-14T00:00:00.000' AS DateTime), CAST(1 AS Decimal(18, 0)), N'TR                                                ', N'istanbul                                          ', N'esenyurt                                          ', 2523338, N'example@gmail.com                                 ', CAST(3065 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(3075 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_head] ([docNum], [docType], [docChar], [customerId], [custName1], [custName2], [currency], [hCurrency], [docDate], [exRate], [country], [city], [address], [phone], [email], [grandTotal], [discount], [subTotal]) VALUES (100000001, N'F1        ', 0, 100000000, N'leyla                                             ', N'akmancı                                           ', N'USD       ', N'TL        ', CAST(N'2020-10-14T00:00:00.000' AS DateTime), CAST(1 AS Decimal(18, 0)), N'TR                                                ', N'istanbul                                          ', N'esenyurt                                          ', 26598745, N'example2@gmail.com                                ', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_head] ([docNum], [docType], [docChar], [customerId], [custName1], [custName2], [currency], [hCurrency], [docDate], [exRate], [country], [city], [address], [phone], [email], [grandTotal], [discount], [subTotal]) VALUES (100000003, N'F1        ', 0, 100000000, N'leyla                                             ', N'akmancı                                           ', N'EUR       ', N'TL        ', CAST(N'2020-10-14T00:00:00.000' AS DateTime), CAST(1 AS Decimal(18, 0)), N'TR                                                ', N'istanbul                                          ', N'esenyurt                                          ', 26598745, N'example2@gmail.com                                ', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_head] ([docNum], [docType], [docChar], [customerId], [custName1], [custName2], [currency], [hCurrency], [docDate], [exRate], [country], [city], [address], [phone], [email], [grandTotal], [discount], [subTotal]) VALUES (100000004, N'F5        ', 0, 0, N'admin                                             ', N'                                                  ', N'AU        ', N'TL        ', CAST(N'2020-10-13T00:00:00.000' AS DateTime), CAST(0 AS Decimal(18, 0)), N'EN                                                ', N'Hatay                                             ', N'b mnö                                             ', 556, N'jkjjk455                                          ', CAST(1446 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(1456 AS Decimal(18, 0)))
GO
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000000, N'F1        ', 10, N'Atkı      ', CAST(5 AS Decimal(18, 0)), N'AD        ', N'TL        ', CAST(65 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(75 AS Decimal(18, 0)), N'kırmızı s', CAST(15 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000000, N'F1        ', 20, N'Bere      ', CAST(100 AS Decimal(18, 0)), N'AD        ', N'TL        ', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), N'mavi m', CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000000, N'F1        ', 30, N'Çorap     ', CAST(200 AS Decimal(18, 0)), N'AD        ', N'TL        ', CAST(1000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), N'kırmızı s', CAST(5 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000001, N'F1        ', 10, N'Kumaş     ', CAST(2 AS Decimal(18, 0)), N'M         ', N'USD       ', CAST(50 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(50 AS Decimal(18, 0)), N'düz', CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000003, N'F1        ', 20, N'Bere      ', CAST(100 AS Decimal(18, 0)), N'AD        ', N'TL        ', CAST(2000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), N'mavi m', CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000004, N'F5        ', 10, N'Kulaklık  ', CAST(4 AS Decimal(18, 0)), N'KG        ', N'USD       ', CAST(219 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(224 AS Decimal(18, 0)), N'Blue_L', CAST(56 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000004, N'F5        ', 20, N'Bere      ', CAST(12 AS Decimal(18, 0)), N'KG        ', N'GBP       ', CAST(31 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(36 AS Decimal(18, 0)), N'Red_M', CAST(3 AS Decimal(18, 0)))
INSERT [dbo].[tbl_sal_item] ([docNum], [docType], [itemNum], [material], [quantity], [unit], [currency], [grandTotal], [discount], [subTotal], [variantOptions], [price]) VALUES (100000004, N'F5        ', 30, N'Şapka     ', CAST(46 AS Decimal(18, 0)), N'KG        ', N'USD       ', CAST(1196 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(1196 AS Decimal(18, 0)), N'Brown_Std', CAST(26 AS Decimal(18, 0)))
GO
INSERT [dbo].[tbl_User] ([Name], [Password]) VALUES (N'admin     ', N'admin     ')
INSERT [dbo].[tbl_User] ([Name], [Password]) VALUES (N'leyla     ', N'lyl       ')
GO
USE [master]
GO
ALTER DATABASE [lyl_db_Sales] SET  READ_WRITE 
GO
