--按条件获取作品章节列表
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Chapter_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Chapter_Query;
GO

CREATE PROCEDURE dbo.Chapter_Query
    @StartUpdateTime datetime,
    @EndUpdateTime datetime,
    @Name varchar(100),
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.N_Chapter AS a
    WHERE   (@Name IS NULL OR a.Name like  '%' +@Name+ '%') and UpdateTime >= @StartUpdateTime and UpdateTime < @EndUpdateTime

	SELECT  a.*
    FROM      dbo.N_Chapter AS a
    WHERE   (@Name IS NULL OR a.Name like  '%' +@Name+ '%') and UpdateTime >= @StartUpdateTime and UpdateTime < @EndUpdateTime
    ORDER BY a.No,a.UpdateTime
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO