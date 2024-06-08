CREATE OR ALTER PROCEDURE ReplaceXML
    @TABLE NVARCHAR(MAX),
    @ATTRIBUTE NVARCHAR(MAX),
    @VALUE NVARCHAR(MAX),
    @NEWVALUE NVARCHAR(MAX)
AS
BEGIN
    -- Declare local variables
    DECLARE @xdoc XML;
    DECLARE @sql NVARCHAR(MAX);

    -- Retrieve the XML content from the table
    SELECT @xdoc = XmlContent FROM XmlData WHERE Name = @TABLE;

    -- Construct the dynamic SQL for modifying the XML content
    -- Ensure safe use of table name in dynamic SQL by using QUOTENAME
    SET @sql = N'
        DECLARE @xdoc XML = @xmlContent;

        -- Using modify() to replace content dynamically with whitespace consideration
        SET @xdoc.modify(''replace value of (/list/' + @TABLE + '/' + @ATTRIBUTE + '[contains(text()[1], sql:variable("@VALUE"))]/text())[1] with sql:variable("@NEWVALUE")'');

        -- Update the XmlData table directly in the dynamic SQL
        UPDATE XmlData
        SET XmlContent = @xdoc
        WHERE Name = @TABLE;
    ';

    -- Prepare parameters for sp_executesql to handle dynamic SQL execution
    EXEC sp_executesql @sql, 
                       N'@xmlContent XML, @TABLE NVARCHAR(MAX), @VALUE NVARCHAR(MAX), @NEWVALUE NVARCHAR(MAX)', 
                       @xdoc, @TABLE, @VALUE, @NEWVALUE;
END
GO


-- Call the stored procedure to update XML data
EXEC ReplaceXML
    @TABLE = 'student',
    @ATTRIBUTE = 'imie',
    @VALUE = 'Karol',
    @NEWVALUE = 'Adam';
GO

SELECT * FROM XmlData;