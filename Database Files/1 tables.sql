-- SM Excellent! See comment, no need to resubmit.

use RecipeDB 
go 

drop table if exists CookbookRecipe
drop table if exists Cookbook
drop table if exists MealCourseRecipe
drop table if exists MealCourse
drop table if exists Meal 
drop table if exists Course
drop table if exists RecipeSteps
drop table if exists RecipeIngredient
drop table if exists MeasurementType
drop table if exists Recipe
drop table if exists Cuisine
drop table if exists Ingredient 
drop table if exists Users 
go 

create table dbo.Users(
    UsersId int not null identity primary key ,
    FirstName varchar (50) not null constraint ck_FirstName_cannot_be_blank check (FirstName <> ''),
    LastName varchar (50) not null constraint ck_LastName_cannot_be_blank check (LastName <> ''),
    UserName varchar (50) not null constraint ck_UserName_cannot_be_blank check (UserName <> '')
                              constraint u_UserName unique
)
go 

create table dbo.Ingredient(
    IngredientId int not null identity primary key,
    IngredientName varchar (50) not null constraint ck_IngredientName_cannot_be_blank check (IngredientName <> '')
                                         constraint u_IngredientName unique,
    IngredientPic as  
    concat('Ingredient_',replace(Ingredientname, ' ', '_'),'.jpg') persisted
)
go 

create table dbo.Cuisine(
    CuisineId int not null identity primary key,
    CuisineType varchar (50) not null constraint ck_CuisineType_cannot_be_blank check (CuisineType <> '')
                                      constraint u_CuisineType unique
)
go 

create table dbo.Recipe(
    RecipeId int not null identity primary key,
    CuisineId int not null constraint f_Recipe_Cuisine foreign key references Cuisine(CuisineId),
    UsersId int not null constraint f_Recipe_Users foreign key references Users(UsersId),
    RecipeName varchar (200) not null constraint ck_RecipeName_cannot_be_blank check (RecipeName <> '')
                                      constraint u_RecipeName unique,
    DraftedDate datetime not null constraint ck_DraftedDate_cannot_be_future_date check (DraftedDate <= getdate()) default getdate(),
    PublishedDate datetime  constraint ck_PublishedDate_cannot_be_future_date check (PublishedDate <= getdate()),
    ArchivedDate datetime constraint ck_ArchivedDate_cannot_be_future_date check(ArchivedDate <= getdate()),
    Calories int not null constraint ck_Calories_must_be_greater_than_or_equal_to_0 check (Calories >= 0),
    CurrentStatus as case 
    when ArchivedDate is not null then 'Archived'
    when ArchivedDate is null and PublishedDate is not null then 'Published'
    when ArchivedDate is null and PublishedDate is null then 'Drafted'
    end
    persisted,
    RecipePic as concat('Recipe_',replace(Recipename, ' ', '_'),'.jpg') persisted,
    constraint ck_PublishedDate_must_be_after_drafteddate_or_publisheddate check (DraftedDate<= PublishedDate and isnull(PublishedDate, DraftedDate) <= ArchivedDate )
)
go 

create table dbo.MeasurementType(
    MeasurementTypeId int not null identity primary key,
    MeasurementType varchar (50) not null constraint ck_MeasurementType_cannot_be_blank check (MeasurementType <> '')
                                          constraint u_MeasurementType unique
)
go 

create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key,
    RecipeId int not null constraint f_RecipeIngredient_Recipe foreign key references Recipe(RecipeId),
    IngredientId int not null constraint f_RecipeIngredient_Ingredient foreign key references Ingredient(IngredientId),
 MeasurementTypeId int null constraint f_RecipeIngredient_MeasurementType foreign key references MeasurementType(MeasurementTypeId) ,
