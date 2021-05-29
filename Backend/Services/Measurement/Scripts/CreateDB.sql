USE [Measurement]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderedMeasureEquivalences]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderedMeasureEquivalences] DROP CONSTRAINT IF EXISTS [FK_OrderedMeasureEquivalences_MeasureEquivalences]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderedMeasureEquivalences]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderedMeasureEquivalences] DROP CONSTRAINT IF EXISTS [FK_OrderedMeasureEquivalences_Conversions]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MeasureEquivalences]') AND type in (N'U'))
ALTER TABLE [dbo].[MeasureEquivalences] DROP CONSTRAINT IF EXISTS [FK_MeasureEquivalences_MeasuresTo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MeasureEquivalences]') AND type in (N'U'))
ALTER TABLE [dbo].[MeasureEquivalences] DROP CONSTRAINT IF EXISTS [FK_MeasureEquivalences_MeasuresFrom]
GO
/****** Object:  Index [PK_OrderedMeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderedMeasureEquivalences]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderedMeasureEquivalences] DROP CONSTRAINT IF EXISTS [PK_OrderedMeasureEquivalences]
GO
/****** Object:  Index [PK_Measures]    Script Date: 29/5/2021 17:42:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Measures]') AND type in (N'U'))
ALTER TABLE [dbo].[Measures] DROP CONSTRAINT IF EXISTS [PK_Measures]
GO
/****** Object:  Index [PK_MeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MeasureEquivalences]') AND type in (N'U'))
ALTER TABLE [dbo].[MeasureEquivalences] DROP CONSTRAINT IF EXISTS [PK_MeasureEquivalences]
GO
/****** Object:  Index [PK_Conversions]    Script Date: 29/5/2021 17:42:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Conversions]') AND type in (N'U'))
ALTER TABLE [dbo].[Conversions] DROP CONSTRAINT IF EXISTS [PK_Conversions]
GO
/****** Object:  Table [dbo].[OrderedMeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
DROP TABLE IF EXISTS [dbo].[OrderedMeasureEquivalences]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 29/5/2021 17:42:08 ******/
DROP TABLE IF EXISTS [dbo].[Measures]
GO
/****** Object:  Table [dbo].[MeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
DROP TABLE IF EXISTS [dbo].[MeasureEquivalences]
GO
/****** Object:  Table [dbo].[Conversions]    Script Date: 29/5/2021 17:42:08 ******/
DROP TABLE IF EXISTS [dbo].[Conversions]
GO
/****** Object:  Table [dbo].[Conversions]    Script Date: 29/5/2021 17:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversions](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[OwnedBy] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasureEquivalences](
	[Id] [uniqueidentifier] NOT NULL,
	[MeasureFromId] [uniqueidentifier] NOT NULL,
	[MeasureToId] [uniqueidentifier] NOT NULL,
	[IngredientFrom] [uniqueidentifier] NOT NULL,
	[IngredientTo] [uniqueidentifier] NOT NULL,
	[Factor] [float] NOT NULL,
	[OwnedBy] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 29/5/2021 17:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [varchar](256) NOT NULL,
	[ShortName] [varchar](16) NULL,
	[OwnedBy] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderedMeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderedMeasureEquivalences](
	[Id] [uniqueidentifier] NOT NULL,
	[MeasureEquivalenceId] [uniqueidentifier] NOT NULL,
	[ConversionId] [uniqueidentifier] NOT NULL,
	[Order] [int] NOT NULL,
	[InvertEquivalence] [bit] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Conversions] ([Id], [Name], [OwnedBy]) VALUES (N'25e3072b-f86d-4a60-bdd0-d903bef30c99', N'U. Manzanas a Kg.', N'00000000-0000-0000-0000-000000000000')
GO
INSERT [dbo].[MeasureEquivalences] ([Id], [MeasureFromId], [MeasureToId], [IngredientFrom], [IngredientTo], [Factor], [OwnedBy]) VALUES (N'41606253-1c60-4eae-8512-32f01606b43a', N'f86b8f99-7cf7-4317-9d9e-53379dc629b6', N'7e858eff-124e-4f59-b45c-6daf188329c6', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', 1000, N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[MeasureEquivalences] ([Id], [MeasureFromId], [MeasureToId], [IngredientFrom], [IngredientTo], [Factor], [OwnedBy]) VALUES (N'6c2d9aa6-2796-4f61-ab1c-f4cd1f370eb5', N'39e7055a-bd43-451a-969b-c74c7d0c7c2d', N'4bba2fa7-5280-498a-b32f-698b903f9a7d', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', 1000, N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[MeasureEquivalences] ([Id], [MeasureFromId], [MeasureToId], [IngredientFrom], [IngredientTo], [Factor], [OwnedBy]) VALUES (N'3b1d5f32-4329-4a1b-8012-f349c0703f93', N'39e7055a-bd43-451a-969b-c74c7d0c7c2d', N'bcf547a8-fcba-4368-a86f-92ee1549ad7f', N'00000000-0000-0000-0000-000000000000', N'00000000-0000-0000-0000-000000000000', 1000, N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[MeasureEquivalences] ([Id], [MeasureFromId], [MeasureToId], [IngredientFrom], [IngredientTo], [Factor], [OwnedBy]) VALUES (N'458f155d-8984-4b14-ae4d-42b0f349f50f', N'008de672-7fcd-4cce-8b98-94c1905da5e7', N'7e858eff-124e-4f59-b45c-6daf188329c6', N'6c0ba731-5bff-4152-9ba1-01612dd754b3', N'6c0ba731-5bff-4152-9ba1-01612dd754b3', 150, N'00000000-0000-0000-0000-000000000000')
GO
INSERT [dbo].[Measures] ([Id], [FullName], [ShortName], [OwnedBy]) VALUES (N'f86b8f99-7cf7-4317-9d9e-53379dc629b6', N'Kilogramo', N'Kg', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Measures] ([Id], [FullName], [ShortName], [OwnedBy]) VALUES (N'39e7055a-bd43-451a-969b-c74c7d0c7c2d', N'Litro', N'Lt', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Measures] ([Id], [FullName], [ShortName], [OwnedBy]) VALUES (N'008de672-7fcd-4cce-8b98-94c1905da5e7', N'Unidad', N'U', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Measures] ([Id], [FullName], [ShortName], [OwnedBy]) VALUES (N'bcf547a8-fcba-4368-a86f-92ee1549ad7f', N'Centímetro Cúbico', N'cm3', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Measures] ([Id], [FullName], [ShortName], [OwnedBy]) VALUES (N'4bba2fa7-5280-498a-b32f-698b903f9a7d', N'Mililitro', N'ml', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Measures] ([Id], [FullName], [ShortName], [OwnedBy]) VALUES (N'7e858eff-124e-4f59-b45c-6daf188329c6', N'Gramo', N'Gr', N'00000000-0000-0000-0000-000000000000')
GO
INSERT [dbo].[OrderedMeasureEquivalences] ([Id], [MeasureEquivalenceId], [ConversionId], [Order], [InvertEquivalence]) VALUES (N'64780d0a-3f38-4be7-9f11-ce36bed1d661', N'458f155d-8984-4b14-ae4d-42b0f349f50f', N'25e3072b-f86d-4a60-bdd0-d903bef30c99', 1, 0)
INSERT [dbo].[OrderedMeasureEquivalences] ([Id], [MeasureEquivalenceId], [ConversionId], [Order], [InvertEquivalence]) VALUES (N'f978b0ef-2811-422d-84dd-537ff2772373', N'41606253-1c60-4eae-8512-32f01606b43a', N'25e3072b-f86d-4a60-bdd0-d903bef30c99', 2, 1)
GO
/****** Object:  Index [PK_Conversions]    Script Date: 29/5/2021 17:42:08 ******/
ALTER TABLE [dbo].[Conversions] ADD  CONSTRAINT [PK_Conversions] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_MeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
ALTER TABLE [dbo].[MeasureEquivalences] ADD  CONSTRAINT [PK_MeasureEquivalences] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_Measures]    Script Date: 29/5/2021 17:42:08 ******/
ALTER TABLE [dbo].[Measures] ADD  CONSTRAINT [PK_Measures] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_OrderedMeasureEquivalences]    Script Date: 29/5/2021 17:42:08 ******/
ALTER TABLE [dbo].[OrderedMeasureEquivalences] ADD  CONSTRAINT [PK_OrderedMeasureEquivalences] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MeasureEquivalences]  WITH CHECK ADD  CONSTRAINT [FK_MeasureEquivalences_MeasuresFrom] FOREIGN KEY([MeasureFromId])
REFERENCES [dbo].[Measures] ([Id])
GO
ALTER TABLE [dbo].[MeasureEquivalences] CHECK CONSTRAINT [FK_MeasureEquivalences_MeasuresFrom]
GO
ALTER TABLE [dbo].[MeasureEquivalences]  WITH CHECK ADD  CONSTRAINT [FK_MeasureEquivalences_MeasuresTo] FOREIGN KEY([MeasureToId])
REFERENCES [dbo].[Measures] ([Id])
GO
ALTER TABLE [dbo].[MeasureEquivalences] CHECK CONSTRAINT [FK_MeasureEquivalences_MeasuresTo]
GO
ALTER TABLE [dbo].[OrderedMeasureEquivalences]  WITH CHECK ADD  CONSTRAINT [FK_OrderedMeasureEquivalences_Conversions] FOREIGN KEY([ConversionId])
REFERENCES [dbo].[Conversions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderedMeasureEquivalences] CHECK CONSTRAINT [FK_OrderedMeasureEquivalences_Conversions]
GO
ALTER TABLE [dbo].[OrderedMeasureEquivalences]  WITH CHECK ADD  CONSTRAINT [FK_OrderedMeasureEquivalences_MeasureEquivalences] FOREIGN KEY([MeasureEquivalenceId])
REFERENCES [dbo].[MeasureEquivalences] ([Id])
GO
ALTER TABLE [dbo].[OrderedMeasureEquivalences] CHECK CONSTRAINT [FK_OrderedMeasureEquivalences_MeasureEquivalences]
GO
