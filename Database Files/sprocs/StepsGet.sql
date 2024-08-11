create or alter proc dbo.StepsGet(
    @StepsId int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output,
    @IncludeBlank bit = 0
)
as
begin 
    declare @return int = 0 

    select @All = isnull(@All, 0), @StepsId = isnull(@StepsId, 0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select rs.recipestepsid, rs.instructions
    from recipesteps rs
    where rs.recipestepsid = @stepsid
    or @All = 1
    union SELECT 0, ' '
    where @IncludeBlank = 1
    
return @return
end 
go 

