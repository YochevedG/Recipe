create or alter proc dbo.MealGet(
    @MealId int = 0,
    @All bit = 0,
    @MealName varchar (50) = '' output
)
as 
begin 
    select  @MealName = nullif(@MealName, '')
    select m.mealid, m.mealname, MealUser = concat(u.firstname, ' ', u.lastname), NumCourses = count(mc.courseid), NumRecipes = count(mcr.recipeid), m.MealDesc
    from meal m
    left join users u 
    on u.usersid = m.usersid
    left join mealcourse mc 
    on mc.mealid = m.mealid
    left join mealcourserecipe mcr 
    on mcr.mealcourseid = mc.mealcourseid
    group by m.mealid, m.mealname, u.firstname, u.lastname, m.MealDesc
    order by m.mealname
end 
go  

--exec MealGet @all = 1
--exec CookbookrecipeGet @all = 1
--exec recipeget @all = 1
