create or alter proc dbo.UsersUpdate(
    @UsersId int output,
    @FirstName varchar (200),
    @LastName varchar (200),
    @UserName varchar (200),
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0

    select @UsersId = isnull(@UsersId, 0)
    if @UsersId = 0
    begin 
    
    insert Users(FirstName, LastName, UserName)
    values(@LastName, @LastName, @UserName)

    select @UsersId = scope_identity()
end 
begin 
update Users 
set 
FirstName = @FirstName,
LastName = @LastName,
UserName = @UserName
where UsersId = @UsersId
end
finished:
return @return
end  
go

