USE [master]
GO
/****** Object:  Database [SportClub]    Script Date: 5/16/2019 5:35:25 PM ******/
CREATE DATABASE [SportClub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SportClub', FILENAME = N'C:\Users\mykyta.tereshkin\SportClub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SportClub_log', FILENAME = N'C:\Users\mykyta.tereshkin\SportClub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SportClub] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportClub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SportClub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SportClub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SportClub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SportClub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SportClub] SET ARITHABORT OFF 
GO
ALTER DATABASE [SportClub] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SportClub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SportClub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SportClub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SportClub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SportClub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SportClub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SportClub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SportClub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SportClub] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SportClub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SportClub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SportClub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SportClub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SportClub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SportClub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SportClub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SportClub] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SportClub] SET  MULTI_USER 
GO
ALTER DATABASE [SportClub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SportClub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SportClub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SportClub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SportClub] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SportClub] SET QUERY_STORE = OFF
GO
USE [SportClub]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SportClub]
GO
/****** Object:  Table [dbo].[Competition]    Script Date: 5/16/2019 5:35:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competition](
	[gkey] [smallint] IDENTITY(1,1) NOT NULL,
	[date] [smalldatetime] NULL,
	[cost] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[gkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 5/16/2019 5:35:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[id_gkey] [smallint] IDENTITY(1,1) NOT NULL,
	[fio] [nvarchar](150) NULL,
	[telephone] [varchar](13) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_gkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 5/16/2019 5:35:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[fkey_member] [smallint] NOT NULL,
	[fkey_competition] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[fkey_member] ASC,
	[fkey_competition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 5/16/2019 5:35:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[id_gkey] [smallint] IDENTITY(1,1) NOT NULL,
	[fio] [nvarchar](150) NULL,
	[telephone] [varchar](13) NULL,
	[adress] [nvarchar](200) NULL,
	[category] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_gkey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Training]    Script Date: 5/16/2019 5:35:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Training](
	[date] [smalldatetime] NOT NULL,
	[fkey_member] [smallint] NOT NULL,
	[fkey_trainer] [smallint] NOT NULL,
	[cost] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[date] ASC,
	[fkey_member] ASC,
	[fkey_trainer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Competition] ON 

INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (1, CAST(N'2019-09-09T00:00:00' AS SmallDateTime), 180.0000)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (2, CAST(N'2019-08-13T00:00:00' AS SmallDateTime), 200.0000)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (3, CAST(N'2019-05-17T00:00:00' AS SmallDateTime), 250.0000)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (4, CAST(N'2019-06-01T00:00:00' AS SmallDateTime), 300.0000)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (5, CAST(N'2019-07-22T00:00:00' AS SmallDateTime), 120.0000)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (6, CAST(N'2019-05-19T00:00:00' AS SmallDateTime), 220.9900)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (7, CAST(N'2019-05-24T00:00:00' AS SmallDateTime), 123.0000)
INSERT [dbo].[Competition] ([gkey], [date], [cost]) VALUES (8, CAST(N'2019-05-23T00:00:00' AS SmallDateTime), 3.0000)
SET IDENTITY_INSERT [dbo].[Competition] OFF
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([id_gkey], [fio], [telephone]) VALUES (2, N'qwe', N'qwe')
INSERT [dbo].[Member] ([id_gkey], [fio], [telephone]) VALUES (3, N'zxc', N'zxc')
INSERT [dbo].[Member] ([id_gkey], [fio], [telephone]) VALUES (4, N'rty', N'rty')
SET IDENTITY_INSERT [dbo].[Member] OFF
SET IDENTITY_INSERT [dbo].[Trainer] ON 

INSERT [dbo].[Trainer] ([id_gkey], [fio], [telephone], [adress], [category]) VALUES (1, N'John Doe', N'000000', N'some address 1', N'1')
INSERT [dbo].[Trainer] ([id_gkey], [fio], [telephone], [adress], [category]) VALUES (2, N'Sidney Smith', N'111112', N'some address 2 ', N'some address 2 ')
INSERT [dbo].[Trainer] ([id_gkey], [fio], [telephone], [adress], [category]) VALUES (3, N'Harry Potter', N'222222', N'some address 3', N'3')
INSERT [dbo].[Trainer] ([id_gkey], [fio], [telephone], [adress], [category]) VALUES (4, N'Sam Willis', N'333333', N'some address 4', N'4')
INSERT [dbo].[Trainer] ([id_gkey], [fio], [telephone], [adress], [category]) VALUES (5, N'Will Smith', N'444444', N'some address 5', N'5')
INSERT [dbo].[Trainer] ([id_gkey], [fio], [telephone], [adress], [category]) VALUES (7, N'qwe', N'qwe', N'qweqwe', N'qwe')
SET IDENTITY_INSERT [dbo].[Trainer] OFF
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Competition] FOREIGN KEY([fkey_competition])
REFERENCES [dbo].[Competition] ([gkey])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Competition]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Member] FOREIGN KEY([fkey_member])
REFERENCES [dbo].[Member] ([id_gkey])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Member]
GO
ALTER TABLE [dbo].[Training]  WITH CHECK ADD  CONSTRAINT [FK_Training_Member] FOREIGN KEY([fkey_member])
REFERENCES [dbo].[Member] ([id_gkey])
GO
ALTER TABLE [dbo].[Training] CHECK CONSTRAINT [FK_Training_Member]
GO
ALTER TABLE [dbo].[Training]  WITH CHECK ADD  CONSTRAINT [FK_Training_Trainer] FOREIGN KEY([fkey_trainer])
REFERENCES [dbo].[Trainer] ([id_gkey])
GO
ALTER TABLE [dbo].[Training] CHECK CONSTRAINT [FK_Training_Trainer]
GO
USE [master]
GO
ALTER DATABASE [SportClub] SET  READ_WRITE 
GO
