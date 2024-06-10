declare @RecipeId int 

select top 1 @RecipeId = r.recipeid
from Recipe r 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
order by r.RecipeId

select * from Recipe r where r.RecipeId = @RecipeId

exec RecipeDelete @RecipeId = @RecipeId

select * from Recipe r where r.RecipeId = @RecipeId

