create or alter procedure dbo.RecipeGet(@RecipeId int = 0 , @All bit = 0, @RecipeName varchar(200) = '', @IncludeBlank bit = 0)
as 
begin 
    select @RecipeName = nullif(@RecipeName, '')
    select r.recipeId, r.CuisineId, r.UsersId, r.recipename, r.DraftedDate, r.PublishedDate, r.ArchivedDate, r.Calories, r.CurrentStatus, r.RecipePic,
   RecipeDesc = dbo.RecipeDesc(r.recipeid), MealCaloriesTotals = dbo.MealCaloriesTotals(mc.mealid), u.LastName, NumIngredients = count(ri.IngredientId)
    from recipe r
    left join mealcourserecipe mcr
    on mcr.recipeid = r.recipeid 
   left  join mealcourse mc 
    on mc.mealcourseid = mcr.mealcourseid
    left join Users u 
    on u.UsersId = r.UsersId
    left join RecipeIngredient ri
    on ri.RecipeId = r.RecipeId
    where r.RecipeId = @RecipeId
    or @All = 1
    or r.RecipeName like '%' + @RecipeName +'%'
    group by r.recipeId, r.CuisineId, r.UsersId, r.recipename, r.DraftedDate, r.PublishedDate, r.ArchivedDate, r.Calories, r.CurrentStatus, r.RecipePic, u.LastName, dbo.MealCaloriesTotals(mc.mealid),dbo.RecipeDesc(r.recipeid)
    union select 0, 0, 0, '', '', '', '', 0, '', '', '', 0, '', 0
    where @IncludeBlank = 1
    order by 1, r.CurrentStatus desc
end
go 

--unit tests
/*
exec RecipeGet @All = 1 
exec RecipeGet 

declare @id int
select top 1@id = r.recipeid from recipe r

exec RecipeGet @RecipeId = @id
*/
