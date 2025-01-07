USE ECOMMERCE 
GO

--STORE PROCEDURE
CREATE PROCEDURE NuevoCliente
@dni char(8),
@nombre varchar(25),
@apellido varchar(25),
@direccion varchar(25),
@provincia varchar(25),
@codPostal varchar(5),
@email char(50),
@pass char(50)
as
insert into Clientes (CL_DNI,CL_Nombre,CL_Apellido,CL_Direccion,CL_Provincia,CL_CodPostal,CL_Email,CL_Password,CL_Estado, CL_Tipo) output inserted.CL_DNI values (@dni,@nombre,@apellido,@direccion,@provincia,@codPostal,@email,@pass, 1, 0)

--CONSULTAS
SELECT TOP 5 IdArticulo,Art_Nombre, Art_UrlImagen, Art_Precio FROM Articulos ORDER BY NEWID()

SELECT CL_DNI, CL_Nombre,CL_Apellido,CL_Direccion,CL_Provincia,CL_CodPostal, CL_Email,CL_Password,CL_Estado,CL_Tipo FROM CLIENTES ORDER BY CL_Apellido
