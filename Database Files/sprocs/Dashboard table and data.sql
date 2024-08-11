use RecipeDB
drop table if exists Dashboard

create table dbo.Dashboard(
    DashboardId int not null identity primary key,
    DashboardType varchar (50) not null,
    Num int not null 
)
go 

delete Dashboard

insert Dashboard(DashboardType, Num)
select 'Recipes', count(r.recipeid) from recipe r
union select 'Meals', count(mealid) from meal m 
union select 'Cookbooks', count(cookbookid) from cookbook c 

select * from Dashboard