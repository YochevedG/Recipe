-- SM Excellent! 100% See comments, no need to resubmit.
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.
use RecipeDB 
go 
--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
-- SM You need to update this. You're missing one delete statement.
--which delete statement? it works to delete the user so I assumed all is good...
-- SM The same as you do for meal course recipe (that you have 2) you need to do for cookbook recipe.
delete ri 
from RecipeIngredient ri 
join Recipe r 
on r.RecipeId = ri.RecipeId
join Users u 
on r.UsersId = u.UsersId
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete rs 
from RecipeSteps rs
join Recipe r 
on r.RecipeId = rs.RecipeId
join Users u 
on r.UsersId = u.UsersId
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete  mcr 
from MealCourseRecipe mcr 
join Recipe r 
on r.RecipeId = mcr.RecipeId
join Users u 
on u.UsersId = r.UsersId 
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete cr
from CookbookRecipe cr
join Recipe r 
on r.RecipeId = cr.recipeid
join Users u 
on u.UsersId = r.UsersId 
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete r 
from Recipe r 
join Users u 
on r.UsersId = U.UsersId
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete  mcr 
from MealCourseRecipe mcr 
join mealcourse mc 
on mcr.MealcourseId = mc.MealcourseId
join meal m 
on m.mealid = mc.Mealid
join Users u 
on u.UsersId = m.UsersId 
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete mc
from MealCourse mc
join meal m 
on m.mealid = mc.mealid 
join Users u 
on u.UsersId = m.UsersId 
where u.FirstName = 'Debra'
and u.LastName = 'Donn'


delete m
from Users u 
left join meal m
on m.usersid = u.UsersId
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete c 
from Users u 
join Cookbook c 
on c.usersid = u.UsersId
where u.FirstName = 'Debra'
and u.LastName = 'Donn'

delete u  
from Users u  
where u.FirstName = 'Debra'
and u.LastName = 'Donn'
--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.
-- SM The copy should really be in draft.
--not sure how to do this???
-- SM draftdate should be current date and published and archived should be null.
insert Recipe(CuisineId, UsersId, RecipeName, DraftedDate, PublishedDate, ArchivedDate, Calories)
select r.cuisineid, r.UsersId, concat(r.RecipeName, ' - Clone'), getdate(), getdate(), r.ArchivedDate, r.Calories
from Recipe r 
where r.RecipeName = 'Pizza'

;with x as(
	select r.recipeid, r.recipename
	from Recipe r 
	where r.RecipeName = 'Pizza - Clone'
)
insert RecipeIngredient(RecipeId, IngredientId, MeasurementTypeId, MeasurementAmount, IngredientSequence)
select x.recipeid, ri.ingredientid, ri.measurementtypeid, ri.measurementamount, ri.ingredientsequence
from x 
cross join Recipe r  
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
where r.recipename = 'Pizza'

;with x as (
	select r.recipeid, r.recipename
	from Recipe r 
	where r.RecipeName = 'Pizza - Clone'
)
insert RecipeSteps(RecipeId, Instructions, StepsSequence)
select x.recipeid, rs.Instructions, rs.stepssequence
from x 
cross join Recipe r  
join Recipesteps rs 
on rs.RecipeId = r.RecipeId
where r.recipename = 'Pizza'
/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/ --**
insert Cookbook(UsersId, CookbookName, Price, ActiveInactive)
select u.usersid, concat('Recipes by ', u.FirstName, ' ', u.LastName), count(r.RecipeId) * 1.33, 1
from users u 
join Recipe r 
on r.UsersId = u.UsersId
where u.FirstName = 'Alyssa'
and u.LastName = 'Anisfeld'
group by u.LastName, u.FirstName, u.UsersId

-- SM You need to update this. What do you do with the where clause in CTE?
--what do you mean by this? do I have to fix anything?
-- SM In select (in CTE) you set the cookbook name in a very good way. But why do you need the where clause for cookbook name?
-- This doesn't make any sense. A better way would be to do where on user name.
;with x as(
    select CookbookName = concat('Recipes by ', u.FirstName, ' ', u.LastName), RecipeSequence = ROW_NUMBER() over (order by r.recipename), r.RecipeName
	from Cookbook c  
	join Users u 
	on u.UsersId = c.UsersId
	join recipe r
	on r.UsersId = u.UsersId
	where c.CookbookName = 'Recipes by Alyssa Anisfeld'
)

insert CookbookRecipe(CookbookId, RecipeId, RecipeSequence)
select c.CookbookId, r.RecipeId, x.RecipeSequence
from x 
join Cookbook c 
on x.CookbookName = c.CookbookName
join Recipe r 
on r.RecipeName = x.RecipeName



/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
-- SM You need to update this. See my comment in table.
update r 
set r.Calories = case when mt.MeasurementType = 'Cup' then ((r.Calories/convert(int, ri.MeasurementAmount)) - 20) * convert(int, ri.MeasurementAmount)
				when mt.MeasurementType = 'Tablespoon' then ((r.Calories/convert(int, ri.MeasurementAmount)) +30) * convert(int, ri.MeasurementAmount)
				else r.Calories end 
--select *
from recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Ingredient i 
on i.IngredientId = ri.IngredientId
join measurementtype mt 
on mt.MeasurementTypeId = ri.MeasurementTypeId
where i.IngredientName = 'Sugar'


/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
-- SM Add a recipe that this should return anything.
;with x as
(select  AvgHours = avg(datediff(hour, r.DraftedDate, r.publisheddate))
from recipe r 
)

select u.firstname, u.lastname, EmailAddress = concat(substring(u.FirstName, 1,1), u.LastName, '@heartyhearth.com'), Alert = concat('Your recipe ', r.recipename, ' is sitting in draft for ',datediff(hour, r.DraftedDate, r.publisheddate), ' hours. That is ', datediff(hour, datediff(hour, r.DraftedDate, r.publisheddate), x.AvgHours) ,' hours more than the average ', x.AvgHours,  ' hours all other recipes took to be published')
from users u 
join recipe r 
on u.UsersId = r.usersId
join x 
on x.AvgHours > datediff(hour, r.DraftedDate, r.publisheddate)
where r.CurrentStatus = 'Drafted'


/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and receive a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
-- SM Tip: Convert the prices to 2 decimal places.
select EmailBody = concat('Order cookbooks from HeartyHearth.com! We have ', count(*), ' books for sale, average price is ', avg(c.price), 
'. You can order them all and receive a 25% discount, for a total of ', (sum(c.Price) - (sum(c.price) * .25)) ,'. Click <a href = "www.heartyhearth.com/order/',newid(),'">here</a> to order.')
from Cookbook c 
