--按条件获取角色
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Role_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Role_Query;
GO

CREATE PROCEDURE dbo.Role_Query
    @Name varchar(100),
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.PM_Role AS a
    WHERE   (@Name IS NULL OR a.Name like  '%' +@Name+ '%')

	SELECT  a.Id, a.No, a.Name
    FROM      dbo.PM_Role AS a
    WHERE  (@Name IS NULL OR a.Name like  '%' +@Name+ '%')
    ORDER BY a.CreateTime DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO


--获取所有角色列表
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Role_QueryAll' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Role_QueryAll;
GO

CREATE PROCEDURE dbo.Role_QueryAll
WITH ENCRYPTION
AS

	SELECT  a.Id, a.No, a.Name
    FROM      dbo.PM_Role AS a
    ORDER BY a.CreateTime DESC

GO