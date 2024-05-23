CREATE OR ALTER PROCEDURE FetchXmlData
@Element NVARCHAR(MAX)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @Name NVARCHAR(MAX);

    -- Select the name value securely, ensuring input parameter safety
    SELECT TOP 1 @Name = Name FROM dbo.XmlData WHERE Name = @Element;

    -- Check if @Name is not NULL to proceed with the SQL generation
    IF @Name IS NOT NULL
    BEGIN
        -- Construct the dynamic SQL query. Now extracting and working with VARCHAR instead of XML directly.
        SET @SQL = '
        SELECT DISTINCT
            student.value(''local-name(.)'', ''NVARCHAR(MAX)'') AS ElementName
        FROM dbo.XmlData
        CROSS APPLY XmlContent.nodes(''/list/' + @Name + '/*'') AS x(student);
        ';

        -- Execute the dynamic SQL query
        EXEC sp_executesql @SQL;
    END
    ELSE
    BEGIN
        -- Handle the case where no matching name is found
        PRINT 'No matching element found for the specified name.';
    END
END
GO

-- Execute the procedure with a specific element name
EXEC FetchXmlData 'student';
