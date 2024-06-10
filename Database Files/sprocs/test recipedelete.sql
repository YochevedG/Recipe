declare @PresidentId int 

select top 1 @PresidentId = p.PresidentId 
from president p 
left join ExecutiveOrder e 
on e.PresidentId = p.PresidentId
left join PresidentMedal pm 
on pm.PresidentId = p.PresidentId
where e.ExecutiveOrderId is null 
and pm.PresidentMedalId is null
order by p.PresidentId

select * from president p where p.presidentid = @PresidentId

exec PresidentDelete @PresidentId = @PresidentId

select * from president p where p.presidentid = @PresidentId