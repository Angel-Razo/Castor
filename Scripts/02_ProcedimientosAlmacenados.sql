
if object_id('dbo.Usp_Tb_Usuario_Ins') is not null
  drop procedure dbo.Usp_Tb_Usuario_Ins
go

create procedure dbo.Usp_Tb_Usuario_Ins
  @nombre varchar(100)
  , @correo varchar(100)
  , @contrasena varchar(25)
  , @idRol int
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Usuario_Ins "Jose Razo", "j.razo@razo.com","password", 1
 
*/
begin 
  declare
    @Activo int
  set
    @Activo = 1
  if exists (select * from dbo.Tb_Rol where idRol = @idRol)
  begin

    if not exists(select us.idUsuario from dbo.Tb_Usuario us where us.nombre=@nombre)
      begin
        insert into 
          dbo.Tb_Usuario  
          (nombre
          , correo
          , idRol
          , contrasena
          , fechaAlta
          , estatus)
        values 
          (@nombre
          , @correo
          , @idRol
          , @contrasena
          , getdate()
          ,1)
         
        select [idUsuario] = @@identity
      end
    
  else
    begin
      
      update 
        dbo.Tb_Usuario
      set
        estatus = @Activo
        , fechaModificacion = getdate() 
      where
        correo = @correo
        and contrasena = @contrasena
      
      select 
        us.idUsuario 
      from 
        dbo.Tb_Usuario us
      where 
        us.nombre=@nombre
    end
  end
  else
  select [idUsuario] = 0
end
go

if object_id('dbo.Usp_Tb_Rol_Ins') is not null
  drop procedure dbo.Usp_Tb_Rol_Ins
go

create procedure dbo.Usp_Tb_Rol_Ins
  @descripcion varchar(100)
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Rol_Ins "Administrador"
 
*/
begin 
  if not exists(select ro.idRol from dbo.Tb_Rol ro where ro.descripcion = @descripcion)
    begin
      insert into 
        dbo.Tb_Rol  
        (descripcion
        , fechaAlta
        , estatus)
      values 
        (@descripcion
        , getdate()
        ,1)
       
      select [idRol] = @@identity
    end
  else
    begin
      select 
        ro.idRol
      from 
        dbo.Tb_Rol ro
      where 
        ro.descripcion=@descripcion
    end
  
end
go

if object_id('dbo.Usp_Tb_Usuario_Obt') is not null
  drop procedure dbo.Usp_Tb_Usuario_Obt
go

create procedure dbo.Usp_Tb_Usuario_Obt
  @correo varchar(100)
  , @contrasena varchar(25)
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Usuario_Obt "j.razo@razo.com","password"
 
*/
begin

  declare
    @Activo int 
  set
    @Activo = 1
  select
    us.idUsuario
    , us.nombre
    , us.correo
    , us.idRol
    , ro.descripcion
    , us.estatus
    , us.fechaAlta
    , us.contrasena
  from
    dbo.Tb_Usuario us
    inner join
    dbo.Tb_Rol ro
    on
      ro.idRol = us.idRol
    
  where
    us.correo = @correo
    and us.contrasena = @contrasena
    --and us.estatus = @Activo
  
end
go

if object_id('dbo.Usp_Tb_Usuario_Eli') is not null
  drop procedure dbo.Usp_Tb_Usuario_Eli
go

create procedure dbo.Usp_Tb_Usuario_Eli
  @correo varchar(100)
  , @contrasena varchar(25)
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Usuario_Eli "j.razo@razo.com","password"
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
  update 
    dbo.Tb_Usuario
  set
    estatus = @Inactivo 
    , fechaModificacion = getdate()
  where
    correo = @correo
    and contrasena = @contrasena
  
  select 
    us.idUsuario
  from 
    dbo.Tb_Usuario us 
  where 
    us.correo = @correo 
    and us.contrasena = @contrasena

end
go



