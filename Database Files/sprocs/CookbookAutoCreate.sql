create or alter proc dbo.CookbookAutoCreate(
    @UsersId int = 0,
    @CookbookId int = 0 output,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    declare @CookbookName varchar(200)


select @CookbookName = 'Recipes by ' + u.firstname + ' ' + u.lastname
from users u 
where u.UsersId = @UsersId


insert cookbook(usersid, CookbookName, price, ActiveInactive)   
select u.usersid, @cookbookname, count(r.recipeid) * 1.33, 1
from users u 
join recipe r 
on r.usersid = u.usersid
where u.UsersId = @UsersId
group by u.lastname, u.usersid

select @cookbookid = scope_identity()

;with x as (
    select 
    cookbookname = concat('Recipes by ', u.FirstName, ' ', u.LastName),
    recipesequence = row_number() over (order by r.recipename),
    r.recipename,
    r.recipeid
    from users u
    join recipe r on r.UsersId = u.UsersId
    where u.UsersId = @UsersId

)
insert Cookbookrecipe(cookbookid, recipeid, recipesequence)
select @cookbookid, x.recipeid, x.recipesequence
from x 
join cookbook c 
on c.cookbookname = x.cookbookname
where c.cookbookid = @cookbookid


end 
go 
