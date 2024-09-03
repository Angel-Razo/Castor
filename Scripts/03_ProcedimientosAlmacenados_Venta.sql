


if object_id('dbo.Usp_Tb_Venta_Ins') is not null
  drop procedure dbo.Usp_Tb_Venta_Ins
go

create procedure dbo.Usp_Tb_Venta_Ins
  @idProducto int
  , @idUsuario int
  , @Cantidad int
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Venta_Ins 1, 1
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
    
  if exists ( select vn.idVenta from dbo.Tb_Venta vn  where vn.idVenta = @idVenta)  
  begin  
    update 
      dbo.Tb_Venta
    set
      estatus = @Inactivo 
      , fechaModificacion = getdate()
      , idUsuario = @idUsuario
    where
      idVenta = @idVenta
  
    select [idVenta] = @idVenta
      
  end
  else
  begin
    select [idVenta] = 0
  end
end
go

if object_id('dbo.Usp_Tb_Venta_Eli') is not null
  drop procedure dbo.Usp_Tb_Venta_Eli
go

create procedure dbo.Usp_Tb_Venta_Eli
  @idVenta int
  , @idUsuario int
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Venta_Eli 1, 1
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
    
  if exists ( select vn.idVenta from dbo.Tb_Venta vn  where vn.idVenta = @idVenta)  
  begin  
    update 
      dbo.Tb_Venta
    set
      estatus = @Inactivo 
      , fechaModificacion = getdate()
      , idUsuario = @idUsuario
    where
      idVenta = @idVenta
  
    select [idVenta] = @idVenta
      
  end
  else
  begin
    select [idVenta] = 0
  end
end
go