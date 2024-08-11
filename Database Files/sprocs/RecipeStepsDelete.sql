create or alter proc dbo.RecipeStepsDelete(
    @RecipeStepsId int = 0,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeStepsid = isnull(@RecipeStepsId, 0)

    delete RecipeSteps where RecipeStepsId = @RecipeStepsId
    return @return
end 
go 