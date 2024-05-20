DECLARE @Name NVARCHAR(MAX);
DECLARE @SQL NVARCHAR(MAX);

-- Select the name value
SELECT TOP 1 @Name = Name FROM dbo.XmlData;
PRINT @Name;
-- Construct the dynamic SQL query
SET @SQL = '
SELECT 
    x.student.query(''.'') AS StudentXml
FROM dbo.XmlData
CROSS APPLY XmlContent.nodes(''/list/' + @Name + ''') AS x(student);
';

-- Execute the dynamic SQL query
EXEC sp_executesql @SQL, N'@Name NVARCHAR(MAX)', @Name;

