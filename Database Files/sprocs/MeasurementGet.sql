create or alter proc dbo.MeasurementGet(
    @MeasurementTypeId int = 0,
    @All bit = 0,
    @Message varchar (500) = '' output,
    @IncludeBlank bit = 0
)
as 
begin 
    declare @return int = 0 

    select @All = isnull(@All, 0), @MeasurementTypeId = isnull(@MeasurementTypeId, 0), @IncludeBlank = ISNULL(@IncludeBlank,0)

    select m.measurementtypeid, m.measurementtype, ri.measurementamount, ri.recipeingredientid
    from measurementtype m
    join recipeingredient ri 
    on ri.measurementtypeid = m.measurementtypeid
    where m.measurementtypeid = @MeasurementTypeId
    or @All = 1
    union SELECT 0, ' ', ' ', 0
    where @IncludeBlank = 1
    
return @return
end 
go 