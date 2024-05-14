-- SM Excellent! Can't run file.
use RecipeDB
go 

delete CookbookRecipe
delete Cookbook
delete MealCourseRecipe
delete MealCourse
delete Meal 
delete Course
delete RecipeSteps
delete RecipeIngredient
delete MeasurementType
delete Recipe
delete Cuisine
delete Ingredient 
delete Users 

insert Users(FirstName, LastName, UserName)
select 'Alyssa', 'Anisfeld', 'AAnisfeld'
union select 'Brenna', 'Barnold', 'BBarnold'
union select 'Caitlyn', 'Cornowski', 'CCornowski'
union select 'Debra', 'Donn', 'DDonn'
union select 'Ella', 'Ebert', 'EEbert'
union select 'Freya', 'Frank', 'Frank'
union select 'Geraldine', 'Green', 'GGreen'
union select 'Hila', 'Hill', 'HHill'

insert Ingredient(IngredientName)
select 'Sugar'
union select 'Vanilla Sugar'
union select 'Flour'
union select 'Eggs'
union select 'Oil'
union select 'Baking Powder'
union select 'Baking Soda'
union select 'Chocolate Chips'
union select 'Granny Smith Apples'
union select 'Vanilla Yogurt'
union select 'Orange Juice'
union select 'Honey'
union select 'Ice Cubes'
union select 'Club Bread'
union select 'Butter'
union select 'Shredded Cheese'
union select 'Garlic Cloves'
union select 'Black Pepper'
union select 'Salt'
union select 'Butter'
union select 'Vanilla Pudding'
union select 'Whipped Cream Cheese'
union select 'Sour Cream Cheese'
union select 'Frozen Strawberries'
union select 'Sliced Peaches'
union select 'Sliced Pinapple'
union select 'Mandarin Oranges'
union select 'Water'
union select 'Garlic Powder'
union select 'Mushrooms'
union select 'Chicken Cutlets'
union select 'Italian Breadcrumbs'
union select 'Oil Spray'
union select 'Pizza Dough'
union select 'Tomato Sauce'
union select 'Mozzerella Cheese'
union select 'Oregano'
union select 'Instant Coffee'
union select 'Boiling Water'
union select 'Milk'

insert Cuisine(CuisineType)
select 'American'
union select 'Australian'
union select 'English'
union select 'French'
union select 'Israeli'
union select 'Italian'
union select 'Mediterranean'

;with x as(
    select CuisineName = 'American', FirstName = 'Alyssa', LastName = 'Anisfeld', RecipeName = 'Chocolate Chip Cookies', DraftedDate = '01/01/2020', PublishedDate = '02/01/2020', ArchivedDate = null, Calories = 300
    union select 'American', 'Debra', 'Donn', 'Butter Muffins', '01/01/2021', '05/02/2022', '08/19/2023', 200
    union select 'American', 'Hila', 'Hill', 'Strawberry Ice cream', '07/17/2022', '09/10/2022', null, 100
    union select 'American', 'Alyssa', 'Anisfeld', 'Ice Coffee Slush', '10/10/2021', '12/10/2021', null, 250
    union select 'French', 'Freya', 'Frank', 'Apple Yogurt Smoothie', '07/07/2022', null, '02/05/2023', 75
    union select 'French', 'Debra', 'Donn', 'Fruit Salad cups', '03/13/2023', '07/10/2023', null, 90
    union select 'English', 'Brenna', 'Barnold', 'Cheese Bread', '05/29/2023', '10/14/2023', '01/01/2024', 150
    union select 'Israeli', 'Ella', 'Ebert', 'Mushroom Soup', '02/23/2020', '07/17/2020', null, 100
    union select 'Israeli', 'Freya', 'Frank', 'Italian Breaded Chicken Cutlets', '12/20/2021', '03/20/2023', null, 90
    union select 'Italian', 'Debra', 'Donn', 'Pizza', '08/09/2023', '08/19/2023', null, 200
)
insert Recipe(CuisineId, UsersId, RecipeName, DraftedDate, PublishedDate, ArchivedDate, Calories)
select c.CuisineId, u.UsersId, x.RecipeName, x.DraftedDate, x.PublishedDate, x.ArchivedDate, x.Calories
from x 
join Cuisine c 
on c.cuisineType = x.CuisineName
join Users u 
on u.FirstName = x.FirstName
and u.LastName = x.LastName

insert MeasurementType(MeasurementType)
select 'Cup'
union select'Teaspoon'
union select'Tablespoon'
union select'Ounce'
union select'Pinch'
union select'Stick'
union select'Bag'
union select'Tray'
union select'Sprinkle'
union select'Can'
union select'Pound'

;with x as(
    select RecipeName = 'Chocolate Chip Cookies', IngredientName = 'Sugar', MeasurementType = 'Cup', MeasurementAmount = '1', IngredientSequence = 1 
    union select 'Chocolate Chip Cookies', 'Oil', 'Cup', '1/2', 2
    union select 'Chocolate Chip Cookies', 'Flour','Cup', '2', 3
    union select 'Chocolate Chip Cookies', 'Vanilla Sugar', 'Teaspoon', '1', 4
    union select 'Chocolate Chip Cookies', 'Baking Powder', 'Teaspoon', '2', 5
    union select 'Chocolate Chip Cookies', 'Baking Soda', 'Teaspoon', '1/2', 6
    union select 'Chocolate Chip Cookies', 'Chocolate Chips', 'Cup', '1',7
    union select 'Apple Yogurt Smoothie','Granny Smith Apples', null, '3', 1
    union select 'Apple Yogurt Smoothie','Vanilla Yogurt', 'Cup', '2',2
    union select 'Apple Yogurt Smoothie','Sugar', 'Teaspoon', '2',3
    union select 'Apple Yogurt Smoothie','Orange Juice', 'Cup', '1/2',4
    union select 'Apple Yogurt Smoothie','Honey', 'Tablespoon', '2',5
    union select 'Apple Yogurt Smoothie','Ice Cubes', null, '5-6',6
    union select 'Cheese Bread','Club Bread', null,'1',1
    union select 'Cheese Bread','Butter', 'Ounce', '4',2
    union select 'Cheese Bread','Shredded Cheese', 'Ounce', '8',3
    union select 'Cheese Bread','Garlic Cloves', null, '2',4
    union select 'Cheese Bread','Black Pepper', 'Teaspoon', '3/4',5
    union select 'Cheese Bread','Salt', 'Pinch', '1',6
    union select 'Butter Muffins', 'Butter', 'Stick', '1',1
    union select 'Butter Muffins', 'Sugar', 'Cup', '3',2
    union select 'Butter Muffins', 'Vanilla Pudding', 'Tablespoon', '2',3
    union select 'Butter Muffins', 'Eggs', null, '4',4
    union select 'Butter Muffins', 'Whipped Cream Cheese', 'Ounce', '8',5
    union select 'Butter Muffins', 'Sour Cream Cheese', 'Ounce', '8',6
    union select 'Butter Muffins', 'Flour', 'Cup', '1',7
    union select 'Butter Muffins', 'Baking Powder', 'Teaspoon', '2',8
    union select 'Strawberry Ice Cream', 'Eggs', null,  '2',1
    union select 'Strawberry Ice Cream', 'Sugar', 'Cup', '1',2
    union select 'Strawberry Ice Cream', 'Frozen Strawberries', 'Bag', '2',3
    union select 'Fruit Salad cups','Sliced Peaches', 'Cup', '1',1
    union select 'Fruit Salad cups','Sliced Pinapple', 'Cup', '1',2
    union select 'Fruit Salad cups','Mandarin Oranges', 'Cup', '1',3
    union select 'Mushroom Soup', 'Water','Cup', '5',1
    union select 'Mushroom Soup', 'Salt', 'Tablespoon', '2',2
    union select 'Mushroom Soup', 'Garlic Powder', 'Teaspoon', '2',3
    union select 'Mushroom Soup', 'Black Pepper', 'Teaspoon', '1',4
    union select 'Mushroom Soup', 'Mushrooms', 'Can', '1',5
    union select 'Italian Breaded Chicken Cutlets','Chicken Cutlets', 'Pound', '1',1
    union select 'Italian Breaded Chicken Cutlets','Egg', null, '1',2
    union select 'Italian Breaded Chicken Cutlets','Italian Breadcrumbs', 'Cup', '1',3
    union select 'Italian Breaded Chicken Cutlets','Oil Spray', null, 'As needed',4
    union select 'Pizza','Pizza Dough', 'Pound', '1',1
    union select 'Pizza','Tomato Sauce','Cup', '1',2
    union select 'Pizza','Mozzerella Cheese', 'Cup', '2',3
    union select 'Pizza','Flour', 'Sprinkle', '1',4
    union select 'Ice Coffee Slush','Instant Coffee', 'Tablespoon', '1',1
    union select 'Ice Coffee Slush','Boiling Water', 'Tablespoon', '2',2
    union select 'Ice Coffee Slush','Sugar', 'Tablespoon', '2',3
    union select 'Ice Coffee Slush','Milk', 'Cup', '1',4
    union select 'Ice Coffee Slush', 'Vanilla Pudding', 'Teaspoon', '1',5
    union select 'Ice Coffee Slush','Ice Cubes', 'Tray', '1',6
)
insert RecipeIngredient(RecipeId, IngredientId, MeasurementTypeId, MeasurementAmount, IngredientSequence)
select r.RecipeId, I.IngredientId, mt.MeasurementTypeId, x.MeasurementAmount, x.IngredientSequence
from x 
join Recipe r 
on r.RecipeName = x.RecipeName
join Ingredient i 
on i.IngredientName = x.IngredientName
left join MeasurementType mt 
on mt.MeasurementType = x.MeasurementType

;with x as(
    select RecipeName = 'Chocolate Chip Cookies', Instructions = 'First combine sugar, oil and eggs in a bowl', StepsSequence = 1
    union select 'Chocolate Chip Cookies', 'mix well', 2
    union select 'Chocolate Chip Cookies', 'add flour, vanilla sugar, baking powder and baking soda', 3
    union select 'Chocolate Chip Cookies', 'beat for 5 minutes', 4
    union select 'Chocolate Chip Cookies', 'add chocolate chips', 5
    union select 'Chocolate Chip Cookies', 'freeze for 1-2 hours', 6
    union select 'Chocolate Chip Cookies', 'roll into balls and place spread out on a cookie sheet', 7
    union select 'Chocolate Chip Cookies', 'bake on 350 for 10 min', 8
    union select 'Apple Yogurt Smoothie', 'Peel the apples and dice', 1
    union select 'Apple Yogurt Smoothie', 'Combine all ingredients in bowl except for apples and ice cubes', 2
    union select 'Apple Yogurt Smoothie', 'mix until smooth', 3
    union select 'Apple Yogurt Smoothie', 'add apples and ice cubes', 4
    union select 'Apple Yogurt Smoothie', 'pour into glasses', 5
    union select 'Cheese Bread', 'Slit bread every 3/4 inch', 1
    union select 'Cheese Bread', 'Combine all ingredients in bowl', 2
    union select 'Cheese Bread', 'fill slits with cheese mixture', 3
    union select 'Cheese Bread', 'wrap bread into a foil and bake for 30 minutes', 4
    union select 'Butter Muffins', 'Cream butter with sugars', 1
    union select 'Butter Muffins', 'Add eggs and mix well', 2
    union select 'Butter Muffins', 'Slowly add rest of ingredients and mix well', 3
    union select 'Butter Muffins', 'fill muffin pans 3/4 full and bake for 30 minutes', 4
    union select 'Strawberry Ice Cream', 'beat eggs and sugar', 1
    union select 'Strawberry Ice Cream', 'add strawberries and beat till fluffy', 2
    union select 'Strawberry Ice Cream', 'store in 9 x 13 and freeze', 3
    union select 'Fruit Salad Cups', 'pour all ingredients into big bowl', 1
    union select 'Fruit Salad Cups', 'mix very well', 2
    union select 'Fruit Salad Cups', 'pour into individual cups', 3
    union select 'Mushroom Soup', 'saute the mushrooms with the spices', 1
    union select 'Mushroom Soup', 'boil the water meanwhile', 2
    union select 'Mushroom Soup', 'add mushrooms to water and cook for 3 hours', 3
    union select 'Italian Breaded Chicken Cutlets', 'coat cutlets in egg', 1
    union select 'Italian Breaded Chicken Cutlets', 'then coat in breading', 2
    union select 'Italian Breaded Chicken Cutlets', 'lay on greased 9 x 13 and spray with oil', 3
    union select 'Italian Breaded Chicken Cutlets', 'bake for 9 minutes and spray and turn over, turn for another 9 minutes', 4
    union select 'Pizza', 'sprinkle flour on pizza dough', 1
    union select 'Pizza', 'spread tomato sauce on dough', 2
    union select 'Pizza', 'cover with cheese', 3
    union select 'Pizza', 'bake for 20 minutes', 4
    union select 'Ice Coffee Slush', 'dissolve coffee in boiling water', 1
    union select 'Ice Coffee Slush', 'pour into blender', 2
    union select 'Ice Coffee Slush', 'pour milk, sugar, pudding into blender', 3
    union select 'Ice Coffee Slush', 'add ice cubes and blend till slushy', 4
    )
insert RecipeSteps(RecipeId, Instructions, StepsSequence)
select r.RecipeId, x.Instructions, x.StepsSequence
from x 
join Recipe r 
on r.RecipeName = x.RecipeName

insert Course(CourseName, CourseSequence)
select 'Appetizer', 1
union select 'Main Course', 2
union select 'Dessert', 3

;with x as(
    select FirstName = 'Alyssa', LastName = 'Anisfeld', MealName = 'Breakfast Bash'
    union select 'Debra', 'Donn', 'Lunch Life'
    union select 'Debra', 'Donn', 'Dinner Delight'
    union select 'Hila', 'Hill', 'Brunch Breeze'
)
insert Meal(UsersId, MealName)
select u.UsersId, x.MealName
from x 
join Users u 
on u.FirstName = x.FirstName
and u.LastName = x.LastName

;with x as(
    select MealName = 'Breakfast Bash', CourseName = 'Appetizer'
    union select 'Breakfast Bash', 'Main Course'
    union select 'Breakfast Bash', 'Dessert'
    union select 'Lunch Life', 'Appetizer'
    union select 'Lunch Life', 'Main Course'
    union select 'Dinner Delight', 'Appetizer'
    union select 'Dinner Delight', 'Main Course'
    union select 'Dinner Delight', 'Dessert'
    union select 'Brunch Breeze', 'Appetizer'
    union select 'Brunch Breeze', 'Main Course'
)
insert MealCourse(MealId, CourseId)
select m.MealId, c.CourseId
from x 
join Meal m 
on m.MealName = x.MealName
join course c 
on c.CourseName = x.CourseName

;with x as(
    select RecipeName = 'Cheese Bread', Course = 'Main Course', Meal = 'Breakfast Bash', IsMainDish = 1
    union select 'Apple Yogurt Smoothie', 'Appetizer', 'Breakfast Bash', 1
    union select 'Butter Muffins', 'Main Course', 'Breakfast Bash', 0
    union select 'Ice Coffee Slush', 'Dessert', 'Breakfast Bash', 1
    union select 'Pizza', 'Main Course', 'Lunch Life', 1
    union select 'Mushroom Soup', 'Appetizer', 'Lunch Life',  1
    union select 'Italian Breaded Cutlets', 'Main Course', 'Dinner Delight', 1
    union select 'Mushroom Soup', 'Main Course', 'Dinner Delight', 0
    union select 'Fruit Salad Cups', 'Appetizer', 'Dinner Delight', 1
    union select 'Strawberry Ice Cream', 'Dessert', 'Dinner Delight', 1
    union select 'Chocolate Chip Cookies', 'Main Course', 'Brunch Breeze', 1
    union select 'Fruit Salad Cups', 'Main Course', 'Brunch Breeze', 0
    union select 'Ice Coffee Slush', 'Appetizer', 'Brunch Breeze', 1
)
insert MealCourseRecipe(MealCourseId, RecipeId, IsMainDish)
select mc.MealCourseId, r.RecipeId, x.IsMainDish
from x 
join recipe r 
on r.recipename = x.recipename 
join course c 
on x.Course = c.coursename 
join meal m 
on x.meal = m.mealname
join MealCourse mc 
on mc.Mealid = m.MealId
and mc.CourseId = c.CourseId


;with x as(
    select FirstName = 'Ella', LastName = 'Ebert', CookbookName = 'Treats for Two', Price = 30
    union select 'Freya', 'Frank', 'Recipe Rite', 20
    union select 'Ella', 'Ebert', 'Dining Delish', 45
    union select 'Brenna', 'Barnold', 'SlimYum', 40
)
insert Cookbook(UsersId, CookbookName, Price)
select u.UsersId, x.CookbookName, x.Price
from x 
join Users u 
on x.FirstName = u.FirstName
and x.LastName = u.LastName

;with x as(
    select CookbookName = 'Treats for Two', RecipeName = 'Chocolate Chip Cookies', RecipeSequence = 1
    union select 'Treats for Two', 'Apple Yogurt Smoothie', 2
    union select 'Treats for Two', 'Cheese Bread', 3
    union select 'Treats for Two', 'Butter Muffins', 4
    union select 'Recipe Rite', 'Pizza', 1
    union select 'Recipe Rite', 'Fruit Salad Cups', 2
    union select 'Recipe Rite', 'Cheese Bread', 3
    union select 'Recipe Rite', 'Chocolate Chip Cookies', 4
    union select 'Recipe Rite', 'Ice Coffee Slush', 5
    union select 'Dining Delish', 'Strawberry Ice cream', 1
    union select 'Dining Delish', 'Italian Breaded Chicken Cutlets', 2
    union select 'Dining Delish', 'Apple Yogurt Smoothie', 3
    union select 'Dining Delish', 'Mushroom Soup', 4
    union select 'Dining Delish', 'Ice Coffee Slush', 5
    union select 'SlimYum', 'Apple Yogurt Smoothie', 1
    union select 'SlimYum', 'Mushroom Soup', 2
    union select 'SlimYum', 'Fruit Salad Cups', 3
)
insert CookbookRecipe(CookbookId, RecipeId, RecipeSequence)
select c.CookbookId, r.RecipeId, x.RecipeSequence
from x 
join Cookbook c 
on c.CookbookName = x.CookbookName
join Recipe r 
on r.RecipeName = x.RecipeName

select * from Users
select * from Ingredient
select * from Cuisine
select * from Recipe
select * from MeasurementType
select * from RecipeIngredient
select * from RecipeSteps
select * from Course 
select * from Meal
select * from MealCourse
select * from Cookbook
select * from CookbookRecipe
select * from MealCourseRecipe



--thanks!