declare @RecipeId int 

select @RecipeId =r.recipeid from recipe r where r.recipename = 'Pizza'

select @RecipeId

select 'recipe', r.recipeid, r.recipename from recipe r where r.recipeid = @Recipeid
union select 'cookbook', cr.CookbookRecipeId, c.cookbookname from cookbookrecipe cr join cookbook c on c.cookbookid = cr.cookbookid where cr.recipeid = @Recipeid
union select 'meal', pm.PresidentMedalId, m.MedalName from PresidentMedal pm join Medal m on m.MedalId= pm.MedalId where pm.PresidentId = @PresidentId
