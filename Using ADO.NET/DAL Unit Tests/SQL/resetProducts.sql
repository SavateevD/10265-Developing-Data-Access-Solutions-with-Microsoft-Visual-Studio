﻿DELETE  FROM [Production].[Product]
WHERE [Product].[ProductID] >0



SET IDENTITY_INSERT [Production].[Product] ON
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (1, N'Adjustable Race', N'AR-5381', 0, 0, NULL, 1000, 750, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'694215b7-08f7-4c0d-acb1-d734ba44c0c8', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (2, N'Bearing Ball', N'BA-8327', 0, 0, NULL, 1000, 750, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'58ae3c20-4f3a-4749-a7d4-d568806cc537', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (3, N'BB Ball Bearing', N'BE-2349', 1, 0, NULL, 800, 600, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'9c21aed2-5bfa-4f18-bcb8-f11638dc2e4e', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (4, N'Headset Ball Bearings', N'BE-2908', 0, 0, NULL, 800, 600, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'ecfed6cb-51ff-49b5-b06c-7d8ac834db8b', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (316, N'Blade', N'BL-2036', 1, 0, NULL, 800, 600, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'e73e9750-603b-4131-89f5-3dd15ed5ff80', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (317, N'LL Crankarm', N'CA-5965', 0, 0, N'Black', 500, 375, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, N'L ', NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'3c9d10b7-a6b2-4774-9963-c19dcee72fea', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (318, N'ML Crankarm', N'CA-6738', 0, 0, N'Black', 500, 375, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, N'M ', NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'eabb9a92-fa07-4eab-8955-f0517b4a4ca7', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (319, N'HL Crankarm', N'CA-7457', 0, 0, N'Black', 500, 375, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'7d3fd384-4f29-484b-86fa-4206e276fe58', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (320, N'Chainring Bolts', N'CB-2903', 0, 0, N'Silver', 1000, 750, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'7be38e48-b7d6-4486-888e-f53c26735101', CAST(0x000094A700A53CF8 AS DateTime))
INSERT [Production].[Product] ([ProductID], [Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], [Color], [SafetyStockLevel], [ReorderPoint], [StandardCost], [ListPrice], [Size], [SizeUnitMeasureCode], [WeightUnitMeasureCode], [Weight], [DaysToManufacture], [ProductLine], [Class], [Style], [ProductSubcategoryID], [ProductModelID], [SellStartDate], [SellEndDate], [DiscontinuedDate], [rowguid], [ModifiedDate]) VALUES (321, N'Chainring Nut', N'CN-6137', 0, 0, N'Silver', 1000, 750, 0.0000, 0.0000, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x00008C6900000000 AS DateTime), NULL, NULL, N'3314b1d7-ef69-4431-b6dd-dc75268bd5df', CAST(0x000094A700A53CF8 AS DateTime))
SET IDENTITY_INSERT [Production].[Product] OFF
