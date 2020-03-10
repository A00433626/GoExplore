USE [master]
GO
/****** Object:  Database [GoExplore]    Script Date: 01-12-2019 16:24:26 ******/
CREATE DATABASE [GoExplore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GoExplore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GoExplore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GoExplore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GoExplore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GoExplore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GoExplore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GoExplore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GoExplore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GoExplore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GoExplore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GoExplore] SET ARITHABORT OFF 
GO
ALTER DATABASE [GoExplore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GoExplore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GoExplore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GoExplore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GoExplore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GoExplore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GoExplore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GoExplore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GoExplore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GoExplore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GoExplore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GoExplore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GoExplore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GoExplore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GoExplore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GoExplore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GoExplore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GoExplore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GoExplore] SET  MULTI_USER 
GO
ALTER DATABASE [GoExplore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GoExplore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GoExplore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GoExplore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GoExplore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GoExplore] SET QUERY_STORE = OFF
GO
USE [GoExplore]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TicketId] [int] NULL,
	[TicketsBooked] [int] NULL,
	[TotalAmount] [decimal](18, 6) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event_Details]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_Details](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[EventName] [varchar](255) NULL,
	[EventDescription] [varchar](1024) NULL,
	[EventStartDate] [datetime] NULL,
	[EventEndDate] [datetime] NULL,
	[Venue] [varchar](200) NULL,
	[Organiser_ID] [int] NULL,
	[ImagePath] [varchar](255) NULL,
 CONSTRAINT [PK_Event_Details] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventAttendee]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventAttendee](
	[Attendee_id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[Favorites] [varchar](13) NULL,
 CONSTRAINT [PK_EventAttendee] PRIMARY KEY CLUSTERED 
(
	[Attendee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCategory]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](255) NULL,
 CONSTRAINT [PK_EventCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[DateTime] [varchar](255) NULL,
	[Status] [varchar](255) NULL,
	[PayMode] [varchar](255) NULL,
	[Amount] [decimal](18, 6) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[Category] [varchar](255) NULL,
	[Amount] [decimal](18, 6) NULL,
	[TotalCount] [int] NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserNAme] [varchar](255) NULL,
	[EmailId] [varchar](255) NULL,
	[UserType] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Event_Details] ON 
GO
INSERT [dbo].[Event_Details] ([EventId], [CategoryId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [Venue], [Organiser_ID], [ImagePath]) VALUES (1, 1, N'The Music of Pink Floyd', N'Pink Floyd is one of the world’s best-selling bands, and a pivotal player in the history of rock music. Symphony Nova Scotia proudly presents a powerful performance of Pink Floyd’s all-time greatest hits, including Another Brick in the Wall, Wish You Were Here, Hey You, and Comfortably Numb – plus a complete rendition of their monumental, multi-million-selling magnum opus, The Dark Side of the Moon. Don’t miss this symphonic salute of epic proportions!', CAST(N'2020-01-26T16:00:00.000' AS DateTime), CAST(N'2020-01-26T20:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Event_Details] ([EventId], [CategoryId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [Venue], [Organiser_ID], [ImagePath]) VALUES (2, 2, N'4th EnergyDATA Workshop', N'Learn how Atlantic Canadian organizations are playing their part in reducing greenhouse gas emissions locally and beyond our borders. ', CAST(N'2020-02-28T09:00:00.000' AS DateTime), CAST(N'2020-02-28T15:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Event_Details] ([EventId], [CategoryId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [Venue], [Organiser_ID], [ImagePath]) VALUES (3, 3, N'Networking At Night', N'"If you have been hesitant to go to networking events before, this one ', CAST(N'2020-01-16T18:00:00.000' AS DateTime), CAST(N'2020-01-16T20:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Event_Details] ([EventId], [CategoryId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [Venue], [Organiser_ID], [ImagePath]) VALUES (4, 3, N'Halifax Job Fair', N'Looking for Work? New Career? Immediate Hiring? Direct Interview?', CAST(N'2019-12-26T13:00:00.000' AS DateTime), CAST(N'2019-12-26T15:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Event_Details] ([EventId], [CategoryId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [Venue], [Organiser_ID], [ImagePath]) VALUES (5, 4, N'ProLife Nutrition Free Info Session', N'"Join us for a FREE casual evening where we discuss brand new, ground breaking information about the role nutrition plays in your quality of life. In this engaging hour presentation, you will discover:', CAST(N'2019-12-30T12:00:00.000' AS DateTime), CAST(N'2019-12-30T14:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Event_Details] ([EventId], [CategoryId], [EventName], [EventDescription], [EventStartDate], [EventEndDate], [Venue], [Organiser_ID], [ImagePath]) VALUES (6, 4, N'Inner Powers: A Course in Spiritual Intelligence', N'"This practical course explores the inner powers of the soul. ', CAST(N'2020-01-02T19:00:00.000' AS DateTime), CAST(N'2020-01-02T21:00:00.000' AS DateTime), NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Event_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[EventCategory] ON 
GO
INSERT [dbo].[EventCategory] ([CategoryId], [CategoryName]) VALUES (1, N'Music & Entertainment')
GO
INSERT [dbo].[EventCategory] ([CategoryId], [CategoryName]) VALUES (2, N'Learning & Tech')
GO
INSERT [dbo].[EventCategory] ([CategoryId], [CategoryName]) VALUES (3, N'Career & Networking')
GO
INSERT [dbo].[EventCategory] ([CategoryId], [CategoryName]) VALUES (4, N'Health & Wellness')
GO
SET IDENTITY_INSERT [dbo].[EventCategory] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Booking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Booking] ([BookingId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Booking]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Tickets] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Tickets]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Users]
GO
ALTER TABLE [dbo].[Event_Details]  WITH CHECK ADD  CONSTRAINT [FK_Event_Details_EventCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[EventCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[Event_Details] CHECK CONSTRAINT [FK_Event_Details_EventCategory]
GO
ALTER TABLE [dbo].[Event_Details]  WITH CHECK ADD  CONSTRAINT [FK_Event_Details_Users] FOREIGN KEY([Organiser_ID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Event_Details] CHECK CONSTRAINT [FK_Event_Details_Users]
GO
ALTER TABLE [dbo].[EventAttendee]  WITH CHECK ADD  CONSTRAINT [FK_EventAttendee_Event_Details] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event_Details] ([EventId])
GO
ALTER TABLE [dbo].[EventAttendee] CHECK CONSTRAINT [FK_EventAttendee_Event_Details]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Booking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Booking] ([BookingId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Booking]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Event_Details] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event_Details] ([EventId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Event_Details]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Tickets] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([TicketId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Tickets]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEventList]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_GetEventList]  
as  
Begin  
 Begin Try  
  SET NOCOUNT ON;  
  select top 10 ED.EventId, ED.EventName, ED.EventDescription, Convert(varchar,ED.EventStartDate, 100) as EventStartDate, Convert(varchar,ED.EventEndDate, 100) as EventEndDate, ED.Venue, isnull(ED.ImagePath,'../../images/event-1.jpg') as ImagePath,  
    EC.CategoryName,  
    T.Category, isNull(T.Amount, '0') As Amount,  
    U.UserName, U.EmailId  
  From Event_Details ED  
  Left Join EventCategory EC  
  On ED.CategoryId = EC.CategoryId  
  Left Join Tickets T  
  On ED.EventId = T.EventId  
  Left Join Users U  
  On ED.Organiser_ID = U.UserID  
  Order By Ed.EventId Desc
 End Try  
 Begin Catch  
  SELECT    
            ERROR_NUMBER() AS ErrorNumber    
            ,ERROR_SEVERITY() AS ErrorSeverity    
            ,ERROR_STATE() AS ErrorState    
            ,ERROR_PROCEDURE() AS ErrorProcedure    
            ,ERROR_LINE() AS ErrorLine    
            ,ERROR_MESSAGE() AS ErrorMessage;  
 End Catch  
End  
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEventList_Upcoming]    Script Date: 01-12-2019 16:24:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_GetEventList_Upcoming]
as  
Begin  
 Begin Try  
  SET NOCOUNT ON;  
  select top 10 ED.EventId, ED.EventName, ED.EventDescription, Convert(varchar,ED.EventStartDate, 100) as EventStartDate, Convert(varchar,ED.EventEndDate, 100) as EventEndDate, ED.Venue, isnull(ED.ImagePath,'../../images/event-1.jpg') as ImagePath,  
    EC.CategoryName,  
    T.Category, isNull(T.Amount, '0') As Amount,  
    U.UserName, U.EmailId  
  From Event_Details ED  
  Left Join EventCategory EC  
  On ED.CategoryId = EC.CategoryId  
  Left Join Tickets T  
  On ED.EventId = T.EventId  
  Left Join Users U  
  On ED.Organiser_ID = U.UserID  
  Where ED.EventStartDate > GetDate()
  Order By Ed.EventId Desc
 End Try  
 Begin Catch  
  SELECT    
            ERROR_NUMBER() AS ErrorNumber    
            ,ERROR_SEVERITY() AS ErrorSeverity    
            ,ERROR_STATE() AS ErrorState    
            ,ERROR_PROCEDURE() AS ErrorProcedure    
            ,ERROR_LINE() AS ErrorLine    
            ,ERROR_MESSAGE() AS ErrorMessage;  
 End Catch  
End  
GO
USE [master]
GO
ALTER DATABASE [GoExplore] SET  READ_WRITE 
GO
