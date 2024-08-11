create or alter proc dbo.ChangeRecipeStatus(
    @RecipeId int = 0,
    @NewStatus varchar (50),
    @Message varchar (500) = '' output
)
as 
begin 

declare @return int = 0
declare @CurrentStatus varchar(50)
select @CurrentStatus = 
case
when r.PublishedDate is null and r.ArchivedDate is null
then 'Drafted'
when r.ArchivedDate is null and r.DraftedDate is not null 
then 'Published'
when r.ArchivedDate is not null
then 'Archived'
end
from Recipe r  

if @NewStatus = 'Drafted' and @CurrentStatus = 'Published'
begin 
    update r 
    set r.DraftedDate = GETDATE(),
    r.PublishedDate = null
    from recipe r
    where r.RecipeId = @RecipeId
end 
if @NewStatus = 'Drafted' and @CurrentStatus = 'Archived'
begin 
    update r 
    set r.DraftedDate = GETDATE(),
    r.PublishedDate = null,
    r.ArchivedDate = null
    from recipe r
    where r.RecipeId = @RecipeId
end 
if @NewStatus = 'Published' and @CurrentStatus = 'Archived'
begin 
    update r 
    set r.PublishedDate = getdate(),
    r.ArchivedDate = null
    from Recipe r 
    where r.RecipeId = @RecipeId
end 
if @NewStatus = 'Published' and @CurrentStatus = 'Drafted'
begin 
    update r 
    set r.PublishedDate = getdate()
    from Recipe r 
    where r.RecipeId = @RecipeId
end 
if @NewStatus = 'Archived' and @CurrentStatus = 'Drafted'
begin
    update r 
    set r.ArchivedDate = getdate(),
    r.PublishedDate = dateadd(day,-1,getdate())
    from Recipe r 
    where r.RecipeId = @RecipeId
end
if @NewStatus = 'Archived' and @CurrentStatus = 'Published'
begin
    update r 
    set r.ArchivedDate = getdate()
    from Recipe r 
    where r.RecipeId = @RecipeId
end
finished:
return @return
end 
go

