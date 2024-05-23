CREATE OR ALTER PROCEDURE GetXmlTable
@TableName NVARCHAR(MAX)
AS
BEGIN
	SELECT XmlContent FROM XmlData WHERE Name = @TableName;
END
GO

EXEC GetXmlTable 'praca1';
GO