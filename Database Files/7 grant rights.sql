use RecipeDB 
go 
/* select concat('grant execute on ', r.ROUTINE_NAME, ' to testrole')
from INFORMATION_SCHEMA.ROUTINES r  */ 

grant execute on RecipeGet to testrole
grant execute on CuisineGet to testrole
grant execute on UsersGet to testrole
grant execute on RecipeDelete to testrole
grant execute on RecipeUpdate to testrole
grant execute on CookbookGet to testrole
grant execute on MealGet to testrole
grant execute on RecipeIngredientGet to testrole
grant execute on RecipeStepsGet to testrole
grant execute on RecipeIngredientUpdate to testrole
grant execute on RecipeStepsUpdate to testrole
grant execute on RecipeIngredientDelete to testrole
grant execute on RecipeStepsDelete to testrole
grant execute on IngredientGet to testrole
grant execute on RecipeCaloriesTotals to testrole
grant execute on StepsGet to testrole
grant execute on RecipeDesc to testrole
grant execute on CookbookUpdate to testrole
grant execute on MealCaloriesTotals to testrole
grant execute on CookbookRecipeGet to testrole
grant execute on CookbookRecipeUpdate to testrole
grant execute on CookbookRecipeDelete to testrole
grant execute on CourseGet to testrole
grant execute on CourseUpdate to testrole
grant execute on CourseDelete to testrole
grant execute on CookbookDelete to testrole
grant execute on CuisineUpdate to testrole
grant execute on CuisineDelete to testrole
grant execute on IngredientDelete to testrole
grant execute on IngredientUpdate to testrole
grant execute on MeasurementGet to testrole
grant execute on UsersDelete to testrole
grant execute on RecipeClone to testrole
grant execute on CookbookAutoCreate to testrole
grant execute on DashboardGet to testrole
grant execute on StatusGet to testrole
grant execute on ChangeRecipeStatus to testrole
grant execute on ChangeRecipeStatusToPublished to testrole
grant execute on ChangeRecipeStatusToArchived to testrole
grant execute on ChangeRecipeStatusToDrafted to testrole
grant execute on UsersUpdate to testrole
