# DBServer

#Este projeto está dividido em DDD, banco, api, classes de testes

#Banco: Criar o database dbserver com as seguintes tabelas


CREATE TABLE CONTA (
	ContaId int identity(1,1) CONSTRAINT PK_Conta PRIMARY KEY,
	ContaCodigo VARCHAR(20),
	ContaValor NUMERIC(15,2)
);


CREATE TABLE LANCAMENTO (
	LancamentoId int identity(1,1) CONSTRAINT PK_Lancamento PRIMARY KEY,
	ContaCreditoId INT CONSTRAINT FK_Lancamento_Credito FOREIGN KEY (ContaCreditoId) REFERENCES Conta (ContaId),
	ContaDebitoId INT CONSTRAINT FK_Lancamento_Debito FOREIGN KEY (ContaDebitoId) REFERENCES Conta (ContaId),
	Lancamento NUMERIC(15,2)
)

#Lembrar de rodar ContaTest
#Lembrar de rodar LancamentoTest


#Caso queria rodar no postman, usar o endereço:

https://localhost:44354/v1/Conta

Com o seguinte Header:
Content-Type
application/json

Com o Body 
{
	"ContaCodigo": "1",
	"ContaValor": 100
}

Este exemplo foi um bonus, coloquei a classe conta

#Caso queria rodar no postman, o endpoint lançamento:

https://localhost:44354/v1/Lancamento/Lancar

Com o seguinte Header:
Content-Type
application/json

Com o Body 
{
	"ContaCredito": {
		"ContaCodigo": "1"
	},
	"ContaDebito": {
		"ContaCodigo": "2"
	},
	"LancamentoValor": 15
}
