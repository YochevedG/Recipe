create or alter function dbo.MealCaloriesTotals(@MealId int)
returns varchar(250)
as 
begin 
    declare @value varchar (250) = ''

    select @value =  sum(r.calories)
    from recipe r 
    join mealcourserecipe mcr
    on mcr.recipeid = r.recipeid 
    join mealcourse mc
    on mc.mealcourseid = mcr.mealcourseid 
    where mc.MealId = @MealId
    
    return @value
end 
go 

select MealCaloriesTotals = dbo.MealCaloriesTotals(mc.mealid), r.*
from recipe r
join mealcourserecipe mcr
on mcr.recipeid = r.recipeid 
join mealcourse mc
on mc.mealcourseid = mcr.mealcourseid 

