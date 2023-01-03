/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [BusinessEntityID]
      ,[Title]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[Suffix]
      ,[Shift]
      ,[Department]
      ,[GroupName]
      ,[StartDate]
      ,[EndDate]
  FROM [AdventureWorks2019].[HumanResources].[vEmployeeDepartmentHistory]