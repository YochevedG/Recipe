create or alter proc dbo.CookbookDelete(
    @CookbookId int = 0,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CookbookId = isnull(@CookbookId, 0)

    delete Cookbook where CookbookId = @CookbookId
    return @return
end 
go 
