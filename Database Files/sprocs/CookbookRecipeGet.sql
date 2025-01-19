create or alter proc dbo.CookbookRecipeGet(
    @CookbookRecipeId int = 0,
    @CookbookId int = 0,
    @cookbookname varchar (50) = '',
    @All bit = 0,
    @Message varchar (500) = '' output
)
as  
begin 
    declare @return int = 0

    select @All = isnull(@All, 0), @CookbookRecipeId = isnull(@CookbookRecipeId,0), @CookbookId = isnull(@CookbookId, 0)

    select cr.cookbookrecipeid, cr.cookbookid, cr.RecipeId, r.recipename, cr.recipesequence, r.currentstatus, r.Vegan, u.lastname, r.Calories, NumIngredients = count(ri.IngredientId)
    from cookbookrecipe cr
    left join recipe r 
    on cr.recipeid = r.recipeid
    left join Cookbook c 
    on c.CookbookId = cr.CookbookId
    left join users u 
    on u.UsersId = r.UsersId
    join RecipeIngredient ri 
    on ri.RecipeId = r.RecipeId
    where (@all = 1) or 
     (cr.cookbookrecipeid = @CookbookRecipeId)
     or (cr.CookbookId = @cookbookid)
     or c.cookbookname like '%' + @cookbookname + '%'
    group by cr.cookbookrecipeid, cr.cookbookid, cr.RecipeId, r.recipename, cr.recipesequence, r.currentstatus, r.Vegan, u.lastname, r.Calories

     order by cr.RecipeSequence
    return @return
end 
go 
exec CookbookRecipeGet @all = 1

