create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar (250)
as 
begin
    declare @value varchar (250) = ''

    select @value = concat(r.recipename, ' (', c.cuisinetype, ') ', 'has ', count(ri.ingredientid) ,' ingredients and ', count(rs.RecipeStepsId), ' steps.' )
    from recipe r 
left join cuisine c 
on c.cuisineid = r.cuisineid
left join recipeingredient ri 
on ri.recipeid = r.recipeid
left join recipesteps rs 
on rs.recipeid = r.recipeid
where r.recipeid = @recipeid
group by r.recipename, c.cuisineType

return @value
end 
go 

select PresidentDesc = dbo.PresidentDesc(r.recipeid), r.*
from recipe r

select  r.recipename, c.cuisinetype, count(ri.ingredientid), count(rs.RecipeStepsId)
from recipe r 
left join cuisine c 
on c.cuisineid = r.cuisineid
left join recipeingredient ri 
on ri.recipeid = r.recipeid
left join recipesteps rs 
on rs.recipeid = r.recipeid
group by r.recipename, c.cuisineType


select * from recipesteps