-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Volcado de Datos --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
USE dbmeven

-- Insertar Datos Tabla Categoria de Productos
IF EXISTS (SELECT name FROM sys.tables WHERE name = 'product_category')
BEGIN
	CREATE TABLE #TempCSV_products (
		supermarket NVARCHAR(255) DEFAULT NULL,
		category VARCHAR(255) DEFAULT NULL,
		name VARCHAR(255) DEFAULT NULL,
		description VARCHAR(255) DEFAULT NULL,
		price VARCHAR(255) DEFAULT NULL,
		reference_price VARCHAR(255) DEFAULT NULL,
		reference_unit VARCHAR(255) DEFAULT NULL,
		insert_date VARCHAR(255) DEFAULT NULL
	);

	BULK INSERT #TempCSV_products
	FROM 'D:\CarpetaProtegida\CPO-2\evendcore_venta\WebDBVentas\CSV\database_csv_products.csv'
	WITH (
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2,
		CODEPAGE = '65001',
		MAXERRORS = 1000,
		TABLOCK
	);

	INSERT INTO Ventas.product_category ([description])
	SELECT DISTINCT category
	FROM #TempCSV_products;
	PRINT('[MENSAJE] Se insertó correctamente los datos del csv')

END


-- Insertar Datos Tabla Supply_type
INSERT INTO Ventas.supply_type (description)
VALUES 
('Proveedor de arroz'),
('Proveedor de azúcar'),
('Proveedor de leche evaporada'),
('Proveedor de aceite vegetal'),
('Proveedor de legumbres secas'),
('Proveedor de harina de trigo'),
('Proveedor de fideos'),
('Proveedor de pan'),
('Proveedor de avena'),
('Proveedor de agua embotellada'),
('Proveedor de sal yodada'),
('Proveedor de atún en conserva'),
('Proveedor de sardinas en conserva'),
('Proveedor de pollo'),
('Proveedor de huevos'),
('Proveedor de carne de res'),
('Proveedor de cerdo'),
('Proveedor de pescado fresco'),
('Proveedor de frutas frescas'),
('Proveedor de verduras frescas'),
('Proveedor de papas'),
('Proveedor de cebollas'),
('Proveedor de ajos'),
('Proveedor de ají amarillo'),
('Proveedor de plátanos'),
('Proveedor de manzanas'),
('Proveedor de naranjas'),
('Proveedor de alimentos para bebés'),
('Proveedor de productos de higiene personal'),
('Proveedor de papel higiénico'),
('Proveedor de detergente en polvo'),
('Proveedor de jabón de lavar'),
('Proveedor de desinfectantes'),
('Proveedor de productos de limpieza para el hogar'),
('Proveedor de pañales desechables'),
('Proveedor de alcohol en gel'),
('Proveedor de mascarillas descartables'),
('Proveedor de guantes descartables'),
('Proveedor de conservas de frutas'),
('Proveedor de mermeladas'),
('Proveedor de miel de abeja'),
('Proveedor de lácteos'),
('Proveedor de quesos'),
('Proveedor de yogurt'),
('Proveedor de bebidas gaseosas'),
('Proveedor de jugos naturales embotellados'),
('Proveedor de galletas'),
('Proveedor de snacks saludables'),
('Proveedor de cereales para desayuno'),
('Proveedor de café instantáneo'),
('Proveedor de té en bolsitas');


-- Insertar Datos Tabla Identification_Type
INSERT INTO Ventas.identification_type (description)
VALUES 
('Documento Nacional de Identidad (DNI)'),
('Carné de Extranjería'),
('Registro Único de Contribuyente (RUC)'),
('Pasaporte'),
('Permiso Temporal de Permanencia (PTP)'),
('Cédula de Identidad'),
('Licencia de Conducir'),
('Carné de Identidad Militar'),
('Carné Universitario'),
('Tarjeta de Identificación Tributaria (TIT)'),
('Tarjeta de Identificación Consular'),
('Documento Provisional de Identidad'),
('Certificado de Nacimiento Digital'),
('Identificación Biométrica'),
('Carné de Seguro Social'),
('Código de Identificación Tributaria para Extranjeros'),
('Carné de Pesca Artesanal'),
('Carné de Agricultor Familiar'),
('Carné de Discapacidad (CONADIS)'),
('Certificado de Trabajador Independiente');


-- Insertar Datos Tabla Role
INSERT INTO Ventas.role (description)
VALUES 
('Administrador'),
('Vendedor'),
('Cajero');


-- Insertar Datos Tabla Billing_type
INSERT INTO Ventas.billing_type (type_name)
VALUES 
('Factura Electrónica'),
('Boleta de Venta Electrónica'),
('Nota de Crédito Electrónica'),
('Nota de Débito Electrónica'),
('Recibo por Honorarios Electrónico');


-- Insertar Datos Tabla Payment_method
INSERT INTO Ventas.payment_method (description)
VALUES 
('Efectivo'),
('Tarjeta de Débito'),
('Tarjeta de Crédito'),
('Transferencia Bancaria'),
('Yape'),
('Plin'),
('Pago contra Entrega'),
('Depósito Bancario');


-- Insertar registros en Transaction_type
INSERT INTO Ventas.transaction_type (description)
VALUES 
('Compra'),
('Venta'),
('Devolución'),
('Transferencia de Stock'),
('Pedido de Proveedor');


-- Insertar Datos Tabla Reward_type
INSERT INTO Ventas.reward_type (description)
VALUES 
-- Recompensas para clientes
('Descuento en próxima compra'),
('Envío gratis en pedidos mayores a un monto'),
('Puntos de fidelidad acumulables'),
('Producto gratis por acumulación de puntos'),
('Promoción 2x1 en productos seleccionados'),
('Cupón de descuento por referir a un amigo'),
('Doble puntaje en compras de productos seleccionados'),
('Acceso anticipado a promociones'),
('Regalo por compras mayores a un monto'),
('Sorteo mensual de premios'),
('Descuento en productos de primera necesidad'),
('Promoción exclusiva para días festivos'),
('Cashback en compras mayores a un monto'),
('Regalo sorpresa en la tienda'),
('Membresía gratuita por un mes'),

-- Recompensas para empleados
('Bonificación mensual por objetivos cumplidos'),
('Reconocimiento como empleado del mes'),
('Días libres adicionales'),
('Acceso a programas de formación'),
('Vales de consumo en la tienda'),
('Premios físicos (productos o electrodomésticos)'),
('Descuento exclusivo en compras personales'),
('Puntos canjeables por días libres'),
('Entradas para eventos sociales'),
('Vales de gasolina o transporte'),
('Acceso a sorteos internos'),
('Bonificación especial por metas superadas'),

-- Recompensas generales
('Badge de cliente VIP'),
('Certificado de agradecimiento por fidelidad'),
('Acceso a promociones por cumpleaños');


-- Insertar Datos Tabla Content
INSERT INTO Central.content (title, description)
VALUES 
('Productos', 'Explora nuestra variedad de productos diseñados para satisfacer tus necesidades.'),
('Soluciones', 'Descubre cómo nuestras soluciones pueden transformar tu negocio.'),
('Recursos', 'Accede a guías, tutoriales y materiales de apoyo para aprovechar al máximo nuestros productos y servicios.'),
('Extensiones', 'Personaliza y potencia tu experiencia con nuestras extensiones y herramientas adicionales.'),
('Precios', 'Consulta nuestros planes y precios competitivos.');