/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DECLARE @goodAId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Goods
VALUES (@goodAId, 'GoodA');

DECLARE @goodBId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Goods
VALUES (@goodBId, 'GoodB');

DECLARE @goodCId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Goods
VALUES (@goodCId, 'GoodC');


DECLARE @warehouseAId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Warehouses
VALUES (@warehouseAId, 'WH1');

DECLARE @warehouseBId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Warehouses
VALUES (@warehouseBId, 'WH2');

DECLARE @warehouseCId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Warehouses
VALUES (@warehouseCId, 'WH3');

INSERT INTO GoodsWarehouses
VALUES (
	@goodAId,
	@warehouseAId,
	5
	);

INSERT INTO GoodsWarehouses
VALUES (
	@goodBId,
	@warehouseAId,
	4
	);

INSERT INTO GoodsWarehouses
VALUES (
	@goodCId,
	@warehouseAId,
	3
	);

INSERT INTO GoodsWarehouses
VALUES (
	@goodAId,
	@warehouseBId,
	10
	);

INSERT INTO GoodsWarehouses
VALUES (
	@goodBId,
	@warehouseBId,
	6
	);

INSERT INTO GoodsWarehouses
VALUES (
	@goodBId,
	@warehouseCId,
	7
	);

INSERT INTO GoodsWarehouses
VALUES (
	@goodCId,
	@warehouseCId,
	4
	);