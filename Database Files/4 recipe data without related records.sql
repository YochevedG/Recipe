select * from recipe 

;with x as(
    select CuisineName = 'American', FirstName = 'Alyssa', LastName = 'Anisfeld', RecipeName = 'Cupcakes', DraftedDate = '01/01/2020', PublishedDate = '02/01/2020', ArchivedDate = null, Calories = 300
    union select 'American', 'Debra', 'Donn', 'Berry Ices', '01/01/2021', '05/02/2022', '08/19/2023', 200
    union select 'American', 'Hila', 'Hill', 'Pepper Steak', '07/17/2022', '09/10/2022', null, 100
)
insert Recipe(CuisineId, UsersId, RecipeName, DraftedDate, PublishedDate, ArchivedDate, Calories)
select c.CuisineId, u.UsersId, x.RecipeName, x.DraftedDate, x.PublishedDate, x.ArchivedDate, x.Calories
from x 
join Cuisine c 
on c.cuisineType = x.CuisineName
join Users u 
on u.FirstName = x.FirstName
and u.LastName = x.LastName