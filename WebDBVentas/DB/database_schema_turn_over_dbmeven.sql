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
	PRINT('[MENSAJE] Se insert� correctamente los datos del csv')

END


-- Insertar Datos Tabla Supply_type
INSERT INTO Ventas.supply_type (description)
VALUES 
('Proveedor de arroz'),
('Proveedor de az�car'),
('Proveedor de leche evaporada'),
('Proveedor de aceite vegetal'),
('Proveedor de legumbres secas'),
('Proveedor de harina de trigo'),
('Proveedor de fideos'),
('Proveedor de pan'),
('Proveedor de avena'),
('Proveedor de agua embotellada'),
('Proveedor de sal yodada'),
('Proveedor de at�n en conserva'),
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
('Proveedor de aj� amarillo'),
('Proveedor de pl�tanos'),
('Proveedor de manzanas'),
('Proveedor de naranjas'),
('Proveedor de alimentos para beb�s'),
('Proveedor de productos de higiene personal'),
('Proveedor de papel higi�nico'),
('Proveedor de detergente en polvo'),
('Proveedor de jab�n de lavar'),
('Proveedor de desinfectantes'),
('Proveedor de productos de limpieza para el hogar'),
('Proveedor de pa�ales desechables'),
('Proveedor de alcohol en gel'),
('Proveedor de mascarillas descartables'),
('Proveedor de guantes descartables'),
('Proveedor de conservas de frutas'),
('Proveedor de mermeladas'),
('Proveedor de miel de abeja'),
('Proveedor de l�cteos'),
('Proveedor de quesos'),
('Proveedor de yogurt'),
('Proveedor de bebidas gaseosas'),
('Proveedor de jugos naturales embotellados'),
('Proveedor de galletas'),
('Proveedor de snacks saludables'),
('Proveedor de cereales para desayuno'),
('Proveedor de caf� instant�neo'),
('Proveedor de t� en bolsitas');


-- Insertar Datos Tabla Identification_Type
INSERT INTO Ventas.identification_type (description)
VALUES 
('Documento Nacional de Identidad (DNI)'),
('Carn� de Extranjer�a'),
('Registro �nico de Contribuyente (RUC)'),
('Pasaporte'),
('Permiso Temporal de Permanencia (PTP)'),
('C�dula de Identidad'),
('Licencia de Conducir'),
('Carn� de Identidad Militar'),
('Carn� Universitario'),
('Tarjeta de Identificaci�n Tributaria (TIT)'),
('Tarjeta de Identificaci�n Consular'),
('Documento Provisional de Identidad'),
('Certificado de Nacimiento Digital'),
('Identificaci�n Biom�trica'),
('Carn� de Seguro Social'),
('C�digo de Identificaci�n Tributaria para Extranjeros'),
('Carn� de Pesca Artesanal'),
('Carn� de Agricultor Familiar'),
('Carn� de Discapacidad (CONADIS)'),
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
('Factura Electr�nica'),
('Boleta de Venta Electr�nica'),
('Nota de Cr�dito Electr�nica'),
('Nota de D�bito Electr�nica'),
('Recibo por Honorarios Electr�nico');


-- Insertar Datos Tabla Payment_method
INSERT INTO Ventas.payment_method (description)
VALUES 
('Efectivo'),
('Tarjeta de D�bito'),
('Tarjeta de Cr�dito'),
('Transferencia Bancaria'),
('Yape'),
('Plin'),
('Pago contra Entrega'),
('Dep�sito Bancario');


-- Insertar registros en Transaction_type
INSERT INTO Ventas.transaction_type (description)
VALUES 
('Compra'),
('Venta'),
('Devoluci�n'),
('Transferencia de Stock'),
('Pedido de Proveedor');


-- Insertar Datos Tabla Reward_type
INSERT INTO Ventas.reward_type (description)
VALUES 
-- Recompensas para clientes
('Descuento en pr�xima compra'),
('Env�o gratis en pedidos mayores a un monto'),
('Puntos de fidelidad acumulables'),
('Producto gratis por acumulaci�n de puntos'),
('Promoci�n 2x1 en productos seleccionados'),
('Cup�n de descuento por referir a un amigo'),
('Doble puntaje en compras de productos seleccionados'),
('Acceso anticipado a promociones'),
('Regalo por compras mayores a un monto'),
('Sorteo mensual de premios'),
('Descuento en productos de primera necesidad'),
('Promoci�n exclusiva para d�as festivos'),
('Cashback en compras mayores a un monto'),
('Regalo sorpresa en la tienda'),
('Membres�a gratuita por un mes'),

-- Recompensas para empleados
('Bonificaci�n mensual por objetivos cumplidos'),
('Reconocimiento como empleado del mes'),
('D�as libres adicionales'),
('Acceso a programas de formaci�n'),
('Vales de consumo en la tienda'),
('Premios f�sicos (productos o electrodom�sticos)'),
('Descuento exclusivo en compras personales'),
('Puntos canjeables por d�as libres'),
('Entradas para eventos sociales'),
('Vales de gasolina o transporte'),
('Acceso a sorteos internos'),
('Bonificaci�n especial por metas superadas'),

-- Recompensas generales
('Badge de cliente VIP'),
('Certificado de agradecimiento por fidelidad'),
('Acceso a promociones por cumplea�os');


-- Insertar Datos Tabla Content
INSERT INTO Central.content (title, description)
VALUES 
('Productos', 'Explora nuestra variedad de productos dise�ados para satisfacer tus necesidades.'),
('Soluciones', 'Descubre c�mo nuestras soluciones pueden transformar tu negocio.'),
('Recursos', 'Accede a gu�as, tutoriales y materiales de apoyo para aprovechar al m�ximo nuestros productos y servicios.'),
('Extensiones', 'Personaliza y potencia tu experiencia con nuestras extensiones y herramientas adicionales.'),
('Precios', 'Consulta nuestros planes y precios competitivos.');