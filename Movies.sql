USE [CRUDApiMVC]
GO

/****** Object:  Table [dbo].[Movies]    Script Date: 19/04/2022 02:00:58 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ReleaseYear] [date] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Duration] [time](7) NULL,
	[FK_Director] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_DirectorMovies] FOREIGN KEY([FK_Director])
REFERENCES [dbo].[Director] ([Name])
GO

ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_DirectorMovies]
GO


