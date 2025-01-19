CREATE DATABASE ECOMMERCE
GO

USE ECOMMERCE 
GO

CREATE TABLE Marcas
(
IdMarca int identity(1,1) not null,
DescripcionMarca varchar(25) not null,
EstadoMarca bit not null default 1,
CONSTRAINT PK_Marcas PRIMARY KEY (IdMarca)
)
GO

CREATE TABLE Categorias
(
IdCategoria int identity(1,1) not null,
NombreCategoria varchar(25) not null,
EstadoCategoria bit not null default 1,
CONSTRAINT PK_Categorias PRIMARY KEY (IdCategoria)
)
GO

CREATE TABLE Proveedores
(
Id_Proveedores int identity(1,1) not null,
PR_Cuit varchar(25) not null,
PR_Nombre varchar(25) not null,
PR_NombreContacto varchar(25) not null,
PR_CargoContacto varchar(25) not null,
PR_Direccion varchar(35) not null,
PR_Ciudad varchar(25) not null,
PR_CodPostal varchar(5) not null,
PR_Telefono varchar(12) not null,
PR_Estado bit not null default 1,
CONSTRAINT PK_Proveedores PRIMARY KEY (Id_Proveedores)
)
GO


CREATE TABLE Articulos
(
IdArticulo int identity(1,1) not null,
Art_Descripcion varchar(25) not null,
Art_IdCategoria int not null,
Art_IdMarca int not null,
Art_Proveedor int not null,
Art_Nombre varchar (25) not null,
Art_Stock int not null,
Art_UrlImagen varchar (800) not null,
Art_Precio decimal (8,2) not null,
Art_StockMinimo int default 15 not null,
Art_Estado bit default 1 not null,
CONSTRAINT PK_Articulos PRIMARY KEY (IdArticulo), 
CONSTRAINT FK_Categorias_Articulos FOREIGN KEY (Art_IdCategoria) REFERENCES Categorias(IdCategoria),
CONSTRAINT FK_Marcas_Articulos FOREIGN KEY (Art_IdMarca) REFERENCES Marcas (IdMarca),
CONSTRAINT FK_Proveedores_Articulos FOREIGN KEY (Art_Proveedor) REFERENCES Proveedores(Id_Proveedores) 
)
GO

CREATE TABLE Clientes
(
CL_DNI char (8) not null,
CL_Nombre varchar (25) not null,
CL_Apellido varchar (25) not null,
CL_Direccion varchar (25) not null,
CL_Provincia varchar (25) not null,
CL_CodPostal varchar (5) not null,
CL_Email char (50) not null unique,
CL_Password char (30) not null,
CL_Estado bit default 1 not null,
CL_Tipo bit default 0 not null,
CONSTRAINT PK_Clientes PRIMARY KEY (CL_DNI)
)
GO

CREATE TABLE Ventas
(
Vta_NroFactura int identity(1000,1) not null,
Vta_DNI char (8) not null, 
Vta_Fecha DATE default getdate() not null,
Vta_Monto decimal (8,2) default 0 not null,
Vta_MetodoPago varchar (10) not null,
CONSTRAINT PK_Ventas PRIMARY KEY (Vta_NroFactura),
CONSTRAINT FK_Clientes_Ventas FOREIGN KEY (Vta_DNI) REFERENCES Clientes (CL_DNI)
)
GO

CREATE TABLE Detalle_Ventas
(
DV_NroFactura int not null,
DV_IdArticulo int not null,
DV_Precio decimal (8,2) not null,
DV_Cantidad int not null,
CONSTRAINT PK_Detalle_Ventas PRIMARY KEY(DV_NroFactura,DV_IdArticulo),
CONSTRAINT FK_Ventas_Detalle_Ventas FOREIGN KEY(DV_NroFactura) REFERENCES Ventas(Vta_NroFactura),
CONSTRAINT FK_Articulos_Detalle_Ventas FOREIGN KEY(DV_IdArticulo) REFERENCES Articulos(IdArticulo)
)
GO

