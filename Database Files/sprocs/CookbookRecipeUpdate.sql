create or alter proc dbo.CookbookRecipeUpdate(
    @CookbookRecipeId int output,
    @CookbookId int,
    @RecipeId int,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CookbookRecipeId = isnull(@CookbookRecipeId, 0)

    if @CookbookRecipeId = 0 
    begin 
        insert CookbookRecipe(CookbookId, RecipeId)
        values (@CookbookId, @RecipeId)

        select @CookbookRecipeId = scope_identity()
    end 
    else 
    begin 
        update CookbookRecipe
        set 
            CookbookId = @CookbookId,
            RecipeId = @RecipeId
            where cookbookrecipeid = @CookbookRecipeId
    end 

    return @return
end 
go 