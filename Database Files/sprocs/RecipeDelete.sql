create or alter procedure dbo.RecipeDelete(
    @RecipeId int,
    @Message varchar (500) = '' output
)
as
begin 
declare @return int = 0 
if exists(select * from Recipe r where (r.CurrentStatus = 'Drafted' or  DATEDIFF(day, r.ArchivedDate, CURRENT_TIMESTAMP) > 30) and r.RecipeId = @RecipeId)
begin 
select @return = 1, @Message = 'Cannot delete recipe that is drafted or archived for more than 30 days'
    goto finished
end 


begin try 
    begin tran
    delete Ingredient from Ingredient i join RecipeIngredient ri on ri.IngredientId = i.IngredientId where recipeid = @RecipeId
    delete RecipeIngredient where RecipeId = @RecipeId
    delete RecipeSteps where RecipeId = @RecipeId
    delete Recipe where RecipeId = @RecipeId
    commit
    end try 
    begin catch 
        rollback ;
        throw 
        end catch

        finished:
        return @return
end
go

select * from Recipe r where r.CurrentStatus = 'Drafted' or  DATEDIFF(day, r.ArchivedDate, CURRENT_TIMESTAMP) > 30 