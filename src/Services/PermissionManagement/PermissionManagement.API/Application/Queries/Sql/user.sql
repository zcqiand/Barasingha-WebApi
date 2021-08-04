--按条件获取用户
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'User_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.User_Query;
GO

CREATE PROCEDURE dbo.User_Query
    @NickName varchar(100),
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.PM_User AS a
    WHERE   (@NickName IS NULL OR a.NickName like  '%' +@NickName+ '%')

	SELECT  a.Id, a.AvatarUrl, a.NickName, a.Gender, a.Disabled
    FROM      dbo.PM_User AS a
    WHERE  (@NickName IS NULL OR a.NickName like  '%' +@NickName+ '%')
    ORDER BY a.CreateTime DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO


--获取所有用户列表
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'User_QueryAll' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.User_QueryAll;
GO

CREATE PROCEDURE dbo.User_QueryAll
WITH ENCRYPTION
AS

	SELECT  a.Id, a.AvatarUrl, a.NickName, a.Gender, a.Disabled
    FROM      dbo.PM_User AS a
    ORDER BY a.CreateTime DESC

GO