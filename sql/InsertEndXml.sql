CREATE OR ALTER PROCEDURE InsertEndXml
@TableName				NVARCHAR(MAX),
@ElementName			NVARCHAR(MAX),
@Value					NVARCHAR(MAX)
AS
BEGIN
	DECLARE @SQL NVARCHAR(MAX);
	DECLARE @xdoc XML;

    -- Select the name value securely, ensuring input parameter safety
	SELECT @xdoc = XmlContent FROM XmlData WHERE Name = @TableName;

    -- Check if @Name is not NULL to proceed with the SQL generation
    IF @xdoc IS NOT NULL
    BEGIN
       -- Construct the dynamic SQL query. Now extracting and working with VARCHAR instead of XML directly.
       SET @SQL = '
	DECLARE @xdoc XML = @xmlContent;
       SET @xdoc.modify(''insert <'+@ElementName+'> '+ @Value+' </' + @ElementName + '> as last into (/list/' + @TableName+')[1]'')
	
	  -- Update the XmlData table directly in the dynamic SQL
       UPDATE XmlData
       SET XmlContent = @xdoc
       WHERE Name = '''+ @TableName+''';
       ';
	
       -- Execute the dynamic SQL query
       EXEC sp_executesql @sql, 
                      N'@xmlContent XML', 
                      @xdoc;
    END
    ELSE
    BEGIN
        -- Handle the case where no matching name is found
        PRINT 'No matching element found for the specified name.';
    END

END
GO

EXEC InsertEndXml 'student', 'rok', '2';
GO

SELECT * FROM XmlData where Name = 'student';