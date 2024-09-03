
--Create database dbCastor
--go
if object_id('fkRol') is not null
  alter table dbo.Tb_Usuario
  drop constraint fkRol;
go

if object_id('fkUsuarioProd') is not null
  alter table dbo.Tb_Producto
  drop constraint fkUsuarioProd;
go

if object_id('fkUsuarioVenta') is not null
  alter table dbo.Tb_Venta
  drop constraint fkUsuarioVenta;
go

if object_id('fkProd') is not null
  alter table dbo.Tb_Venta
  drop constraint fkProd;
go

if object_id('dbo.Tb_Rol') is not null
  drop table dbo.Tb_Rol
go

create table dbo.Tb_Rol(
  idRol int Identity(1,1) primary key
  , descripcion nvarchar(100)
  , estatus int default 1
  , fechaAlta datetime
  , fechaModificacion datetime
)

if object_id('dbo.Tb_Usuario') is not null
  drop table dbo.Tb_Usuario
go

create table dbo.Tb_Usuario(
  idUsuario int Identity(1,1) primary key
  , nombre nvarchar(100)
  , correo nvarchar(100)
  , idRol int
  , contrasena varchar(25)
  , estatus int
  , fechaAlta datetime
  , fechaModificacion datetime
  , constraint fkRol foreign key (idRol) references dbo.Tb_Rol(idRol) 
  
)
if object_id('dbo.Tb_Producto') is not null
  drop table dbo.Tb_Producto
go

create table Tb_Producto(
  idProducto int identity(1,1) primary key
  , nombre varchar(40)
  , precio decimal(16,2)
  , estatus int
  , fechaAlta datetime
  , fechaModificacion datetime
  , idUsuario int
  , constraint fkUsuarioProd foreign key (idUsuario) references dbo.Tb_Usuario(idUsuario) 
)

if object_id('dbo.Tb_Venta') is not null
  drop table dbo.Tb_Venta
go
create table dbo.Tb_Venta(
  idVenta int identity(1,1) primary key
  , idProducto int
  , cantidad int
  , estatus int
  , fechaAlta datetime
  , fechaModificacion datetime
  , idUsuario int
  , constraint fkUsuarioVenta foreign key (idUsuario) references dbo.Tb_Usuario(idUsuario)
  , constraint fkProd foreign key (idProducto) references dbo.Tb_Producto(idProducto)
  ) 