Select * from TblClients

Select Min(Id) from TblClients
where Id > (select Min(Id) from TblClients)


Select Max(Id) from TblClients
where Id < (select Max(Id) from TblClients)

Select ROW_NUMBER() OVER(ORDER BY Id DESC) AS RowIndex, * from TblClients