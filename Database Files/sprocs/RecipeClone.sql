create or alter proc dbo.RecipeClone(
    @RecipeId int = null output,
    @NewRecipeId int output,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

     declare @CuisineId int,
            @UsersId int,
            @RecipeName varchar(100),
            @Calories int,
            @DraftedDate datetime,
            @PublishedDate datetime,
            @ArchivedDate datetime 

    select @CuisineId = CuisineId,
           @UsersId = UsersId,
           @RecipeName = RecipeName,
           @Calories = Calories,
           @DraftedDate  = DraftedDate,
           @PublishedDate = PublishedDate,
           @ArchivedDate = ArchivedDate

from recipe 
where recipeid = @recipeid 

if @Recipename is null  
begin 
    return @return
end 
set @RecipeName = @RecipeName + ' - Clone'
insert Recipe(CuisineId, UsersId, RecipeName, Calories, DraftedDate, PublishedDate, ArchivedDate)
values(@CuisineId, @UsersId, @RecipeName, @Calories, @DraftedDate, @PublishedDate, @ArchivedDate)

select @NewRecipeId = scope_identity()

    insert  RecipeIngredient (RecipeId, IngredientId, MeasurementTypeId, MeasurementAmount, IngredientSequence)
    select @NewRecipeId, IngredientId, MeasurementTypeId, MeasurementAmount, IngredientSequence
    from RecipeIngredient
    where RecipeId = @RecipeId;
    insert RecipeSteps(RecipeId, Instructions, StepsSequence)
    select @NewRecipeId, Instructions, StepsSequence
    from RecipeSteps
    where RecipeId = @RecipeId;

end 
go 

