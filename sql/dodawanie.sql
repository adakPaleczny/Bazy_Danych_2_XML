CREATE OR ALTER PROCEDURE AddXMLToDB 
    @FileName NVARCHAR(255),
    @DirectoryPath NVARCHAR(255)
AS
BEGIN
    DECLARE @FilePath NVARCHAR(4000);
    DECLARE @TableName NVARCHAR(MAX);
    DECLARE @SQL NVARCHAR(MAX);

    -- Construct the full file path
    SET @FilePath = @DirectoryPath + @FileName;
    SET @TableName = REPLACE(@FileName, '.xml', '');

    -- Print the file path for debugging
    PRINT 'FilePath: ' + @FilePath;

    -- Insert XML data from the specified file into the XmlData table
    SET @SQL = '
		DELETE FROM XmlData WHERE Name = ''' + @TableName + '''
        INSERT INTO XmlData (Name, XmlContent)
        SELECT ''' + @TableName + ''', XmlContent
        FROM OPENROWSET(
            BULK ''' + REPLACE(@FilePath, '''', '''''') + ''',
            SINGLE_BLOB) AS x(XmlContent)';

    PRINT 'SQL: ' + @SQL; -- For debugging, print the SQL statement
    EXEC sp_executesql @SQL;
    PRINT 'ELEMENT ADDED';
END;
GO


-- Example usage
EXECUTE AddXMLToDB 'student.xml', 'C:\Users\Administrator\Desktop\BD2\projekt\';
GO

SELECT * FROM XmlData;

DELETE FROM XmlData WHERE Name = 'student';
