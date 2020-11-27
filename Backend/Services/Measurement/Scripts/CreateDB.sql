USE [Measurement]
GO
/****** Object:  Table [dbo].[MeasureEquivalences]    Script Date: 26/11/2020 21:58:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasureEquivalences](
	[Id] [bigint] NOT NULL,
	[MeasureFrom] [bigint] NOT NULL,
	[MeasureTo] [bigint] NOT NULL,
	[IngredientFrom] [uniqueidentifier] NULL,
	[IngredientTo] [uniqueidentifier] NULL,
	[Factor] [float] NOT NULL,
 CONSTRAINT [PK_MeasureEquivalences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 26/11/2020 21:58:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[Id] [bigint] NOT NULL,
	[DistributedId] [uniqueidentifier] NOT NULL,
	[FullName] [varchar](256) NOT NULL,
	[ShortName] [varchar](16) NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Measures_DistributedId]    Script Date: 26/11/2020 21:58:49 ******/
ALTER TABLE [dbo].[Measures] ADD  CONSTRAINT [IX_Measures_DistributedId] UNIQUE NONCLUSTERED 
(
	[DistributedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Measures] ADD  CONSTRAINT [DF_Measures_DistributedId]  DEFAULT (newid()) FOR [DistributedId]
GO
ALTER TABLE [dbo].[MeasureEquivalences]  WITH CHECK ADD  CONSTRAINT [FK_MeasureEquivalences_Measures_From] FOREIGN KEY([MeasureFrom])
REFERENCES [dbo].[Measures] ([Id])
GO
ALTER TABLE [dbo].[MeasureEquivalences] CHECK CONSTRAINT [FK_MeasureEquivalences_Measures_From]
GO
ALTER TABLE [dbo].[MeasureEquivalences]  WITH CHECK ADD  CONSTRAINT [FK_MeasureEquivalences_Measures_To] FOREIGN KEY([MeasureTo])
REFERENCES [dbo].[Measures] ([Id])
GO
ALTER TABLE [dbo].[MeasureEquivalences] CHECK CONSTRAINT [FK_MeasureEquivalences_Measures_To]
GO
