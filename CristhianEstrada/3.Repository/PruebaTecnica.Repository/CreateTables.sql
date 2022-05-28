-- 2. Script para realizar creación de la tabla empleado en la base de datos.

CREATE TABLE Adm.Employees 
(	
	EmployeeId			INT				IDENTITY,
	CompanyId			VARCHAR(100)	NULL,
	CreatedOn			VARCHAR(100)	NULL,
	DeletedOn			VARCHAR(100)	NULL,
	Email				VARCHAR(100)	NULL,
	Fax					VARCHAR(100)	NULL,
	Name				VARCHAR(100)	NULL,
	Lastlogin			VARCHAR(100)	NULL,
	Password			VARCHAR(100)	NULL,
	PortalId			VARCHAR(100)	NULL,
	RoleId				VARCHAR(100)	NULL,
	StatusId			VARCHAR(100)	NULL,
	Telephone			VARCHAR(100)	NULL,
	UpdatedOn			VARCHAR(100)	NULL,
	Username			VARCHAR(100)	NULL,

	CONSTRAINT PK_EMPLOYEE primary key (EmployeeId)
)
GO

CREATE SYNONYM Employees FOR Adm.Employees
GO