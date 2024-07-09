create or alter procedure dbo.RecipeUpdate(
    @RecipeId int output,
    @cuisineId int,
    @UsersId int,
    @RecipeName varchar (100),
    @DraftedDate datetime2 output,
    @Calories int output,
    @Message varchar (500) = '' output
)
as 
begin 
declare @return int = 0

select @RecipeId = isnull(@RecipeId, 0)

if @RecipeId = 0
begin 

    insert Recipe(CuisineId, UsersId, RecipeName,  Calories)
    values(@cuisineId, @UsersId, @RecipeName,  @Calories)

    select @recipeid = scope_identity()
end 
 
begin 
    update Recipe 
    set 
    CuisineId= @cuisineid,
    UsersId = @Usersid,
    RecipeName = @RecipeName,
    Calories = @Calories
    where RecipeId = @RecipeId
end 

finished:
return @return
end  
go 

