create or alter proc dbo.CuisineDelete(
    @CuisineId int = 0,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CuisineId = isnull(@CuisineId, 0)

    delete ri 
    from RecipeIngredient ri 
    join recipe r
    on ri.RecipeId = r.RecipeId
    join Cuisine c 
    on r.CuisineId = c.CuisineId
    where c.CuisineId = @CuisineId

    delete rs 
    from RecipeSteps rs 
    join Recipe r 
    on rs.RecipeId = r.RecipeId
    join Cuisine c 
    on r.CuisineId = c.CuisineId
    where c.CuisineId = @CuisineId

    delete mcr 
    from MealCourseRecipe mcr 
    join recipe r 
    on r.RecipeId = mcr.RecipeId
    join Cuisine c 
    on r.CuisineId = c.CuisineId
    where c.CuisineId = @CuisineId
    
    delete cr 
    from CookbookRecipe cr 
    join Recipe r 
    on cr.RecipeId = r.RecipeId
    join Cuisine c 
    on r.CuisineId = c.CuisineId
    where c.CuisineId = @CuisineId

    delete  r
    from Recipe r 
    join cuisine c 
    on c.CuisineId = r.CuisineId
   where c.CuisineId = @CuisineId

    delete  c
    from Cuisine c
    where c.CuisineId = @CuisineId

    return @return
end 
go 