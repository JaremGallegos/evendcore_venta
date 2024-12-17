IF DB_ID('dbmeven') IS NULL
BEGIN
	CREATE DATABASE dbmeven;
	PRINT 'Base de datos dbmeven creada.';
END
ELSE
BEGIN
    ALTER DATABASE dbmeven SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE dbmeven;
    CREATE DATABASE dbmeven;
    PRINT 'Base de datos dbmeven recreada.';
END
GO

USE dbmeven;
GO

CREATE SCHEMA Ventas;
GO

CREATE SCHEMA Central;
GO
------------------------------------------------------------------------
-- Tabla BILLING (Factura) schema VENTAS
CREATE TABLE Ventas.[billing] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[date] DATETIME NOT NULL DEFAULT GETDATE(),
	[code] VARCHAR(50) NOT NULL DEFAULT '',
	[authorized] BIT NOT NULL DEFAULT 1,
	[bill_date] DATETIME NOT NULL DEFAULT GETDATE(),
	[process_date] DATETIME NOT NULL DEFAULT GETDATE(),
	[supplier_id] BIGINT NOT NULL,
	[billing_type_id] TINYINT NOT NULL,
	[employee_id] BIGINT NOT NULL,
	[customer_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla CUSTOMER (Cliente) schema VENTAS
CREATE TABLE Ventas.[customer] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[in] VARCHAR(20) NOT NULL DEFAULT '',
	[name] VARCHAR(100) NOT NULL DEFAULT '',
	[fname] VARCHAR(100) NOT NULL DEFAULT '',
	[mname] VARCHAR(100) NOT NULL DEFAULT '',
	[sex] BIT NOT NULL DEFAULT 1,
	[DOB] DATE NOT NULL DEFAULT GETDATE(),
	[phone] VARCHAR(15) NOT NULL DEFAULT '',
	[last_updated] DATETIME NOT NULL DEFAULT GETDATE(),
	[identification_type_id] TINYINT NOT NULL,
	[address_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla MODULE (Modulo) schema VENTAS
CREATE TABLE Ventas.[module] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[mod_name] VARCHAR(100) NOT NULL DEFAULT '',
	[mod_type] VARCHAR(50) NOT NULL DEFAULT '',
	[mod_active] BIT NOT NULL DEFAULT 1,
	[mod_relative_link] VARCHAR(255) NOT NULL DEFAULT '',
	[mod_ui_order] INT NOT NULL DEFAULT '',
	[mod_description] VARCHAR(255) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY([id])
);

-- Tabla PRODUCT (Producto) schema VENTAS
CREATE TABLE Ventas.[product] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[name] VARCHAR(255) NOT NULL DEFAULT '',
	[code_number] VARCHAR(50) NOT NULL DEFAULT '',
	[stock] INT NOT NULL DEFAULT 0,
	[min_stock] INT NOT NULL DEFAULT 0,
	[max_stock] INT NOT NULL DEFAULT 0,
	[active] BIT NOT NULL DEFAULT 1,
	[price] DECIMAL(4,2) NOT NULL DEFAULT 0,
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[product_category_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla AUDIT_MASTER (Auditoria)
CREATE TABLE [audit_master] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[approval_status] VARCHAR(50) NOT NULL DEFAULT '',
	[created_time] DATETIME NOT NULL DEFAULT GETDATE(),
	[modified_time] DATETIME NOT NULL DEFAULT GETDATE(),
	[ip_address] VARCHAR(45) NOT NULL DEFAULT '',
	[type] VARCHAR(45) NOT NULL DEFAULT '',
	[employee_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla SUPPLIER (Proveedor) schema VENTAS
CREATE TABLE Ventas.[supplier] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[in] VARCHAR(255) NOT NULL DEFAULT '',
	[name] VARCHAR(255) NOT NULL DEFAULT '',
	[contact_name] VARCHAR(255) NOT NULL DEFAULT '',
	[email] VARCHAR(255) NOT NULL DEFAULT '',
	[phone] VARCHAR(20) NOT NULL DEFAULT '',
	[direction] VARCHAR(255) NOT NULL DEFAULT '',
	[active] BIT NOT NULL DEFAULT 1,
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[supply_type_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla PAYMENT (Pagos) schema VENTAS
CREATE TABLE Ventas.[payment] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[date] DATETIME NOT NULL DEFAULT GETDATE(),
	[amount] DECIMAL(4,2) NOT NULL DEFAULT 0,
	[status] VARCHAR(50) NOT NULL DEFAULT '',
	[sales_id] BIGINT NOT NULL,
	[payment_method_id] TINYINT NOT NULL,
	[billing_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla SYSTEM (Sistema) schema VENTAS
CREATE TABLE Ventas.[system] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[name] VARCHAR(100) NOT NULL DEFAULT '',
	[version] VARCHAR(20) NOT NULL DEFAULT '',
	[status] VARCHAR(20) NOT NULL DEFAULT '', 
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_ad] DATETIME NOT NULL DEFAULT GETDATE(),
	[type] VARCHAR(50) NOT NULL DEFAULT '',
	[environment] VARCHAR(50) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla SALES_DETAIL (Detalles de Venta) schema VENTAS
CREATE TABLE Ventas.[sales_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[notes] VARCHAR(255) DEFAULT NULL,
	[discount] DECIMAL(4,2) DEFAULT NULL,
	[tax_amount] DECIMAL(4,2)  DEFAULT NULL,
	[delivery_status] VARCHAR(50) DEFAULT NULL,
	[delivery_date] DATETIME  DEFAULT NULL,
	[coupon_code] VARCHAR(50) DEFAULT NULL,
	[sales_channel] VARCHAR(50) DEFAULT NULL,
	[sales_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla SALES (Venta) schema VENTAS
CREATE TABLE Ventas.[sales] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[date] DATETIME NOT NULL DEFAULT GETDATE(),
	[total_amount] DECIMAL(6,2) NOT NULL DEFAULT 0,
	[payment_status] VARCHAR(50) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla FACILITY (Organizacion) schema VENTAS
CREATE TABLE Ventas.[facility] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[name] VARCHAR(255) NOT NULL DEFAULT '',
	[phone] VARCHAR(15) NOT NULL DEFAULT '',
	[email] VARCHAR(255) NOT NULL DEFAULT '',
	[direction] VARCHAR(255) NOT NULL DEFAULT '',
	[date_created] DATETIME NOT NULL DEFAULT GETDATE(),
	[last_updated] DATETIME NOT NULL DEFAULT GETDATE(),
	[identification_type_id] TINYINT NOT NULL,
	[address_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla BILLING_DETAIL (Detalle de Facturacion) schema VENTAS
CREATE TABLE Ventas.[billing_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[groupname] VARCHAR(50) DEFAULT NULL,
	[encounter] VARCHAR(50) DEFAULT NULL,
	[code_text] VARCHAR(255) DEFAULT NULL,
	[billed] BIT DEFAULT NULL,
	[activity] VARCHAR(100) DEFAULT NULL,
	[bill_process] VARCHAR(50) DEFAULT NULL,
	[process_file] VARCHAR(255) DEFAULT NULL,
	[modifier] VARCHAR(50) DEFAULT NULL,
	[units] INT DEFAULT NULL,
	[fee] DECIMAL(6,2) DEFAULT NULL,
	[justify] VARCHAR(255) DEFAULT NULL,
	[target] VARCHAR(100) DEFAULT NULL,
	[notecodes] VARCHAR(255) DEFAULT NULL,
	[pricelevel] DECIMAL(6,2) DEFAULT NULL,
	[revenue_code] VARCHAR(50) DEFAULT NULL,
	[chargetcat] VARCHAR(50) DEFAULT NULL,
	[product_id] BIGINT NOT NULL,
	[billing_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla EMPLOYEE (Empleado) schema VENTAS
CREATE TABLE Ventas.[employee] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[in] VARCHAR(20) NOT NULL DEFAULT '',
	[name] VARCHAR(100) NOT NULL DEFAULT '',
	[fname] VARCHAR(100) NOT NULL DEFAULT '',
	[mname] VARCHAR(100) NOT NULL DEFAULT '',
	[email] VARCHAR(255) NOT NULL DEFAULT '',
	[phone] VARCHAR(15) NOT NULL DEFAULT '',
	[status] VARCHAR(30) NOT NULL DEFAULT '',
	[hire_date] DATE NOT NULL DEFAULT GETDATE(),
	[is_active] BIT NOT NULL DEFAULT 1,
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[role_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla PRODUCT_DETAIL (Detalle del Producto) schema VENTAS
CREATE TABLE Ventas.[product_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[on_order] INT DEFAULT NULL,
	[last_notify] DATETIME DEFAULT NULL,
	[problems] VARCHAR(255) DEFAULT NULL,
	[form] VARCHAR(50) DEFAULT NULL,
	[size] VARCHAR(50) DEFAULT NULL,
	[unit] VARCHAR(50) DEFAULT NULL,
	[related_code] VARCHAR(100) DEFAULT NULL,
	[cyp_factor] DECIMAL(4,2) DEFAULT NULL,
	[allow_combining] BIT DEFAULT NULL,
	[no_stock] BIT DEFAULT NULL,
	[dispensable] BIT DEFAULT NULL,
	[description] VARCHAR(255) DEFAULT NULL,
	[cost] DECIMAL(4,2) DEFAULT NULL,
	[tax_rate] DECIMAL(4,2) DEFAULT NULL,
	[barcode] VARCHAR(50) DEFAULT NULL,
	[weight] DECIMAL(4,2) DEFAULT NULL,
	[dimensions] VARCHAR(50) DEFAULT NULL,
	[expiration_date] DATE DEFAULT NULL,
	[supplier_id] BIGINT NOT NULL,
	[setting_id] BIGINT NOT NULL,
	[product_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla MODULE_DETAIL (Detalle del Modulo) schema VENTAS
CREATE TABLE Ventas.[module_detail] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[mod_directory] VARCHAR(255) DEFAULT NULL,
	[mod_ui_name] VARCHAR(100) DEFAULT NULL,
	[mod_ui_active] BIT DEFAULT NULL,
	[mod_nick_name] VARCHAR(50) DEFAULT NULL,
	[mod_enc_menu] VARCHAR(255) DEFAULT NULL,
	[permissions_item_table] VARCHAR(100) DEFAULT NULL,
	[directory] VARCHAR(255) DEFAULT NULL,
	[sql_run] VARCHAR(255) DEFAULT NULL,
	[sql_version] VARCHAR(50) DEFAULT NULL,
	[acl_version] VARCHAR(50) DEFAULT NULL,
	[module_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla FACILITY_DETAIL (Detalle de la Organización) schema VENTAS
CREATE TABLE Ventas.[facility_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[x12_sender_id] VARCHAR(50) DEFAULT NULL,
	[weno_id] VARCHAR(50) DEFAULT NULL,
	[website] VARCHAR(255) DEFAULT NULL,
	[service_location] BIT DEFAULT NULL,
	[billing_location] BIT DEFAULT NULL,
	[accepts_assignment] BIT DEFAULT NULL,
	[pos_code] VARCHAR(20) DEFAULT NULL,
	[attn] VARCHAR(255) DEFAULT NULL,
	[domain_identifier] VARCHAR(255) DEFAULT NULL,
	[color] VARCHAR(10) DEFAULT NULL,
	[primary_business_entity] BIT DEFAULT NULL,
	[facility_code] VARCHAR(50) DEFAULT NULL,
	[extra_validation] BIT DEFAULT NULL,
	[cci] VARCHAR(50) DEFAULT NULL,
	[info] VARCHAR(255) DEFAULT NULL,
	[inactive] BIT DEFAULT NULL,
	[facility_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla EMPLOYEE_DETAIL (Detalle del Empleado) schema VENTAS
CREATE TABLE Ventas.[employee_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[suffix] VARCHAR(10) DEFAULT NULL,
	[valedictory] VARCHAR(255) DEFAULT NULL,
	[see_auth] BIT DEFAULT NULL,
	[termination_date] DATE DEFAULT NULL,
	[salary] DECIMAL(5,2) DEFAULT NULL,
	[shift] VARCHAR(50) DEFAULT NULL,
	[contract_terms] XML DEFAULT NULL,
	[employee_id] BIGINT NOT NULL,
	[address_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla SUPPLIER_DETAIL (Detalle del Proveedor) schema VENTAS
CREATE TABLE Ventas.[supplier_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[rating] TINYINT DEFAULT NULL,
	[notes] VARCHAR(255) DEFAULT NULL,
	[contract_terms] XML DEFAULT NULL,
	[accept_terms] BIT DEFAULT NULL,
	[supplier_id] BIGINT NOT NULL,
	[address_id] INT NOT NULL
);

-- Tabla CUSTOMER_DETAIL (Detalle del Cliente) schema VENTAS
CREATE TABLE Ventas.[customer_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[title] VARCHAR(50) DEFAULT NULL,
	[preferred_name] VARCHAR(100) DEFAULT NULL,
	[language] VARCHAR(50) DEFAULT NULL,
	[email] VARCHAR(255) DEFAULT NULL,
	[contact_relationship] VARCHAR(100) DEFAULT NULL,
	[billing_note] VARCHAR(255) DEFAULT NULL,
	[financial] BIT DEFAULT NULL,
	[is_retain] BIT DEFAULT NULL,
	[status] VARCHAR(50) DEFAULT NULL,
	[date_created] DATETIME DEFAULT NULL,
	[updated_by] DATETIME DEFAULT NULL,
	[contract_terms] XML DEFAULT NULL,
	[customer_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla SYSTEM_DETAIL (Detalle del Sistema) schema VENTAS
CREATE TABLE Ventas.[sytem_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(255) DEFAULT NULL,
	[support_contact] VARCHAR(100) DEFAULT NULL,
	[last_backup_date] DATETIME DEFAULT NULL,
	[max_users] INT DEFAULT NULL,
	[license_key] VARCHAR(50) DEFAULT NULL,
	[os_supported] VARCHAR(255) DEFAULT NULL,
	[log_level] VARCHAR(50) DEFAULT NULL,
	[active_modules] XML DEFAULT NULL,
	[system_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla AUDIT_DETAIL (Detalle de la Auditoria)
CREATE TABLE [audit_detail] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[table_name] VARCHAR(255) NOT NULL DEFAULT '',
	[field_name] VARCHAR(255) NOT NULL DEFAULT '',
	[old_field_value] VARCHAR(255) NOT NULL DEFAULT '',
	[new_field_value] VARCHAR(255) NOT NULL DEFAULT '',
	[entry_identification] BIGINT NOT NULL DEFAULT 0,
	[timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
	[action_type] VARCHAR(50) NOT NULL DEFAULT '',
	[changed_by] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[ip_address] VARCHAR(45) NOT NULL DEFAULT '',
	[user_agent] VARCHAR(255) NOT NULL DEFAULT '',
	[audit_master_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla PAYMENT_DETAIL (Detalle de Pago) schema VENTAS
CREATE TABLE Ventas.[payment_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[reference] VARCHAR(100) DEFAULT NULL,
	[currency] VARCHAR(10) DEFAULT NULL,
	[gateway] VARCHAR(50) DEFAULT NULL,
	[is_refunded] BIT DEFAULT NULL,
	[refund_date] DATETIME DEFAULT NULL,
	[notes] VARCHAR(255) DEFAULT NULL,
	[approval_code] VARCHAR(50) DEFAULT NULL,
	[payment_id] BIGINT NOT NULL,
	[transaction_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla BILLING_TYPE (Tipo de Facturación) schema VENTAS
CREATE TABLE Ventas.[billing_type] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[type_name] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla ADDRESS (Direccion) schema VENTAS
CREATE TABLE Ventas.[address] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[country_code] VARCHAR(15) DEFAULT NULL,
	[country] VARCHAR(150) DEFAULT NULL,
	[street] VARCHAR(255) DEFAULT NULL,
	[city] VARCHAR(100) DEFAULT NULL,
	[state] VARCHAR(100) DEFAULT NULL,
	[zip] VARCHAR(100) DEFAULT NULL,
	[postal_code] VARCHAR(20) DEFAULT NULL,
	PRIMARY KEY([id])
);

-- Tabla IDENTIFICATION_TYPE (Tipo de Identificación) schema VENTAS
CREATE TABLE Ventas.[identification_type] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla FACILITY_CLIENT (Organizacion y Cliente) schema VENTAS
CREATE TABLE Ventas.[customer_employee] (
	[customer_id] BIGINT NOT NULL,
	[employee_id] BIGINT NOT NULL
);

-- Tabla AUTOMATIC_NOTIFICATIONS (Automatizacion de Notificaciones) schema VENTAS
CREATE TABLE Ventas.[automatic_notifications] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[title] VARCHAR(255) NOT NULL DEFAULT '',
	[message] VARCHAR(255) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[status] VARCHAR(50) NOT NULL DEFAULT '',
	[trigger_event] VARCHAR(100) NOT NULL DEFAULT '',
	[system_id] BIGINT NOT NULL,
	[employee_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla LOYALTY (Lealtad del Cliente) schema VENTAS
CREATE TABLE Ventas.[loyalty] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[total_points] INT NOT NULL DEFAULT 0,
	[membership_level] VARCHAR(50) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[status] VARCHAR(50) NOT NULL DEFAULT '',
	[customer_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla REWARD (Premio) schema VENTAS
CREATE TABLE Ventas.[reward] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(100) NOT NULL DEFAULT '',
	[description] VARCHAR(255) NOT NULL DEFAULT '',
	[value] INT NOT NULL DEFAULT 0,
	[criteria] VARCHAR(255) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[reward_type_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla CUSTOMER_REWARDS (Cliente y Premio) schema VENTAS
CREATE TABLE Ventas.[customer_rewards] (
	[reward_id] INT NOT NULL,
	[customer_id] BIGINT NOT NULL
);

-- Tabla ROLE (Rol) schema VENTAS
CREATE TABLE Ventas.[role] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla PRODUCT_CATEGORY (Categoria del Producto) schema VENTAS
CREATE TABLE Ventas.[product_category] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla SUPPLY_TYPE (Tipo de Proveedor) schema VENTAS
CREATE TABLE Ventas.[supply_type] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(255) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla SETTING (Configuracion) schema VENTAS
CREATE TABLE Ventas.[setting] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(100) NOT NULL DEFAULT '',
	[value] VARCHAR(255) NOT NULL DEFAULT '',
	[type] VARCHAR(50) NOT NULL DEFAULT '',
	[category] VARCHAR(50) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[module_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla PAYMENT_METHOD (Método de Pago) schema VENTAS
CREATE TABLE Ventas.[payment_method] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla SETTING_DETAIL (Detalle de Configuracion) schema VENTAS
CREATE TABLE Ventas.[setting_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[decription] VARCHAR(255) DEFAULT NULL,
	[is_editable] BIT DEFAULT NULL,
	[default_value] VARCHAR(255) DEFAULT NULL,
	[scope] VARCHAR(50) DEFAULT NULL,
	[requires_restart] BIT DEFAULT NULL,
	[last_updated_by] INT DEFAULT NULL,
	[validation_rule] INT DEFAULT NULL,
	[setting_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla REWARD_TYPE (Tipo de Premio) schema VENTAS
CREATE TABLE Ventas.[reward_type] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla REWARD_DETAIL (Detalle del Premio) schema VENTAS
CREATE TABLE Ventas.[reward_detail] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[expiry_date] DATETIME DEFAULT NULL,
	[status] VARCHAR(50) DEFAULT NULL,
	[max_uses] INT DEFAULT NULL,
	[redemption_code] VARCHAR(50) DEFAULT NULL,
	[icon] VARCHAR(50) DEFAULT NULL,
	[priority] INT DEFAULT NULL,
	[reward_id] INT NOT NULL,
	[transaction_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla TRANSACTION (Transaccion) schema VENTAS
CREATE TABLE Ventas.[transaction] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[amount] DECIMAL(6,2) NOT NULL DEFAULT 0,
	[currency] VARCHAR(5) NOT NULL DEFAULT '',
	[status] VARCHAR(30) NOT NULL DEFAULT '',
	[date] DATETIME NOT NULL DEFAULT GETDATE(),
	[transaction_type_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla TRANSACTION_TYPE (Tipo de Transacción) schema VENTAS
CREATE TABLE Ventas.[transaction_type] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla SECTION (Seccion) schema VENTAS
CREATE TABLE Ventas.[section] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(100) NOT NULL DEFAULT '',
	[order] INT NOT NULL DEFAULT 0,
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[module_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla USER (Usuario) schema CENTRAL
CREATE TABLE Central.[user] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[username] VARCHAR(50) NOT NULL DEFAULT '',
	[password] VARCHAR(100) NOT NULL DEFAULT '',
	[email] VARCHAR(100) NOT NULL DEFAULT '',
	[avatar] VARCHAR(255) NOT NULL DEFAULT '',
	[active] BIT NOT NULL DEFAULT 1,
	[last_updated] DATETIME NOT NULL DEFAULT GETDATE(),
	[date_created] DATETIME NOT NULL DEFAULT GETDATE(),
	[permission_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla USER_ACHIEVEMENTS (Logros de Clientes) schema CENTRAL 
CREATE TABLE Central.[user_achievements] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[uuid] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWSEQUENTIALID(),
	[achievement_title] VARCHAR(150) NOT NULL DEFAULT '',
	[description] VARCHAR(255) NOT NULL DEFAULT '',
	[earned_at] DATETIME NOT NULL DEFAULT '',
	[user_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla USER_DETAIL (Detalle del Usuario) schema CENTRAL
CREATE TABLE Central.[user_detail] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[pin] VARCHAR(4) DEFAULT NULL,
	[facility] VARCHAR(255) DEFAULT NULL,
	[google_signin_email] VARCHAR(255) DEFAULT NULL,
	[github_signin] VARCHAR(255) DEFAULT NULL,
	[apple_signin] VARCHAR(255) DEFAULT NULL,
	[last_login] DATETIME DEFAULT NULL,
	[source] VARCHAR(255) DEFAULT NULL,
	[default_warehouse] VARCHAR(255) DEFAULT NULL,
	[user_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla LEADs (Candidatos) schema CENTRAL
CREATE TABLE Central.[leads] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(255) NOT NULL DEFAULT '',
	[email] VARCHAR(100) NOT NULL DEFAULT '',
	[subscription_date] DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY([id])
);

-- Tabla CONTENT (Contenidos) schema CENTRAL
CREATE TABLE Central.[content] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[title] VARCHAR(130) NOT NULL DEFAULT '',
	[description] VARCHAR(255) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY([id])
);

-- Tabla TESTIMONY (Comentarios) schema CENTRAL
CREATE TABLE Central.[testimony] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[content] VARCHAR(255) NOT NULL DEFAULT '',
	[created_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[rating] TINYINT NOT NULL DEFAULT 0,
	[like_count] INT NOT NULL DEFAULT 0,
	[user_id] BIGINT NOT NULL,
	[testimony_type_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla ANALITIC (Analitica) schema CENTRAL
CREATE TABLE Central.[analitic] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[user_ip] VARCHAR(45) NOT NULL DEFAULT '',
	[page_viewed] VARCHAR(150) NOT NULL DEFAULT '',
	[date] DATETIME NOT NULL DEFAULT GETDATE(),
	[referrer] VARCHAR(255) NOT NULL DEFAULT '',
	[session_duration] INT NOT NULL DEFAULT 0,
	[user_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla CONFIGURATION (Configuracion) schema CENTRAL
CREATE TABLE Central.[configuration] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[key_name] VARCHAR(100) NOT NULL DEFAULT '',
	[value] VARCHAR(255) NOT NULL DEFAULT '',
	[updated_at] DATETIME NOT NULL DEFAULT GETDATE(),
	[user_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla PERMISSION (Permiso) schema CENTRAL
CREATE TABLE Central.[permission] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	[active] BIT NOT NULL DEFAULT 1,
	[date_created] DATETIME NOT NULL DEFAULT GETDATE(),
	[last_updated] DATETIME NOT NULL DEFAULT GETDATE(),
	PRIMARY KEY([id])
);

-- Tabla USER_SECURE (Seguridad del Usuario) schema CENTRAL
CREATE TABLE Central.[user_secure] (
	[id] BIGINT IDENTITY(1,1) NOT NULL,
	[password_history1] VARCHAR(100) NOT NULL DEFAULT '',
	[password_history2] VARCHAR(100) NOT NULL DEFAULT '',
	[password_history3] VARCHAR(100) NOT NULL DEFAULT '',
	[password_history4] VARCHAR(100) NOT NULL DEFAULT '',
	[auto_block_emailed] BIT NOT NULL DEFAULT 1,
	[login_work_area] VARCHAR(255) NOT NULL DEFAULT '',
	[total_login_fail_counter] INT NOT NULL DEFAULT 0,
	[login_fail_counter] INT NOT NULL DEFAULT 0,
	[last_updated] DATETIME NOT NULL DEFAULT GETDATE(),
	[last_challenge_response] DATETIME DEFAULT NULL,
	[last_login_fail] DATETIME DEFAULT NULL,
	[last_updated_password] DATETIME DEFAULT NULL,
	[user_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla USER_SETTING (Configuración del usuario) schem CENTRAL
CREATE TABLE Central.[user_settings] (
	[setting_user] BIGINT IDENTITY(1,1) NOT NULL,
	[setting_label] VARCHAR(255) NOT NULL DEFAULT '',
	[setting_value] VARCHAR(255) NOT NULL DEFAULT '',
	[user_id] BIGINT NOT NULL,
	PRIMARY KEY([setting_user])
);

-- Tabla TESTIMONY_TYPE (Tipo de Comentario) schema CENTRAL
CREATE TABLE Central.[testimony_type] (
	[id] TINYINT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(50) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);

-- Tabla TESTIMONY_DETAIL (Detalle del Comentario) schema CENTRAL
CREATE TABLE Central.[testimony_detail] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[is_visible] BIT DEFAULT NULL,
	[updated_at] DATETIME DEFAULT NULL,
	[image_url] VARCHAR(255) DEFAULT NULL,
	[testimony_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla LEAD_DETAIL (Detalle del Candidato) schema CENTRAL
CREATE TABLE Central.[lead_detail] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[phone] VARCHAR(20) DEFAULT NULL,
	[message] VARCHAR(255) DEFAULT NULL,
	[leads_id] BIGINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla CONTENT_SECTION (Seccion del Contenido) schema CENTRAL
CREATE TABLE Central.[content_section] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[section_name] VARCHAR(255) DEFAULT NULL,
	[parent_section] INT DEFAULT NULL,
	[section_identifier] VARCHAR(50) DEFAULT NULL,
	[content_detail_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla CONTENT_DETAIL (Detalle del Contenido) schema CENTRAL
CREATE TABLE Central.[content_detail] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[cont_directory] VARCHAR(64) NOT NULL DEFAULT '',
	[cont_parent] VARCHAR(64) NOT NULL DEFAULT '',
	[cont_type] VARCHAR(64) NOT NULL DEFAULT '',
	[cont_active] BIT NOT NULL DEFAULT 1,
	[cont_ui_name] VARCHAR(64) NOT NULL DEFAULT '',
	[cont_relative_link] VARCHAR(64) NOT NULL DEFAULT '',
	[cont_ui_order] TINYINT NOT NULL DEFAULT 0,
	[cont_ui_active] BIT NOT NULL DEFAULT 1,
	[cont_description] VARCHAR(255) NOT NULL DEFAULT '',
	[cont_nick_name] VARCHAR(25) NOT NULL DEFAULT '',
	[cont_enc_menu] VARCHAR(10) NOT NULL DEFAULT '',
	[permissions_item_table] BIT NOT NULL DEFAULT 1,
	[directory] VARCHAR(255) NOT NULL DEFAULT '',
	[date] DATETIME NOT NULL DEFAULT GETDATE(),
	[sql_run] TINYINT NOT NULL DEFAULT 0,
	[sql_version] VARCHAR(150) NOT NULL DEFAULT '',
	[acl_version] VARCHAR(150) NOT NULL DEFAULT '',
	[content_id] BIGINT NOT NULL,
	[content_type_id] INT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla PERMISSION_CONTENT (Permiso y Contenido) schema CENTRAL
CREATE TABLE Central.[permission_content] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[allowed] BIT NOT NULL DEFAULT 1,
	[content_detail_id] INT NOT NULL,
	[permission_id] TINYINT NOT NULL,
	PRIMARY KEY([id])
);

-- Tabla CONTENT_TYPE (Tipo de Contenido) schema CENTRAL
CREATE TABLE Central.[content_type] (
	[id] INT IDENTITY(1,1) NOT NULL,
	[description] VARCHAR(100) NOT NULL DEFAULT '',
	PRIMARY KEY([id])
);


-- GENERANDO RELACIONES
ALTER TABLE Ventas.[billing] ADD CONSTRAINT [billing_supplier_supplier_id] FOREIGN KEY ([supplier_id]) REFERENCES Ventas.[supplier]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[billing] ADD CONSTRAINT [billing_billing_type_billing_type_id] FOREIGN KEY ([billing_type_id]) REFERENCES Ventas.[billing_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[billing] ADD CONSTRAINT [billing_employee_employee_id] FOREIGN KEY ([employee_id]) REFERENCES Ventas.[employee]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[billing] ADD CONSTRAINT [billing_customer_customer_id] FOREIGN KEY ([customer_id]) REFERENCES Ventas.[customer]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer] ADD CONSTRAINT [customer_identification_type_identification_type_id] FOREIGN KEY ([identification_type_id]) REFERENCES Ventas.[identification_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer] ADD CONSTRAINT [customer_address_address_id] FOREIGN KEY ([address_id]) REFERENCES Ventas.[address]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[product] ADD CONSTRAINT [product_product_category_product_category_id] FOREIGN KEY ([product_category_id]) REFERENCES Ventas.[product_category]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE [audit_master] ADD CONSTRAINT [audit_master_employee_employee_id] FOREIGN KEY ([employee_id]) REFERENCES Ventas.[employee]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[supplier] ADD CONSTRAINT [supplier_supply_type_supply_type_id] FOREIGN KEY ([supply_type_id]) REFERENCES Ventas.[supply_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[payment] ADD CONSTRAINT [payment_sales_sales_id] FOREIGN KEY ([sales_id]) REFERENCES Ventas.[sales]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[payment] ADD CONSTRAINT [payment_payment_method_payment_method_id] FOREIGN KEY ([payment_method_id]) REFERENCES Ventas.[payment_method]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[payment] ADD CONSTRAINT [payment_billing_billing_id] FOREIGN KEY ([billing_id]) REFERENCES Ventas.[billing]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[sales_detail] ADD CONSTRAINT [sales_detail_sales_sales_id] FOREIGN KEY ([sales_id]) REFERENCES Ventas.[sales]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[facility] ADD CONSTRAINT [facility_identification_type_identification_type_id] FOREIGN KEY ([identification_type_id]) REFERENCES Ventas.[identification_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[facility] ADD CONSTRAINT [facility_address_address_id] FOREIGN KEY ([address_id]) REFERENCES Ventas.[address]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[billing_detail] ADD CONSTRAINT [billing_detail_product_product_id] FOREIGN KEY ([product_id]) REFERENCES Ventas.[product]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[billing_detail] ADD CONSTRAINT [billing_detail_billing_billing_id] FOREIGN KEY ([billing_id]) REFERENCES Ventas.[billing]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[employee] ADD CONSTRAINT [employee_role_role_id] FOREIGN KEY ([role_id]) REFERENCES Ventas.[role]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[product_detail] ADD CONSTRAINT [product_detail_supplier_supplier_id] FOREIGN KEY ([supplier_id]) REFERENCES Ventas.[supplier]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[product_detail] ADD CONSTRAINT [product_detail_setting_setting_id] FOREIGN KEY ([setting_id]) REFERENCES Ventas.[setting]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[product_detail] ADD CONSTRAINT [product_detail_product_product_id] FOREIGN KEY ([product_id]) REFERENCES Ventas.[product]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[module_detail] ADD CONSTRAINT [module_detail_module_module_id] FOREIGN KEY ([module_id]) REFERENCES Ventas.[module]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[facility_detail] ADD CONSTRAINT [facility_detail_facility_facility_id] FOREIGN KEY ([facility_id]) REFERENCES Ventas.[facility]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[employee_detail] ADD CONSTRAINT [employee_detail_employee_employee_id] FOREIGN KEY ([employee_id]) REFERENCES Ventas.[employee]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[employee_detail] ADD CONSTRAINT [employee_detail_address_address_id] FOREIGN KEY ([address_id]) REFERENCES Ventas.[address]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[supplier_detail] ADD CONSTRAINT [supplier_detail_supplier_supplier_id] FOREIGN KEY ([supplier_id]) REFERENCES Ventas.[supplier]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[supplier_detail] ADD CONSTRAINT [supplier_detail_address_address_id] FOREIGN KEY ([address_id]) REFERENCES Ventas.[address]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer_detail] ADD CONSTRAINT [customer_detail_customer_customer_id] FOREIGN KEY ([customer_id]) REFERENCES Ventas.[customer]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[sytem_detail] ADD CONSTRAINT [sytem_detail_system_system_id] FOREIGN KEY ([system_id]) REFERENCES Ventas.[system]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE [audit_detail] ADD CONSTRAINT [audit_detail_audit_master_audit_master_id] FOREIGN KEY ([audit_master_id]) REFERENCES [audit_master]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[payment_detail] ADD CONSTRAINT [payment_detail_payment_payment_id] FOREIGN KEY ([payment_id]) REFERENCES Ventas.[payment]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[payment_detail] ADD CONSTRAINT [payment_detail_transaction_transaction_id] FOREIGN KEY ([transaction_id]) REFERENCES Ventas.[transaction]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer_employee] ADD CONSTRAINT [customer_employee_customer_customer_id] FOREIGN KEY ([customer_id]) REFERENCES Ventas.[customer]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer_employee] ADD CONSTRAINT [customer_employee_employee_employee_id] FOREIGN KEY ([employee_id]) REFERENCES Ventas.[employee]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[automatic_notifications] ADD CONSTRAINT [automatic_notifications_system_system_id] FOREIGN KEY ([system_id]) REFERENCES Ventas.[system]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[automatic_notifications] ADD CONSTRAINT [automatic_notifications_employee_employee_id] FOREIGN KEY ([employee_id]) REFERENCES Ventas.[employee]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[loyalty] ADD CONSTRAINT [loyalty_customer_customer_id] FOREIGN KEY ([customer_id]) REFERENCES Ventas.[customer]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[reward] ADD CONSTRAINT [reward_reward_type_reward_type_id] FOREIGN KEY ([reward_type_id]) REFERENCES Ventas.[reward_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer_rewards] ADD CONSTRAINT [customer_rewards_reward_reward_id] FOREIGN KEY ([reward_id]) REFERENCES Ventas.[reward]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[customer_rewards] ADD CONSTRAINT [customer_rewards_customer_customer_id] FOREIGN KEY ([customer_id]) REFERENCES Ventas.[customer]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[setting] ADD CONSTRAINT [setting_module_module_id] FOREIGN KEY ([module_id]) REFERENCES Ventas.[module]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[setting_detail] ADD CONSTRAINT [setting_detail_setting_setting_id] FOREIGN KEY ([setting_id]) REFERENCES Ventas.[setting]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[reward_detail] ADD CONSTRAINT [reward_detail_reward_reward_id] FOREIGN KEY ([reward_id]) REFERENCES Ventas.[reward]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[reward_detail] ADD CONSTRAINT [reward_detail_transaction_transaction_id] FOREIGN KEY ([transaction_id]) REFERENCES Ventas.[transaction]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[transaction] ADD CONSTRAINT [transaction_transaction_type_transaction_type_id] FOREIGN KEY ([transaction_type_id]) REFERENCES Ventas.[transaction_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Ventas.[section] ADD CONSTRAINT [section_module_module_id] FOREIGN KEY ([module_id]) REFERENCES Ventas.[module]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[user] ADD CONSTRAINT [user_permission_permission_id] FOREIGN KEY ([permission_id]) REFERENCES Central.[permission]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[user_achievements] ADD CONSTRAINT [user_achievements_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[user_detail] ADD CONSTRAINT [user_detail_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[testimony] ADD CONSTRAINT [testimony_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[testimony] ADD CONSTRAINT [testimony_testimony_type_testimony_type_id] FOREIGN KEY ([testimony_type_id]) REFERENCES Central.[testimony_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[analitic] ADD CONSTRAINT [analitic_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[configuration] ADD CONSTRAINT [configuration_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[user_secure] ADD CONSTRAINT [user_secure_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[user_settings] ADD CONSTRAINT [user_settings_user_user_id] FOREIGN KEY ([user_id]) REFERENCES Central.[user]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[testimony_detail] ADD CONSTRAINT [testimony_detail_testimony_testimony_id] FOREIGN KEY ([testimony_id]) REFERENCES Central.[testimony]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[lead_detail] ADD CONSTRAINT [lead_detail_leads_leads_id] FOREIGN KEY ([leads_id]) REFERENCES Central.[leads]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[content_section] ADD CONSTRAINT [content_section_content_detail_content_detail_id] FOREIGN KEY ([content_detail_id]) REFERENCES Central.[content_detail]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[content_detail] ADD CONSTRAINT [content_detail_content_content_id] FOREIGN KEY ([content_id]) REFERENCES Central.[content]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[content_detail] ADD CONSTRAINT [content_detail_content_type_content_type_id] FOREIGN KEY ([content_type_id]) REFERENCES Central.[content_type]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[permission_content] ADD CONSTRAINT [permission_content_content_detail_content_detail_id] FOREIGN KEY ([content_detail_id]) REFERENCES Central.[content_detail]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
ALTER TABLE Central.[permission_content] ADD CONSTRAINT [permission_content_permission_permission_id] FOREIGN KEY ([permission_id]) REFERENCES Central.[permission]([id]) ON DELETE NO ACTION ON UPDATE CASCADE;
