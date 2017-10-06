USE [AdventureWorks]
GO
/****** Object:  StoredProcedure [dbo].[productUpdateProduct]    Script Date: 11/17/2009 15:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productUpdateProduct]
@name nvarchar(50)
,@productID [int]
,@color nvarchar(15)
,@productNumber nvarchar(25)
,@listPrice money
   AS
BEGIN
    SET NOCOUNT ON;

    
   UPDATE [AdventureWorks].[Production].[Product] SET [Name]=@name,[ProductNumber]=@productNumber,[Color]=@color
           ,[ListPrice]=@listPrice WHERE [ProductID] =@productID
   END;
GO
/****** Object:  StoredProcedure [dbo].[productDeleteProduct]    Script Date: 11/17/2009 15:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productDeleteProduct]
@productID [int]
   AS
BEGIN
    SET NOCOUNT ON;

    
   DELETE FROM [AdventureWorks].[Production].[Product] WHERE [ProductID]=@productID
   END;
GO
/****** Object:  StoredProcedure [dbo].[productGetProductByMaxListPrice]    Script Date: 11/17/2009 15:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productGetProductByMaxListPrice]
@maxListPrice money
   AS
BEGIN
    SET NOCOUNT ON;

    
   SELECT [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[MakeFlag]
      ,[FinishedGoodsFlag]
      ,[Color]
      ,[SafetyStockLevel]
      ,[ReorderPoint]
      ,[StandardCost]
      ,[ListPrice]
      ,[Size]
      ,[SizeUnitMeasureCode]
      ,[WeightUnitMeasureCode]
      ,[Weight]
      ,[DaysToManufacture]
      ,[ProductLine]
      ,[Class]
      ,[Style]
      ,[ProductSubcategoryID]
      ,[ProductModelID]
      ,[SellStartDate]
      ,[SellEndDate]
      ,[DiscontinuedDate]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks].[Production].[Product]
   
   WHERE [ListPrice] <= @maxListPrice
   END;
GO
/****** Object:  StoredProcedure [dbo].[productGetProductByID]    Script Date: 11/17/2009 15:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productGetProductByID]
@productID [int]
   AS
BEGIN
    SET NOCOUNT ON;

    
   SELECT [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[MakeFlag]
      ,[FinishedGoodsFlag]
      ,[Color]
      ,[SafetyStockLevel]
      ,[ReorderPoint]
      ,[StandardCost]
      ,[ListPrice]
      ,[Size]
      ,[SizeUnitMeasureCode]
      ,[WeightUnitMeasureCode]
      ,[Weight]
      ,[DaysToManufacture]
      ,[ProductLine]
      ,[Class]
      ,[Style]
      ,[ProductSubcategoryID]
      ,[ProductModelID]
      ,[SellStartDate]
      ,[SellEndDate]
      ,[DiscontinuedDate]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks].[Production].[Product]
   
   WHERE [ProductID]=@productID
   END;
GO
/****** Object:  StoredProcedure [dbo].[productGetProductByColor]    Script Date: 11/17/2009 15:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productGetProductByColor]
@color nvarchar(15)
   AS
BEGIN
    SET NOCOUNT ON;

    
   SELECT [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[MakeFlag]
      ,[FinishedGoodsFlag]
      ,[Color]
      ,[SafetyStockLevel]
      ,[ReorderPoint]
      ,[StandardCost]
      ,[ListPrice]
      ,[Size]
      ,[SizeUnitMeasureCode]
      ,[WeightUnitMeasureCode]
      ,[Weight]
      ,[DaysToManufacture]
      ,[ProductLine]
      ,[Class]
      ,[Style]
      ,[ProductSubcategoryID]
      ,[ProductModelID]
      ,[SellStartDate]
      ,[SellEndDate]
      ,[DiscontinuedDate]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks].[Production].[Product]
   
   WHERE [Color]=@color
   END;
GO
/****** Object:  StoredProcedure [dbo].[productGetAllProducts]    Script Date: 11/17/2009 15:40:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[productGetAllProducts]
   AS
BEGIN
    SET NOCOUNT ON;

    
   SELECT [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[MakeFlag]
      ,[FinishedGoodsFlag]
      ,[Color]
      ,[SafetyStockLevel]
      ,[ReorderPoint]
      ,[StandardCost]
      ,[ListPrice]
      ,[Size]
      ,[SizeUnitMeasureCode]
      ,[WeightUnitMeasureCode]
      ,[Weight]
      ,[DaysToManufacture]
      ,[ProductLine]
      ,[Class]
      ,[Style]
      ,[ProductSubcategoryID]
      ,[ProductModelID]
      ,[SellStartDate]
      ,[SellEndDate]
      ,[DiscontinuedDate]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks].[Production].[Product]
    ORDER BY [ProductID]
 
END;
GO
