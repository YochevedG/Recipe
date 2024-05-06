-- SM Excellent! 100% See comments, no need to resubmit.
use recipedb
go
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select Names = 'Recipes', Num = count(r.RecipeId)
from Recipe r 
union select 'Meals', count(m.Mealid)
from meal m 
union select 'Cookbooks', count(c.CookbookId)
from Cookbook c



/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
select RecipeName = case when r.CurrentStatus = 'Archived' then concat('<span style="color:gray">', r.RecipeName,'</span>') else r.RecipeName end,
ArchivedDate = isnull(convert(varchar, ArchivedDate, 101), ''), PublishedDate = isnull(convert(varchar, r.PublishedDate, 101), ''), u.firstname, u.lastname,  NumIngredients = count(distinct i.IngredientId), r.calories
from recipe r 
join users u 
on u.usersid = r.UsersId
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Ingredient i 
on i.IngredientId = ri.IngredientId
where r.currentstatus in ('Published', 'Archived')
group by r.RecipeName, r.CurrentStatus, r.ArchivedDate, r.PublishedDate, u.FirstName, u.LastName, r.Calories
order by r.currentstatus desc

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/ 
select  r.RecipeName, r.Calories, NumIngredients = count(distinct i.IngredientId), NumSteps = count(distinct rs.instructions), r.RecipePic
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Ingredient i 
on i.IngredientId = ri.IngredientId
join recipesteps rs 
on r.RecipeId = rs.RecipeId
where r.RecipeName = 'Pizza'
group by r.RecipeName, r.Calories, r.RecipePic

-- SM You have here the same issue as you had in data file. This only shows the ingredients that have measurements.
select ListIngredients = concat(ri.MeasurementAmount, ' ', mt.MeasurementType, ' ', i.IngredientName)
from Ingredient i 
join RecipeIngredient ri 
on ri.IngredientId = i.IngredientId
join recipe r 
on ri.RecipeId = r.RecipeId
join measurementtype mt 
on mt.MeasurementTypeId = ri.MeasurementTypeId
where r.RecipeName = 'Pizza'
order by ri.ingredientsequence

select rs.Instructions
from RecipeSteps rs 
join Recipe r 
on rs.RecipeId = r.RecipeId
where r.RecipeName = 'Pizza'
order by rs.StepsSequence
/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/ 
select m.MealName, u.FirstName, u.LastName, NumCalories = sum(r.Calories), NumCourses = count(c.CourseId), NumRecipes = count(r.RecipeName)
from meal m 
join Users u 
on u.UsersId = m.UsersId
join MealCourse mc
on mc.MealId = m.MealId
join MealCourseRecipe mcr 
on mcr.mealcourseid = mc.mealCourseId
join Recipe r 
on r.recipeid = mcr.RecipeId
join Course c 
on c.CourseId = mc.CourseId
where m.ActiveInactive = 1
group by m.MealName, u.FirstName, u.LastName
order by m.MealName


/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
select m.mealname, u.firstname, u.lastname, m.DateCreated, m.MealPic
from meal m 
join users u 
on m.usersid = u.usersid
where m.MealName = 'Breakfast Bash'

select RecipeList = case when c.CourseName = 'Main Course' and mcr.IsMainDish = 1 then concat('<b>',c.coursename, ': ', 'Main Dish', ' - ', r.recipename, '<b>')
           when c.CourseName = 'Main Course' and mcr.IsMainDish = 0 then concat(c.coursename, ': ', 'Side Dish', ' - ', r.RecipeName)
            else concat(c.coursename, ': ', r.RecipeName) end
from MealCourseRecipe mcr
join MealCourse mc 
on mcr.mealcourseId = mc.mealcourseId
join meal m
on m.mealId = mc.mealId
join course c 
on c.CourseId = mc.CourseId
join Recipe r 
on r.RecipeId = mcr.recipeid
where m.MealName = 'Breakfast Bash'


/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.CookbookName, u.FirstName, u.LastName, NumRecipes = count(r.recipeid)
from Cookbook c 
join users u 
on c.UsersId = u.UsersId
join CookbookRecipe cr 
on c.CookbookId = cr.CookbookId
join Recipe r 
on r.RecipeId = cr.RecipeId
where c.ActiveInactive = 1 
group by c.CookbookName, u.FirstName, u.LastName
order by c.CookbookName



