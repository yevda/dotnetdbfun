USE [AdventureWorks2019]
GO

/****** Object:  UserDefinedFunction [dbo].[GetEmployeesByIdKhai]    Script Date: 1/3/2023 6:23:29 PM ******/
DROP FUNCTION [dbo].[CountEmployeesInDepartmentKhai]
GO

/****** Object:  UserDefinedFunction [dbo].[GetEmployeesByIdKhai]    Script Date: 1/3/2023 6:23:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[CountEmployeesInDepartmentKhai] 
(
@param1 nvarchar(50)
)


RETURNS int
AS 
BEGIN

	DECLARE @res int

	SELECT @res = COUNT(1) FROM [AdventureWorks2019].[HumanResources].[vEmployeeDepartmentHistory]
	WHERE [Department] = @param1
	RETURN @res;
END
GO


SELECT [dbo].[CountEmployeesInDepartmentKhai]('Sales')