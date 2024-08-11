create or alter procedure dbo.UsersGet(@UsersId int = 0 , @All bit = 0, @LastName varchar(50) = '', @IncludeBlank bit = 0)
as 
begin 
    select @LastName = nullif(@LastName, '')
    select u.UsersId, u.FirstName, u.LastName, u.UserName
    from Users u 
    where u.UsersId = @UsersId
    or @All = 1
    or u.LastName like '%' + @LastName +'%'
    union select 0, '', '', ''
    where @IncludeBlank = 1
    order by u.LastName, u.FirstName
end
go 

--unit tests
/*
exec UsersGet @All = 1 
exec UsersGet 

declare @id int
select top 1@id = u.usersid from users u

exec UsersGet @UsersId = @id
*/
