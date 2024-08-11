create or alter proc dbo.CookbookGet(
    @CookbookId int = 0,
    @All bit = 0,
    @CookbookName varchar (50) = '' output
)
as 
begin 
    select @cookbookname = nullif(@cookbookname, '')
    select c.cookbookId, c.UsersId, c.CookbookName, Author = concat(u.firstname, ' ',  u.lastname), NumRecipes = count(r.RecipeId), c.price, c.DateCreated, c.ActiveInactive
    from cookbook c 
    left join users u 
    on u.UsersId = c.UsersId
    join CookbookRecipe cr 
    on cr.CookbookId = c.CookbookId
    join recipe r 
    on r.RecipeId = cr.RecipeId
    where c.CookbookId = @CookbookId
    or @All = 1 
    group by  c.UsersId, u.firstname, u.lastname, c.cookbookId, c.CookbookName, c.price,c.DateCreated, c.ActiveInactive
    order by c.cookbookname
end
go

exec CookbookGet @all = 1
