/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TOP (1000) [Id]
--      ,[XML_String]
--      ,[XML_XElement]
--  FROM [MyXMLDB].[dbo].[XML_Data]

  select [XML_XElement].value('(ArrayOfCar/Car/Name/text())[3]', 'nvarchar(100)'),
  FORMAT ([XML_XElement].value('(ArrayOfCar/Car/ProductionDate/text())[3]', 'date'), 'dd MMMM yyyy', 'uk-ua')
  FROM [MyXMLDB].[dbo].[XML_Data]