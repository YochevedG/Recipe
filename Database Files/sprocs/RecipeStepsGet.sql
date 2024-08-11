create or alter proc dbo.RecipeStepsGet(
    @RecipeStepsId int = 0,
    @RecipeId int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output,
    @IncludeBlank bit = 0
)
as 
begin 
    declare @return int = 0

    select @all = isnull(@All, 0), @RecipeStepsId = isnull(@RecipeStepsId, 0), @recipeid = isnull(@recipeid, 0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select rs.RecipeStepsid, rs.recipeid, rs.Instructions, rs.StepsSequence
    from RecipeSteps rs
    where rs.RecipeStepsid = @RecipeStepsId
    or @All = 1
    or rs.recipeid = @recipeid
    union SELECT 0, 0, ' ', 0 
    where @IncludeBlank = 1
    

    return @return
end 
go 