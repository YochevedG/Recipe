create or alter procedure dbo.RecipeUpdate(
@RecipeId int output,
@cuisineId int,
@UsersId int,
@RecipeName varchar (100),
@DraftedDate DATETIME2,
@Calories int output,
@Message varchar (500) = '' output
)
as 
begin 
declare @return int = 0

select @RecipeId = isnull(@RecipeId, 0)

if @RecipeId = 0
begin 
select @Calories = max(r.Calories) +1 from recipe r 
 

insert Recipe(CuisineId, UsersId, RecipeName, DraftedDate, Calories)
values(@cuisineId, @UsersId, @RecipeName, @DraftedDate, @Calories)

select @recipeid = scope_identity()
end 
 
begin 
update Recipe 
set 
CuisineId= @cuisineid,
UsersId = @Usersid,
RecipeName = @RecipeName,
DraftedDate = @DraftedDate,
Calories = @Calories
where RecipeId = @RecipeId
end 

finished:
return @return
end  
go 