/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
select c.CookbookName, u.FirstName, u.LastName, c.DateCreated, c.Price, NumRecipes = count(r.recipeid), c.CookbookPic
from Cookbook c 
join Users u 
on c.UsersId = u.UsersId
join CookbookRecipe cr 
on c.CookbookId = cr.CookbookId
join Recipe r 
on r.RecipeId = cr.RecipeId
where c.CookbookName = 'Treats for Two'
group by c.CookbookName, u.FirstName, u.LastName, c.DateCreated, c.Price, c.CookbookPic

select r.RecipeName, cu.CuisineType, NumIngredients = count(distinct ri.IngredientId), NumSteps = count(distinct rs.Instructions) ,cr.RecipeSequence
from Cookbook c 
join CookbookRecipe cr 
on c.CookbookId = cr.CookbookId
join Recipe r 
on r.RecipeId = cr.RecipeId 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join RecipeSteps rs 
on r.RecipeId = rs.RecipeId
join Cuisine cu
on cu.CuisineId = r.CuisineId
where c.cookbookname = 'Treats for Two'
group by r.RecipeName, cu.CuisineType, cr.RecipeSequence
order by cr.RecipeSequence

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
select distinct ReversedRecipe =  concat(upper(substring(reverse(r.RecipeName),1,1)), lower(substring(reverse(r.RecipeName),2,100))),
ReversedPic = concat('Recipe_', replace(reverse(r.RecipeName), '', '_'), '.jpg')
from recipe r 
join CookbookRecipe cr 
on cr.RecipeId = r.RecipeId
join Cookbook c 
on c.CookbookId = cr.CookbookId


;with x as (
    select r.RecipeName, LastStep = max(rs.StepsSequence)
    from Recipe r 
    join RecipeSteps rs 
    on r.RecipeId = rs.RecipeId
    group by r.RecipeName
)
select rs.Instructions
from x 
join recipe r 
on r.recipename = x.recipename
join recipesteps rs 
on r.recipeid = rs.recipeid
where rs.stepssequence = x.LastStep
/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all.
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
select NumRecipes = count(r.RecipeId), u.LastName, CurrentStatus = isnull(r.CurrentStatus, '')
from users u 
left join recipe r
on r.UsersId = u.UsersId
group by u.lastname, r.CurrentStatus
order by u.LastName

select NumRecipes = count(r.RecipeId), u.LastName, AvgDays = isnull(avg(datediff(day, r.DraftedDate, r.PublishedDate)), 0)
from users u 
left join recipe r
on r.UsersId = u.UsersId
group by u.lastname
order by u.LastName

select u.LastName, NumMeals = count(m.mealid), NumActive = sum(case when m.ActiveInactive = 1 then 1 else 0 end), NumInactive = sum(case when m.ActiveInactive = 0 then 1 else 0 end)
from Users u 
left join Meal m 
on m.UsersId = u.UsersId
group by u.LastName

select u.LastName, NumCookbooks = count(c.CookbookId), NumActive = sum(case when c.ActiveInactive = 1 then 1 else 0 end), NumInactive = sum(case when c.ActiveInactive = 0 then 1 else 0 end)
from Users u 
left join Cookbook c 
on c.UsersId = u.UsersId
group by u.LastName

select r.recipename, DaysTillArchived = datediff(day, r.drafteddate, r.ArchivedDate)
from recipe r 
where r.ArchivedDate is not null and r.PublishedDate is null
/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.

    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
select Names = 'Recipes', Num = count(r.RecipeId)
from Users u 
join Recipe r 
on r.UsersId = u.UsersId
where u.LastName = 'Donn'
and u.FirstName = 'Debra'
union select 'Meals', count(m.mealid)
from Users u 
join Meal m 
on m.UsersId = u.UsersId
where u.LastName = 'Donn'
and u.FirstName = 'Debra'
union select 'Cookbooks' , count(c.cookbookid)
from users u 
join Cookbook c 
on c.UsersId = u.UsersId
where u.LastName = 'Donn'
and u.FirstName = 'Debra'

-- SM Tip: Use one datediff() with case in it and then you'll be able to use isnull()
select r.RecipeName, r.CurrentStatus, NumHours = case when r.CurrentStatus  = 'Published' then datediff(hour, r.DraftedDate, r.PublishedDate ) when r.currentstatus = 'Archived' and r.PublishedDate is not null then datediff(hour,  r.PublishedDate, r.ArchivedDate) when r.currentstatus = 'Archived' and r.PublishedDate is null then datediff(hour,  r.DraftedDate, r.ArchivedDate) end
from Users u 
join Recipe r 
on r.usersid = u.UsersId
where u.LastName = 'Donn'
and u.FirstName = 'Debra'
and r.currentstatus <> 'Drafted'

--Thanks!