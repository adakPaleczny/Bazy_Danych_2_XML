CREATE OR ALTER PROCEDURE DeleteValues
    @TABLE NVARCHAR(MAX),  -- This parameter is not used dynamically in XPath for safety reasons.
    @ATTRIBUTE NVARCHAR(MAX),
    @VALUE NVARCHAR(MAX)
AS
BEGIN
    DECLARE @xdoc XML;
    DECLARE @sql NVARCHAR(MAX);
    
    -- Retrieve the XML content from the table assuming 'Name' correctly identifies the record
    SELECT @xdoc = XmlContent FROM XmlData WHERE Name = @TABLE;
    -- Construct the dynamic SQL for modifying the XML content
    SET @sql = N'
        DECLARE @xdoc XML = @xmlContent;

        -- Modify the XML by deleting elements that contain the specified value in the specified attribute
        SET @xdoc.modify(''delete /list/'+@TABLE+'[' + @ATTRIBUTE + '[contains(., sql:variable("@VALUE"))]]'');

        -- Update the XmlData table directly in the dynamic SQL
        UPDATE XmlData
        SET XmlContent = @xdoc
        WHERE Name = @TABLE ;

    ';

    -- Execute the dynamic SQL passing necessary parameters
    EXEC sp_executesql @sql, 
                       N'@xmlContent XML, @TABLE NVARCHAR(MAX), @VALUE NVARCHAR(MAX)', 
                       @xdoc, @TABLE, @VALUE;
END;
GO

-- Example execution: Change parameters as needed based on actual use cases
EXEC DeleteValues
    @TABLE = 'student',
    @ATTRIBUTE = 'imie',
    @VALUE = 'Adam';
GO

-- Check the result
SELECT * FROM XmlData;
