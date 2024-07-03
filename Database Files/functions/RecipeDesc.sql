create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar (250)
as 
begin
    declare @value varchar (250) = ''

select @value =concat(r.recipename, ' (', c.cuisinetype, ') has ',
(select count(*) from recipeingredient ri where ri.recipeid = r.recipeid), ' ingredients and ',
(select count(*) from recipesteps rs where r.recipeid = rs.recipeid), ' steps.')
from recipe r
join Cuisine c 
on c.cuisineid = r.cuisineid
where r.recipeid = @recipeid

return @value
end 
go 

select RecipeDesc = dbo.RecipeDesc(r.recipeid), r.*
from recipe r

