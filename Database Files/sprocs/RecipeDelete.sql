create or alter procedure dbo.RecipeDelete(
    @RecipeId int,
    @Message varchar (500) = '' output
)
as
begin 
declare @return int = 0 
if exists(select * from Recipe r where (r.CurrentStatus <> 'Drafted' and  DATEDIFF(day, r.ArchivedDate, CURRENT_TIMESTAMP) <= 30) and r.RecipeId = @RecipeId)
begin 
select @return = 1, @Message = 'A user can only delete a recipe if the recipe is archived for over 30 days or is currently drafted'
    goto finished
end 


begin try 
    begin tran
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
