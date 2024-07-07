create or alter procedure dbo.RecipeGet(@RecipeId int = 0 , @All bit = 0, @RecipeName varchar(200) = '')
as 
begin 
    select @RecipeName = nullif(@RecipeName, '')
    select r.recipeid, r.CuisineId, r.UsersId, r.recipename, r.DraftedDate, r.PublishedDate, r.ArchivedDate, r.Calories, r.CurrentStatus, r.RecipePic,
   RecipeDesc = dbo.RecipeDesc(r.recipeid), MealCaloriesTotals = dbo.MealCaloriesTotals(mc.mealid)
    from recipe r
    join mealcourserecipe mcr
    on mcr.recipeid = r.recipeid 
    join mealcourse mc 
    on mc.mealcourseid = mcr.mealcourseid
    where r.RecipeId = @RecipeId
    or @All = 1
    or r.RecipeName like '%' + @RecipeName +'%'
    order by r.RecipeName, r.DraftedDate
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