--I need this to be a varchar so I could put in amounts like '5-6' or '1/2'
-- SM The problem of using a varchar would be that you won't be able to do math. You should be able to make double recipe etc.
-- Use decimal.
--its really easier for me this way can I please just leave it? I was able to do the math I just converted to an int....
-- SM The issue is not just in this session, you'll have issues in part 2 and 3.
    MeasurementAmount varchar (50) not null constraint ck_MeasurementAmount_cannot_be_blank check (MeasurementAmount <> ''),
    IngredientSequence int not null constraint ck_RecipeIngredient_must_be_greater_than_0 check (IngredientSequence >0)
                                    constraint u_IngredientSequence_and_RecipeId unique (IngredientSequence, RecipeId)
)
go 

create table dbo.RecipeSteps(
    RecipeStepsId int not null identity primary key,
    RecipeId int not null constraint f_RecipeSteps_Recipe foreign key references Recipe(RecipeId),
    Instructions varchar (1000) not null constraint ck_Instruction_cannot_be_blank check (Instructions <> ''),
    StepsSequence int not null constraint ck_StepsSequence_must_be_greater_than_0 check (StepsSequence > 0)
                               constraint u_StepsSequence_and_RecipeId unique (StepsSequence, RecipeID)
)

create table dbo.Course(
    CourseId int not null identity primary key,
    CourseName varchar (50) not null constraint ck_CourseName_cannot_be_blank check (CourseName <> '')
                                     constraint u_CourseName unique,
    CourseSequence int not null constraint ck_CourseSequence_must_be_greater_than_0 check (CourseSequence > 0)
                                constraint u_CourseSequence unique
)
go 
 

create table dbo.Meal(
    MealId int not null identity primary key,
    UsersId int not null constraint f_Meal_Users foreign key references Users(UsersId),
    MealName varchar (200) not null constraint ck_MealName_cannot_be_blank check (MealName <> '')
                                    constraint u_MealName unique,
    ActiveInactive bit not null default 1,
    DateCreated datetime not null default GETDATE() constraint ck_date_created_cannot_be_future_date check (DateCreated <= getdate()),
    MealPic as concat('Meal_',replace(Mealname, ' ', '_'),'.jpg') persisted
)
go 

create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    CourseId int not null constraint f_CourseMeal_Course foreign key references Course(CourseId),
    MealId int not null constraint f_CourseMeal_Meal foreign key references Meal(MealId)
                        constraint u_CourseID_and_MealId unique (CourseId, MealId )
)
go 

create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key,
    MealCourseId int not null constraint f_MealCourseRecipe_MealCourse foreign key references MealCourse(MealCourseId)
-- SM The constraint should be at the bottome.
    constraint u_MealCourseId_RecipeId unique (MealCourseId, RecipeId),
    RecipeId int not null constraint f_MealCourseRecipe_Recipe foreign key references Recipe(RecipeId),
    IsMainDish bit not null 
    --i did it as 1 = main dish 0 = side dish and null is none
)
go 

create table dbo.Cookbook(
    CookbookId int not null identity primary key,
    UsersId int not null constraint f_Cookbook_Users foreign key references Users(UsersId),
    CookbookName varchar(100) not null constraint ck_CookbookName_cannot_be_blank check (CookbookName <> '')
                                       constraint u_CookbookName unique,
    Price decimal (7,2) not null constraint ck_Price_must_be_greater_than_0 check (Price > 0),
    ActiveInactive bit not null default 1,
    DateCreated datetime not null default GETDATE() constraint ck_date_created_cannot_be_a_future_date check (DateCreated <= getdate()),
    CookbookPic as concat('Cookbook_',replace(Cookbookname, ' ', '_'),'.jpg') persisted
)
go 

create table dbo.CookbookRecipe(
    CookbookRecipeId int not null identity primary key,
    RecipeId int not null constraint f_RecipeCookbook_Recipe foreign key references Recipe(RecipeId),
    CookbookId int not null constraint f_RecipeCookbook_Cookbook foreign key references Cookbook(CookbookId),
    RecipeSequence int not null constraint ck_RecipeSequence_must_be_greater_than_0 check (RecipeSequence > 0)
                                constraint u_RecipeSequence_and_CookbookId unique (RecipeSequence, CookbookId),
                                constraint u_RecipeId_CookbookId unique (RecipeId, CookbookId),
)
go 
--Thanks!