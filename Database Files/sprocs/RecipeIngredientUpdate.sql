create or alter proc dbo.RecipeIngredientUpdate(
    @RecipeIngredientId int output,
    @RecipeId int,
    @IngredientId int,
    @MeasurementTypeId int,
    @MeasurementAmount int,
    @IngredientSequence int,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeIngredientId = isnull(@RecipeIngredientId, 0)

    if @recipeingredientid = 0 
    begin 
        insert RecipeIngredient(RecipeId, IngredientId, MeasurementTypeId, MeasurementAmount, IngredientSequence)
        values (@RecipeId, @IngredientId, @MeasurementTypeId, @MeasurementAmount, @IngredientSequence)

        select @RecipeIngredientId = scope_identity()
    end 
    else 
    begin 
        update recipeingredient
        set 
            RecipeId = @recipeid,
            Ingredientid = @ingredientId,
            MeasurementTypeId = @MeasurementTypeId,
            MeasurementAmount = @MeasurementAmount,
            IngredientSequence = @IngredientSequence
            where recipeingredientid = @recipeingredientid
    end 

    return @return
end 
go 
