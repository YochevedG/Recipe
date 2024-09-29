create or alter proc dbo.IngredientGet(
    @IngredientId int = 0,
    @IngredientName varchar = '',
    @All bit = 0,
    @Message varchar (500) = '' output,
    @IncludeBlank bit = 0
)
as
begin 
    declare @return int = 0 

    select @All = isnull(@All, 0), @IngredientId = isnull(@IngredientId, 0), @IncludeBlank = ISNULL(@IncludeBlank,0),@IngredientName = nullif(@IngredientName, '')

    select i.ingredientid, i.ingredientname
    from ingredient i
    where i.ingredientid = @ingredientid
    or @All = 1
     or i.IngredientName like '%' + @IngredientName + '%'
    union SELECT 0, ' '
    where @IncludeBlank = 1
    order by i.IngredientName

    return @return
end 
go 

select * from Ingredient

