/****** Script for SelectTopNRows command from SSMS  ******/
--insert into [Measurement].[dbo].[Conversions]
--select NEWID(),'Unidades de Manzanas a Kg','00000000-0000-0000-0000-000000000000'

select c.[Name], ome.[Order], m1.FullName "From", m2.FullName "To", me.IngredientFrom, me.IngredientTo, me.Factor, ome.InvertEquivalence
from Conversions c
inner join OrderedMeasureEquivalences ome
inner join MeasureEquivalences me
inner join Measures m1
on m1.Id = me.MeasureFromId
inner join Measures m2
on m2.Id = me.MeasureToId
on me.Id = ome.MeasureEquivalenceId
on c.Id = ome.ConversionId
order by ome.[Order]


--(select me1.id meid
--			from MeasureEquivalences me1
--			inner join Measures m1 
--			on m1.Id = me1.MeasureFromId) tfrom
--on tfrom.meid = ome.MeasureEquivalenceId
--inner join (select me2.id meid
--			from MeasureEquivalences me2
--			inner join Measures m2 
--			on m2.Id = me2.MeasureToId) tto
--on tto.meid = ome.MeasureEquivalenceId

