alter table recipe add Vegan varchar (10) not null default 'No'
alter table Cookbook add CookbookSkill int not null default 2
alter table Cookbook add CookbookDesc as case 
    when CookbookSkill = 1 then 'Beginner'
    when CookbookSkill = 2  then 'Intermediate'
    when CookbookSkill = 3  then 'Advanced'
    end
    persisted
alter table Meal add MealDesc varchar(50) not null default 'Delicious!'
