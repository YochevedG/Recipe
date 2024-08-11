create or alter proc dbo.MeasurementDelete(
    @MeasurementTypeId int = 0,
    @Message varchar(500) = '' output
)
as 
begin 
    declare @return int = 0 
    
    delete recipeingredient where measurementtypeid = @MeasurementTypeId

    delete measurementtype where measurementtypeid = @MeasurementTypeId

    return @return

end 
go

