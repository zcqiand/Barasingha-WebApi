--按条件获取作品分卷列表
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'Segment_Query' AND schema_name(uid) = 'dbo')
	DROP PROCEDURE dbo.Segment_Query;
GO

CREATE PROCEDURE dbo.Segment_Query
    @PageIndex int,
    @PageSize int,
    @Total int output
WITH ENCRYPTION
AS

    SELECT @Total = count(*) 
    FROM      dbo.N_Segment AS a

	SELECT  a.*
    FROM      dbo.N_Segment AS a
    ORDER BY a.No,a.CreateTime	
    offset ((@pageIndex-1) * @PageSize) rows
    fetch next @PageSize rows only;

GO