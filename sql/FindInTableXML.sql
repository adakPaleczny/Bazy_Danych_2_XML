CREATE OR ALTER PROCEDURE FindInTableXML
    @TableName NVARCHAR(MAX),
    @Attribute NVARCHAR(MAX),
    @Value NVARCHAR(MAX)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);
    
    SET @sql = N'
		SELECT 
			Element.exist(''./*[local-name() = sql:variable("@Attribute") and contains(text()[1], sql:variable("@Value"))]'') AS ElementExists,
			XmlContent
		FROM 
			XmlData
			CROSS APPLY XmlContent.nodes(''/list/' + @TableName + ''') AS A(Element);
		';


    -- Execute the dynamic SQL
    EXEC sp_executesql @sql, N'@Attribute NVARCHAR(MAX), @Value NVARCHAR(MAX)', @Attribute, @Value;
END;
GO

EXEC FindInTableXML
    @TableName = 'student',
    @Attribute = 'imie',
    @Value = 'Adam';
GO

