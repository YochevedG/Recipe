create or alter proc dbo.StatusGet(
    @StatusId int = 0,
    @RecipeId int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output
)
as 
begin 

    declare @return int = 0

    select @All = isnull(@All, 0), @RecipeId = isnull(@RecipeId, 0), @All = isnull(@All, 0)

    select r.currentstatus
    from recipe r
    where r.recipeid = @statusid
    or @all = 1

return @return
end
go 