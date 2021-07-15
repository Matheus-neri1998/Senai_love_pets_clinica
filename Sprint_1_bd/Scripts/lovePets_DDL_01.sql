CREATE DATABASE lovePets_tarde;
GO

USE lovePets_tarde;
GO

CREATE TABLE clinica
(
	idClinica		INT PRIMARY KEY IDENTITY
	,endereco		VARCHAR(200) NOT NULL UNIQUE
	,razaoSocial	VARCHAR(50) NOT NULL UNIQUE
	,cnpj			CHAR(14) NOT NULL UNIQUE
);
GO

CREATE TABLE dono
(
	idDono				INT PRIMARY KEY IDENTITY
	,nomeDono			VARCHAR(50) NOT NULL
);
GO

CREATE TABLE tipoPet
(
	idTipoPet			INT PRIMARY KEY IDENTITY
	,nomeTipoPet		VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE raca
(
	idRaca				INT PRIMARY KEY IDENTITY
	,idTipoPet			INT FOREIGN KEY REFERENCES tipoPet (idTipoPet)
	,nomeRaca			VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE tipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,nomeTipoUsuario	VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE usuario
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
	,email				VARCHAR(100) NOT NULL UNIQUE
	,senha				VARCHAR(100) NOT NULL
);
GO

CREATE TABLE pet
(
	idPet				INT PRIMARY KEY IDENTITY
	,nomePet			VARCHAR(50) NOT NULL
	,idRaca				INT FOREIGN KEY REFERENCES raca(idRaca)
	,idDono				INT FOREIGN KEY REFERENCES dono(idDono)
	,dataNascimento		DATE NOT NULL
	,idUsuario			INT FOREIGN KEY REFERENCES usuario(idUsuario)
);
GO

CREATE TABLE veterinario
(
	idVeterinario		INT PRIMARY KEY IDENTITY
	,idClinica			INT FOREIGN KEY REFERENCES clinica (idClinica)
	,crmv				CHAR(6) NOT NULL UNIQUE
	,nomeVeterinario	VARCHAR(50) NOT NULL
	,idUsuario			INT FOREIGN KEY REFERENCES usuario(idUsuario)
);
GO

CREATE TABLE situacao
(
	idSituacao			INT PRIMARY KEY IDENTITY
	,nomeSituacao		VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE atendimento
(
	idAtendimento		INT PRIMARY KEY IDENTITY
	,idPet				INT FOREIGN KEY REFERENCES pet (idPet)
	,idVeterinario		INT FOREIGN KEY REFERENCES veterinario (idVeterinario)
	,descricao			TEXT DEFAULT('sem descrição informada')
	,dataAtendimento	SMALLDATETIME NOT NULL
	,idSituacao			INT FOREIGN KEY REFERENCES situacao(idSituacao) DEFAULT(2)
);
GO