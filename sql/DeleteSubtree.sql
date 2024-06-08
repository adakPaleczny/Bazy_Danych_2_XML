CREATE OR ALTER PROCEDURE DeleteSubtree 
@TableName          NVARCHAR(MAX),
@Number             NVARCHAR(MAX)
AS
BEGIN
    DECLARE @xdoc XML;
    DECLARE @sql NVARCHAR(MAX);
    DECLARE @xmlModifyStatement NVARCHAR(MAX);

    -- Retrieve the XML content from the table assuming 'Name' correctly identifies the record
    SELECT @xdoc = XmlContent FROM XmlData WHERE Name = @TableName;

    -- Construct the XML modification statement dynamically
    SET @xmlModifyStatement = 'delete /list/' + @TableName + '[' + @Number + ']';

    -- Construct the dynamic SQL for modifying the XML content
    SET @sql = N'
        DECLARE @xdoc XML = @xmlContent;
        DECLARE @exist INT;

        SET @exist = @xdoc.exist(''/list/' + @TableName + ''');

        IF @exist = 1
        BEGIN
            -- Modify the XML by deleting elements that contain the specified value in the specified attribute
            SET @xdoc.modify(''' + @xmlModifyStatement + ''');
            -- Update the XmlData table directly in the dynamic SQL
            UPDATE XmlData
            SET XmlContent = @xdoc
            WHERE Name = @TableName;
        END
        ELSE
            PRINT ''Node not found'';
    ';

    EXEC sp_executesql @sql, 
                       N'@xmlContent XML, @TableName NVARCHAR(MAX), @Number NVARCHAR(MAX)', 
                       @xdoc, @TableName, @Number;

	-- Check if stays only <list></list>
	DECLARE @Xml XML;
	SELECT @Xml = XmlContent FROM XmlData WHERE Name = @TableName;

	IF(@Xml.exist('//list/*') = 0) BEGIN
		DELETE FROM XmlData WHERE Name = @TableName;
	END

END;
GO

EXEC DeleteSubtree 'student', '1';

SELECT XmlContent from XmlData where Name = 'student';