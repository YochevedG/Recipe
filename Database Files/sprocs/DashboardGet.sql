create or alter proc dbo.DashboardGet(
    @Dashboardid int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output
)
as 
begin 
    declare @return int = 0

    select * from dashboard 
    where dashboardid = @Dashboardid
    or @All = 1 

    return @return
end 

exec DashboardGet @all = 1