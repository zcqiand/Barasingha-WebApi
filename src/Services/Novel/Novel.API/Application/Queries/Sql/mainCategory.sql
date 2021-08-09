--按条件获取作品类别列表
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'MainCategory_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.MainCategory_Query;
GO

CREATE PROCEDURE dbo.MainCategory_Query
    @Name varchar(100),
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.N_MainCategory AS a
    WHERE   (@Name IS NULL OR a.Name like  '%' +@Name+ '%')

	SELECT  a.Id, a.No, a.Name
    FROM      dbo.N_MainCategory AS a
    WHERE  (@Name IS NULL OR a.Name like  '%' +@Name+ '%')
    ORDER BY a.No,a.CreateTime DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO