create or alter function dbo.MealCaloriesTotals(@MealId int)
returns varchar(250)
as 
begin 
    declare @value varchar (250) = ''

    select @value =  concat(m.mealname, ' has ', sum(r.calories), ' calories.')
    from recipe r 
    join mealcourserecipe mcr
    on mcr.recipeid = r.recipeid 
    join mealcourse mc
    on mc.mealcourseid = mcr.mealcourseid 
    join meal m 
    on m.mealid = mc.mealid  
    where m.MealId = @MealId


    return @value
end 
go 

select RecipeCaloriesTotals = dbo.RecipeCaloriesTotals(m.mealid), r.*
from recipe r
join mealcourserecipe mcr
on mcr.recipeid = r.recipeid 
join mealcourse mc
on mc.mealcourseid = mcr.mealcourseid 
join meal m 
on m.mealid = mc.mealid  
