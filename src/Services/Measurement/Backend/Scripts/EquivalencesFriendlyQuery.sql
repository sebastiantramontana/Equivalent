/****** Script for SelectTopNRows command from SSMS  ******/
SELECT me.Id, mfrom.FullName, mto.FullName, me.IngredientFrom, me.IngredientTo, me.Factor, me.OwnedBy
FROM MeasureEquivalences me
inner join Measures mfrom
on mfrom.Id = me.MeasureFromId
inner join Measures mto
on mto.Id = me.MeasureToId