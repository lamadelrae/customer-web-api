Servidor: Localhost/SQL2019 <br>
Senha: pass123 <br>
Connection String: 02 - Infra/Data/CustomerWebApi.Infrastructure.Data/Database/Context.cs<br>
SQL Para criação do Banco de dados:

```
CREATE TABLE Customer
(
	Id UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(30) NOT NULL,
	Cpf VARCHAR(11) NOT NULL,
	BirthDate DATETIME NOT NULL,
	CONSTRAINT PK_Customer PRIMARY KEY NONCLUSTERED (Id)
)

CREATE TABLE Address 
(
	Id UNIQUEIDENTIFIER NOT NULL,
	CustomerId UNIQUEIDENTIFIER NOT NULL,
	Street VARCHAR(50) NOT NULL,
	District VARCHAR(40) NOT NULL,
	City VARCHAR(40) NOT NULL,
	State VARCHAR(40) NOT NULL,
	CONSTRAINT PK_Address PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT FK_Address_Customer FOREIGN KEY (CustomerId) REFERENCES Customer (Id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);
```
