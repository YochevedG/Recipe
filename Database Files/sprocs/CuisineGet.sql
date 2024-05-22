create or alter procedure dbo.CuisineGet(@CuisineId int = 0 , @All bit = 0, @CuisineType varchar(50) = '')
as 
begin 
    select @CuisineType = nullif(@CuisineType, '')
    select c.cuisineid, c.cuisinetype
    from Cuisine c
    where c.cuisineid = @CuisineId
    or @All = 1
    or c.cuisineType like '%' + @CuisineType +'%'
    order by c.cuisinetype
end
go 

--unit tests
/*
exec CuisineGet @All = 1 
exec CuisineGet

declare @id int
select top 1@id = c.cuisineid from cuisine c

exec CuisineGet @CuisineId = @id
*/
