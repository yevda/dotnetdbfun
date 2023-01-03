USE [AdventureWorks2019]
GO

/****** Object:  UserDefinedFunction [dbo].[GetEmployeesByIdKhai]    Script Date: 1/3/2023 6:23:29 PM ******/
DROP FUNCTION [dbo].[GetEmployeesByIdKhai]
GO

/****** Object:  UserDefinedFunction [dbo].[GetEmployeesByIdKhai]    Script Date: 1/3/2023 6:23:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[GetEmployeesByIdKhai] 
(
@param1 int
)
RETURNS TABLE
AS RETURN
(
SELECT * FROM [AdventureWorks2019].[HumanResources].[vEmployeeDepartmentHistory]
WHERE [BusinessEntityID] = @param1
)
GO
---
---

SELECT * FROM [dbo].[GetEmployeesByIdKhai] (5)
