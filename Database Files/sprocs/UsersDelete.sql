create or alter proc dbo.UsersDelete(
    @UsersId int = 0,
    @Message varchar (500)  = '' output
)
as 
begin 
    declare @return int = 0 

    select @UsersId = isnull(@UsersId, 0)
    delete ri 
    from RecipeIngredient ri 
    join Recipe r 
    on r.RecipeId = ri.RecipeId
    join Users u 
    on r.UsersId = u.UsersId
    where u.usersid = @usersid
    
    delete rs 
    from RecipeSteps rs
    join Recipe r 
    on r.RecipeId = rs.RecipeId
    join Users u 
    on r.UsersId = u.UsersId
    where u.usersid = @usersid
    
    delete mcr 
    from MealCourseRecipe mcr 
    join  Recipe r 
    on r.RecipeId = mcr.RecipeId
    join Users u 
    on r.UsersId = u.UsersId
    where u.usersid = @usersid
    
    delete cr 
    from CookbookRecipe cr 
    join Recipe r 
    on r.RecipeId = cr.RecipeId
    join Users u 
    on r.UsersId = u.UsersId
    where u.usersid = @usersid
    
    delete r 
    from Recipe r 
    join Users u 
    on u.UsersId = r.UsersId
    where u.usersid = @usersid
    
    delete  mcr 
    from MealCourseRecipe mcr 
    join mealcourse mc 
    on mcr.MealcourseId = mc.MealcourseId
    join meal m 
    on m.mealid = mc.Mealid
    join Users u 
    on u.UsersId = m.UsersId 
    where u.usersid = @usersid
    
    delete mc
    from MealCourse mc
    join meal m 
    on m.mealid = mc.mealid 
    join Users u 
    on u.UsersId = m.UsersId 
    where u.usersid = @usersid
    
    
    delete m
    from Users u 
    left join meal m
    on m.usersid = u.UsersId
    where u.usersid = @usersid
    
    delete c 
    from Users u 
    join Cookbook c 
    on c.usersid = u.UsersId
    where u.usersid = @usersid
    
    delete u 
    from users u 
    where u.usersid = @usersid

return @return
end 
go  