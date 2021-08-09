--按条件获取作品
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Book_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Book_Query;
GO

CREATE PROCEDURE dbo.Book_Query
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.N_Book AS a

	SELECT  a.Id, b.Name AS SubCategoryName, a.Logo, a.Name, a.AuthorId, a.Introduction, a.WordCount,      a.Favorites,a.BookStatus, a.SerialStatus
    FROM    dbo.N_Book AS a INNER JOIN
        dbo.N_SubCategory AS b ON a.SubCategoryId = b.Id
    ORDER BY a.CreateTime DESC	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO