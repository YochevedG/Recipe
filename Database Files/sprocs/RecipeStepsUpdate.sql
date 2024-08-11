create or alter proc dbo.RecipeStepsUpdate(
    @RecipeStepsId int output,
    @RecipeId int,
    @instructions varchar (1000) = '',
    @stepssequence int,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @RecipeStepsId = isnull(@RecipeStepsId, 0)

    if @recipeStepsid = 0 
    begin 
        insert RecipeSteps(RecipeId, Instructions, StepsSequence)
        values (@RecipeId, @instructions, @stepssequence)

        select @RecipeStepsId = scope_identity()
    end 
    else 
    begin 
        update RecipeSteps
        set 
            RecipeId = @recipeid,
            Instructions = @instructions,
            StepsSequence = @stepssequence
            where recipeStepsid = @recipeStepsid
    end 

    return @return
end 
go 