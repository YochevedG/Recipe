create or alter proc dbo.CookbookRecipeGet(
    @CookbookRecipeId int = 0,
    @CookbookId int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output
)
as  
begin 
    declare @return int = 0

    select @All = isnull(@All, 0), @CookbookRecipeId = isnull(@CookbookRecipeId,0), @CookbookId = isnull(@CookbookId, 0)

    select cr.cookbookrecipeid, cr.cookbookid, cr.RecipeId, r.recipename, cr.recipesequence
    from cookbookrecipe cr
    join recipe r 
    on cr.recipeid = r.recipeid
    where cr.cookbookrecipeid = @CookbookRecipeId
    or @All = 1
    or cr.cookbookid = @cookbookid

    return @return
end 
go 


