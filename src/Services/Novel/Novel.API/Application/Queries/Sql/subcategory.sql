--按条件获取作品小类
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'SubCategory_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.SubCategory_Query;
GO

CREATE PROCEDURE dbo.SubCategory_Query
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.N_SubCategory AS a

	SELECT  a.Id, a.MainCategoryId, a.No, a.Name
    FROM      dbo.N_SubCategory AS a inner join
            dbo.N_MainCategory as b on a.MainCategoryId = b.Id
    ORDER BY b.No,a.No,a.CreateTime DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO

