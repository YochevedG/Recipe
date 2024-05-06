-- SM Excellent! See comments, fix and resubmit.


-- SM Spec should be in separate file.
/*
notes:
recipes can be part of a meal or cookbook 
recipe has cuisine type, ingredient, steps, status, date and time went into drafts, published, archive, user, calories
master list of cuisine
each ingredient has measurement type and amount, sequence num in recipe
steps have instructions, sequence num

meals have name, courses, active/inactive, datecreated, user
courses have diff types - appetizers, main, dessert
each course can have multiple recipes in it
courses have sequence in meal
ingredients, recipe, meal, cookbook would be unique - one time use
in meal have multiple course, but meal cannot have 2 of same course
each course can have multiple recipes


cookbooks has name, price, recipes (not meals), active/inactive datecreated, user
recipes have sequence how presented in cookbook

have pics of recipe, ingredient, meal, cookbook
pictype(ingredient), name of ingredient (recipe_carrot_muffins.jpg)

staff(user) have firstname, lastname, username



tables:
Users
    UserId int not null identity primary key
    FirstName not null not blank
    LastName not null not blank
-- SM Should be unique.
    UserName not null not blank

Ingredient
    Ingredientid int not null identity primary key
    Ingredentname not null not blank unique
-- SM A ingredient can have multiple measurement types. And the measurement has to do with the ingredient for a recipe not with the ingredient itself.
    measurementtype not null not blank
-- SM Both comments on measurementtype are partially valid here.
	amount int not null not blank

Cuisine 
    cuisineid int not null identity primary key
-- SM Should be unique.
    CuisineType not null not blank

Steps
    StepsId int not null identity primary key
    Instructions not null not blank
    StepSequence int not null not blank
Statuses

-- SM No need for status table as commented below.
Status
    StatusId int not null identity primary key
    StatusName not null not blank

Recipe
    recipeid int not null indentity primary key
    cuisineid int not null foreign key constraint
-- SM A recipe has multiple ingredients.
    ingredientid int not null foreign key constraint
    `   constraint ingredientid and recipeid
-- SM A recipe has multiple steps.
    stepsid int not null foreign key constraint
-- SM No need for this. Add 3 date columns for each status, and add computed column to determine currrent status based on latest date.
    StatusId int not null foreign key constraint
    UserId int not null foreign key constraint
    StatusDate default datetime
    recipename not null not blank unique
    calories int not null not blank

Course
    CourseId int not null identity primary key
-- SM Should be unique.
    CourseName not null not blank

-- SM A course doesn't have recipes. A meal has courses and each course in the meal has recipes.
-- You can have once each recipe in each meals course. You can only have once each course in each meal.
-- You can have multiple times same recipe in same meal as long as it's in different courses.
RecipeCourse
    RecipeCourseId int not null identity primary key
    RecipeId int not null foreign key constraint
    CourseId int not null foreign key constraint

Meal
    mealid int not null identity primary key
    UserId int not null foreign key constraint
    MealName not null not blank unique
    Active/Inactive bit
    DateCreated default datetime

CourseMeal
    CourseMealId int not null primary key
    CourseId int not null foreign key constraint 
    MealId int not null foreign key constraint 
-- SM This should be in course table and should be unique. The order of the courses are always the same.
    CourseSequence int not null not blank

Cookbook
    cookbookid int not null identity primary key
    cookbookname not null not blank unique
    cookbookprice decimal not null not blank
    Active/Inactive bit
    DateCreated default datetime

-- SM You need a sequence column. And the books should only have once a recipe.
 RecipeCookbook
    RecipeCookbookid int not null identity primary key   
    RecipeId foreign key constraint
    CookbookId foreign key constraint

-- SM No need for this table. Add a computed column to each table that has images.
Picture
    Pictureid int not null identity primary key
    PicType not null not blank 
    


    