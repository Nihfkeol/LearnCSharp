USE [master]
GO
/****** Object:  Database [ChooseCourse]    Script Date: 2020/12/3 0:06:23 ******/
CREATE DATABASE [ChooseCourse]
 ON  PRIMARY 
( NAME = N'ChooseCourse', FILENAME = N'D:\SQLServiceData\ChooseCourse.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ChooseCourse_log', FILENAME = N'D:\SQLServiceData\ChooseCourse_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChooseCourse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChooseCourse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChooseCourse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChooseCourse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChooseCourse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChooseCourse] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChooseCourse] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChooseCourse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChooseCourse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChooseCourse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChooseCourse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChooseCourse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChooseCourse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChooseCourse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChooseCourse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChooseCourse] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChooseCourse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChooseCourse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChooseCourse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChooseCourse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChooseCourse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChooseCourse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChooseCourse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChooseCourse] SET RECOVERY FULL 
GO
ALTER DATABASE [ChooseCourse] SET  MULTI_USER 
GO
ALTER DATABASE [ChooseCourse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChooseCourse] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChooseCourse', N'ON'
GO
USE [ChooseCourse]
GO
/****** Object:  Table [dbo].[C]    Script Date: 2020/12/3 0:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[C](
	[cno] [char](7) NOT NULL,
	[cname] [varchar](20) NOT NULL,
	[classh] [int] NULL,
 CONSTRAINT [PK_C] PRIMARY KEY CLUSTERED 
(
	[cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CS]    Script Date: 2020/12/3 0:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CS](
	[scodeno] [char](5) NOT NULL,
	[cno] [char](7) NOT NULL,
 CONSTRAINT [PK_CS] PRIMARY KEY CLUSTERED 
(
	[scodeno] ASC,
	[cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[S]    Script Date: 2020/12/3 0:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S](
	[sno] [char](9) NOT NULL,
	[sname] [char](10) NOT NULL,
	[ssex] [char](2) NULL,
	[scodeno] [char](5) NULL,
	[class] [char](6) NULL,
 CONSTRAINT [PK_S] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SC]    Script Date: 2020/12/3 0:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SC](
	[sno] [char](9) NOT NULL,
	[cno] [char](7) NOT NULL,
 CONSTRAINT [PK_SC] PRIMARY KEY CLUSTERED 
(
	[sno] ASC,
	[cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SLogin]    Script Date: 2020/12/3 0:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SLogin](
	[sno] [char](9) NOT NULL,
	[spaw] [varchar](20) NOT NULL,
 CONSTRAINT [PK_SLogin] PRIMARY KEY CLUSTERED 
(
	[sno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SS]    Script Date: 2020/12/3 0:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SS](
	[scodeno] [char](5) NOT NULL,
	[ssname] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SS] PRIMARY KEY CLUSTERED 
(
	[scodeno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C401001', N'数据结构', 70)
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C401002', N'操作系统', 60)
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C402001', N'指挥信息系统', 60)
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C402002', N'数据库原理', 50)
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C403001', N'计算机原理', 60)
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C403002', N'通信原理', 50)
INSERT [dbo].[C] ([cno], [cname], [classh]) VALUES (N'C404001', N'信息编码与加密', 60)
GO
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0401', N'C401001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0401', N'C402001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0401', N'C402002')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0401', N'C403001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0402', N'C402001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0402', N'C402002')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0402', N'C403001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0403', N'C403001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0403', N'C403002')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0404', N'C401001')
INSERT [dbo].[CS] ([scodeno], [cno]) VALUES (N'S0404', N'C404001')
GO
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201401001', N'张华      ', N'男', N'S0401', N'201401')
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201401002', N'李建平    ', N'男', N'S0401', N'201401')
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201401003', N'王丽丽    ', N'女', N'S0401', N'201401')
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201402001', N'杨秋红    ', N'女', N'S0402', N'201402')
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201402002', N'吴志伟    ', N'男', N'S0402', N'201402')
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201402003', N'李涛      ', N'男', N'S0402', N'201402')
INSERT [dbo].[S] ([sno], [sname], [ssex], [scodeno], [class]) VALUES (N'201403001', N'赵晓燕    ', N'女', N'S0403', N'201403')
GO
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201401001', N'C401001')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201401001', N'C403001')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201401002', N'C401001')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201401002', N'C402002')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201401003', N'C402002')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201402001', N'C401001')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201402001', N'C401002')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201402002', N'C403001')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201402003', N'C403001')
INSERT [dbo].[SC] ([sno], [cno]) VALUES (N'201403001', N'C403002')
GO
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201401001', N'123')
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201401002', N'123')
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201401003', N'123')
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201402001', N'123')
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201402002', N'123')
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201402003', N'123')
INSERT [dbo].[SLogin] ([sno], [spaw]) VALUES (N'201403001', N'123')
GO
INSERT [dbo].[SS] ([scodeno], [ssname]) VALUES (N'S0401', N'计算机科学与技术')
INSERT [dbo].[SS] ([scodeno], [ssname]) VALUES (N'S0402', N'指挥信息系统工程')
INSERT [dbo].[SS] ([scodeno], [ssname]) VALUES (N'S0403', N'网络工程')
INSERT [dbo].[SS] ([scodeno], [ssname]) VALUES (N'S0404', N'信息安全')
GO
USE [master]
GO
ALTER DATABASE [ChooseCourse] SET  READ_WRITE 
GO
