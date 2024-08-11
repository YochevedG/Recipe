create or alter proc dbo.CourseGet(
    @CourseId int = 0,
    @All bit = 0,
    @CourseName varchar (50) = '' output
)
as 
begin 
    select  @CourseName = nullif(@CourseName, '')
    select * 
    from course c 
end 
go  

exec CourseGet @all = 1
