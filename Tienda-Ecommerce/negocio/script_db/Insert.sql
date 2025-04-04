--CARGA DE DATOS

INSERT INTO Marcas (DescripcionMarca)
VALUES
('Nike'),
('Adidas'),
('Puma'),
('Under Armour'),
('Reebok');

INSERT INTO Categorias (NombreCategoria)
VALUES
('Camisetas'),
('Buzos'),
('Zapatillas'),
('Accesorios'),
('Musculosas');

INSERT INTO Proveedores (PR_Cuit, PR_Nombre, PR_NombreContacto, PR_CargoContacto, PR_Direccion, PR_Ciudad, PR_CodPostal, PR_Telefono)
VALUES
('30-12345678-9', 'Distribuidora RC', 'Omar Palma', 'Gerente de Ventas', 'Av. Avellaneda 1889', 'Rosario', '2000', '03412345678'),
('33-98765432-1', 'Suministros ROSARIO', 'Andres Bracamonte', 'Jefe de Compras', 'Cordiviola 2023', 'Rosario', '2000', '03411234567'),
('20-87654321-0', 'Proveedores Globales', 'Marco Ruben', 'Coordinador', 'Genova 19', 'C�rdoba', '5000', '03514321098');

INSERT INTO Articulos (Art_Descripcion, Art_IdCategoria, Art_IdMarca, Art_Proveedor, Art_Nombre, Art_Stock, Art_UrlImagen, Art_Precio, Art_StockMinimo)
VALUES
('Zapatillas Running', 3, 1, 1, 'Zapatillas Nike Air', 50, 'https://www.dexter.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw7da80f66/products/NI_CW4555-102/NI_CW4555-102-1.JPG', 12000.50, 10),
('Camiseta Futbol', 1, 2, 2, 'Camiseta Rosario Central', 30, 'https://www.stockcenter.com.ar/on/demandware.static/-/Sites-365-dabra-catalog/default/dw3431123e/products/UBU33RC01722-7268/UBU33RC01722-7268-1.JPG', 75000.00, 15),
('Buzo Argentina', 2, 3, 3, 'Buzo Seleccion', 20, 'https://afaar.vtexassets.com/arquivos/ids/156650-800-auto?v=638459614573470000&width=800&height=auto&aspect=true', 110000.50, 10);

INSERT INTO Clientes (CL_DNI, CL_Nombre, CL_Apellido, CL_Direccion, CL_Provincia, CL_CodPostal, CL_Email, CL_Password, CL_Estado, CL_Tipo)
VALUES
('57102939', 'Mateo', 'Gonzalez', 'Calle 18', 'Buenos Aires', '1001', 'mateo.g@gmail.com', 'password123', 1, 0),
('33000555', 'Paula', 'Rodriguez', 'Calle 2', 'Santa Fe', '3000', 'paula.r@gmail.com', 'paula123', 1, 0),
('35583958', 'Martin', 'Iba�ez', 'Calle 3', 'Rosario', '2000', 'admin@admin.com', 'admin', 1, 1);