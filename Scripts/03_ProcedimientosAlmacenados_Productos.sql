
if object_id('dbo.Usp_Tb_Producto_Ins') is not null
  drop procedure dbo.Usp_Tb_Producto_Ins
go

create procedure dbo.Usp_Tb_Producto_Ins
  @nombre varchar(40)
  , @precio decimal(16,2)
  , @idUsuario int
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Producto_Ins "laptop Gamer", 5000, 1
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
    
  if not exists( select idProducto from dbo.Tb_Producto where nombre = @nombre)  
  begin  
    insert into 
        dbo.Tb_Producto  
        (nombre
        , precio
        , fechaAlta
        , estatus
        , idUsuario)
      values 
        ( @nombre
        , @precio
        , getdate()
        , 1
        , @idUsuario)
  
    select [idProducto]=@@identity
    
  end
  else
  begin
    select [idProducto]= 0
  end
end
go


if object_id('dbo.Usp_Tb_Producto_Obt') is not null
  drop procedure dbo.Usp_Tb_Producto_Obt
go

create procedure dbo.Usp_Tb_Producto_Obt
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Producto_Obt 
 
*/
begin 
  declare
    @Activo int
  set
    @Activo = 1
  select
    pr.idProducto
    , pr.nombre
    , pr.precio
    , pr.estatus
    , pr.fechaAlta
    , [fechaModificacion] = coalesce(pr.fechaModificacion, '1900-01-01')
    , [idUsuario] = coalesce(pr.idUsuario, 0)
  from
    dbo.Tb_Producto pr
  where
    pr.estatus = @Activo
  
end
go

if object_id('dbo.Usp_Tb_Producto_Obt_Todo') is not null
  drop procedure dbo.Usp_Tb_Producto_Obt_Todo
go

create procedure dbo.Usp_Tb_Producto_Obt_Todo
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Producto_Obt_Todo
 
*/
begin 
  declare
    @Activo int
  set
    @Activo = 1
  select
    pr.idProducto
    , pr.nombre
    , pr.precio
    , pr.estatus
    , pr.fechaAlta
    , [fechaModificacion] = coalesce(pr.fechaModificacion, '1900-01-01')
    , [idUsuario] = coalesce(pr.idUsuario, 0)
  from
    dbo.Tb_Producto pr
  
end
go

if object_id('dbo.Usp_Tb_Producto_Eli') is not null
  drop procedure dbo.Usp_Tb_Producto_Eli
go 

create procedure dbo.Usp_Tb_Producto_Eli
  @idProducto int
  , @idUsuario int
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Producto_Eli 1,1
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
    
  if exists ( select pr.idProducto from dbo.Tb_Producto pr where idProducto = @idProducto)  
  begin  
    update 
      dbo.Tb_Producto
    set
      estatus = @Inactivo 
      , fechaModificacion = getdate()
      , idUsuario = @idUsuario
    where
      idProducto = @idProducto
  
    select [idProducto]=@idProducto
    
  end
  else
  begin
    select [idProducto]= 0
  end
end
go

if object_id('dbo.Usp_Tb_Producto_Act') is not null
  drop procedure dbo.Usp_Tb_Producto_Act
go 

create procedure dbo.Usp_Tb_Producto_Act
  @idProducto int
  , @idUsuario int
  , @nombre varchar(40)
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Producto_Act 1,1
 
*/
begin 
  declare
    @Activo int
  set
    @Activo = 1
    
  if exists ( select pr.idProducto from dbo.Tb_Producto pr where idProducto = @idProducto)  
  begin  
    update 
      dbo.Tb_Producto
    set
      estatus = @Activo 
      , nombre = @nombre
      , fechaModificacion = getdate()
      , idUsuario = @idUsuario
    where
      idProducto = @idProducto
  
    select [idProducto]=@idProducto
    
  end
  else
  begin
    select [idProducto]= 0
  end
end
go