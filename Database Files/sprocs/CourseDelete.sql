create or alter proc dbo.CourseDelete(
    @CourseId int = 0,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0 

    select @CourseId = isnull(@CourseId, 0)
    delete mcr 
    from MealCourseRecipe mcr 
    join MealCourse mc 
    on mc.MealCourseId = mcr.MealCourseId
    join Course c 
    on c.CourseId = mc.CourseId
    where c.CourseId = @CourseId
    
    delete mc 
    from MealCourse mc 
    join Course c 
    on c.CourseId = mc.CourseId
    where c.CourseId = @CourseId
    
    delete c 
    from Course c
    where c.CourseId = @CourseId

    return @return
end 
go 