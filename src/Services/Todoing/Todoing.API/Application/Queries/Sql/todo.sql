--按条件获取待办事项
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Todo_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Todo_Query;
GO

CREATE PROCEDURE dbo.Todo_Query
    @Name varchar(100),
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.T_Todo AS a
    WHERE   (@Name IS NULL OR a.Name like  '%' +@Name+ '%')

	SELECT  a.Id, a.Name
    FROM      dbo.T_Todo AS a
    WHERE  (@Name IS NULL OR a.Name like  '%' +@Name+ '%')
    ORDER BY a.Id DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO