USE [MyDB]
GO

/****** Object:  Table [dbo].[Countries]    Script Date: 5/3/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [MyDB]
GO

/****** Object:  Table [dbo].[JobSeeker]    Script Date: 5/3/2021 4:05:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JobSeeker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[GENDER] [bit] NULL,
	[Address] [nvarchar](50) NULL,
	[Mobile] [nvarchar](13) NULL,
	[resume] [varchar](50) NULL,
	[Skills] [nvarchar](50) NULL,
	[Country] [int] NULL,
	[DOB] [date] NULL,
	[IsJava] [bit] NULL,
	[IsDotnet] [bit] NULL,
	[IsSAP] [bit] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JobSeeker] ADD  DEFAULT ((0)) FOR [IsJava]
GO

ALTER TABLE [dbo].[JobSeeker] ADD  DEFAULT ((0)) FOR [IsDotnet]
GO

ALTER TABLE [dbo].[JobSeeker] ADD  DEFAULT ((0)) FOR [IsSAP]
GO

ALTER TABLE [dbo].[JobSeeker]  WITH CHECK ADD FOREIGN KEY([Country])
REFERENCES [dbo].[Countries] ([Id])
GO


