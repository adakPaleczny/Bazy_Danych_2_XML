CREATE OR ALTER PROCEDURE InsertIndexXml
@TableName               NVARCHAR(MAX),
@ElementName             NVARCHAR(MAX),
@Value                   NVARCHAR(MAX),
@Number                  INT
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @xdoc XML;
    DECLARE @Exist INT;
    DECLARE @xpath NVARCHAR(MAX);

    -- Select the XML content securely
    SELECT @xdoc = XmlContent FROM XmlData WHERE Name = @TableName;

    IF @xdoc IS NOT NULL
    BEGIN
        -- Construct the XPath expression dynamically
        SET @xpath = '/list/' + @TableName + '[' + CAST(@Number AS NVARCHAR(10)) + ']';

        -- Construct the dynamic SQL to check existence
        SET @SQL = '
SET @Exist = (SELECT @xmlContent.exist(''' + @xpath + '''));
';

        -- Execute the dynamic SQL to get the existence status
        EXEC sp_executesql @SQL,
                           N'@xmlContent XML, @Exist INT OUTPUT',
                           @xmlContent = @xdoc,
                           @Exist = @Exist OUTPUT;

        -- Check if the element exists
        IF @Exist = 1
        BEGIN
            -- Construct the dynamic SQL to insert the new element
            SET @SQL = '
DECLARE @xdoc XML = @xmlContent;
SET @xdoc.modify(''insert <' + @ElementName + '>' + @Value + '</' + @ElementName + '> as last into (' + @xpath + ')[1]'');
-- Update the XmlData table
UPDATE XmlData
SET XmlContent = @xdoc
WHERE Name = @TableName;
';

            -- Execute the dynamic SQL query
            EXEC sp_executesql @SQL,
                               N'@xmlContent XML, @TableName NVARCHAR(MAX)',
                               @xmlContent = @xdoc, @TableName = @TableName;
        END
        ELSE
        BEGIN
            -- Handle the case where no matching name is found
            PRINT 'No matching element found for the specified name.';
        END
    END
    ELSE
    BEGIN
        PRINT 'No XML content found for the specified table name.';
    END
END
GO


EXEC InsertIndexXml 'praca', 'liczba_kobiet', '20', 2;
GO

SELECT * FROM XmlData where Name = 'praca';