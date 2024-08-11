create or alter proc dbo.RecipeIngredientGet(
    @RecipeIngredientId int = 0,
    @RecipeId int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output,
    @IncludeBlank bit = 0
)
as 
begin 
    declare @return int = 0

    select @All = isnull(@all, 0), @RecipeingredientId = isnull(@RecipeIngredientId, 0), @recipeid = isnull(@recipeid, 0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select ri.RecipeIngredientid, ri.recipeid, ri.IngredientId,  ri.MeasurementTypeid, m.MeasurementType, ri.measurementamount, ri.IngredientSequence
    from RecipeIngredient ri
    join MeasurementType m 
    on m.MeasurementTypeId = ri.MeasurementTypeId
    where ri.RecipeIngredientid = @RecipeingredientId
    or @All = 1
    or ri.recipeid = @recipeid
    union SELECT 0, 0, 0, 0, ' ', ' ', 0
    where @IncludeBlank = 1
    

    return @return
end 
go 
