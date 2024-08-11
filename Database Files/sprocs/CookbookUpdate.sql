create or alter proc dbo.CookbookUpdate(
    @CookbookId int output,
    @UsersId int,
    @Cookbookname varchar (50),
    @Price decimal,
    @DateCreated datetime, 
    @ActiveInactive bit,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0

    select @CookbookId = isnull(@CookbookId, 0)
    if @CookbookId = 0
begin 

    insert Cookbook(UsersId, CookbookName,  Price, DateCreated, ActiveInactive)
    values(@UsersId, @Cookbookname,  @Price, GETDATE(), @ActiveInactive)

    select @CookbookId = scope_identity()
end 
begin 
    update Cookbook 
    set 
    UsersId = @Usersid,
    Cookbookname = @Cookbookname,
    Price = @Price,
    DateCreated = @DateCreated,
    ActiveInactive = @ActiveInactive
    where CookbookId = @CookbookId
end
finished:
return @return
end  
go 



