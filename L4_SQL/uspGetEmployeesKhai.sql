USE [AdventureWorks2019]
GO

/****** Object:  StoredProcedure [HumanResources].[uspGetEmployeesTest2]    Script Date: 1/3/2023 5:41:36 PM ******/
DROP PROCEDURE [HumanResources].[uspGetEmployeesKhai]
GO

/****** Object:  StoredProcedure [HumanResources].[uspGetEmployeesTest2]    Script Date: 1/3/2023 5:41:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [HumanResources].[uspGetEmployeesKhai]   
    @BusEntId int,
	@FoundLastName nvarchar(max) OUT
      
AS   

BEGIN
	SET NOCOUNT ON;
	DECLARE @Name nvarchar(50);

    SELECT @Name = LastName  
    FROM HumanResources.vEmployeeDepartmentHistory  
    WHERE [BusinessEntityID] = @BusEntId

	IF @Name IS NULL
		RAISERROR ('Could not find requested employee', 15, 1);
	ELSE
		SET @FoundLastName = @Name;
END    
GO


---
---
DECLARE @SName nvarchar(50)
EXECUTE [HumanResources].[uspGetEmployeesKhai] 5, @SName OUT;
print @SName