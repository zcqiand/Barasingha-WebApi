--报警查询
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Alarm_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Alarm_Query;
GO

CREATE PROCEDURE dbo.Alarm_Query
    @LevelId uniqueidentifier,
    @CategoryId uniqueidentifier,
    @Name varchar(100),
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.AM_Alarm AS a INNER JOIN
            dbo.AM_Category AS c ON a.CategoryId = c.Id INNER JOIN
            dbo.AM_Level AS b ON a.LevelId = b.Id
    WHERE   (@LevelId IS NULL OR a.LevelId = @LevelId) 
        AND (@CategoryId IS NULL OR a.CategoryId = @CategoryId)
        AND (@Name IS NULL OR a.Name like  '%' +@Name+ '%')

	SELECT  a.Id, a.OccurrenceTime, b.Name AS LevelName, c.Name AS CategoryName, a.Name, a.[Content], 
                a.Details, a.Count, a.State
    FROM      dbo.AM_Alarm AS a INNER JOIN
            dbo.AM_Category AS c ON a.CategoryId = c.Id INNER JOIN
            dbo.AM_Level AS b ON a.LevelId = b.Id
    WHERE   (@LevelId IS NULL OR a.LevelId = @LevelId) 
        AND (@CategoryId IS NULL OR a.CategoryId = @CategoryId)
        AND (@Name IS NULL OR a.Name like  '%' +@Name+ '%')
    ORDER BY a.OccurrenceTime DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO