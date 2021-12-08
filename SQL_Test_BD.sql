CREATE DATABASE TARS;

CREATE TABLE TB_PESSOA (
	id_pessoa int not null,
    username varchar(50) not null,
    email varchar(200) not null,
    pass varchar(500) not null,
    nome varchar(500) not null
    
);

CREATE TABLE TB_ENDERECO (
	id_endereco int not null,
    id_city int not null,
    street varchar(50) not null,
    number_address varchar(200) not null,
    neighborhood varchar(500) not null,
    cep varchar(500) not null,
    reference_address varchar(500) not null    
);

CREATE TABLE TB_CITY (
	id_city int not null,
    name varchar(500) not null,
    state varchar(500) not null,
    country varchar(500) not null
);

CREATE TABLE TB_CLASSIFICATION (
	id_classification int not null,
    descripti varchar(500) not null    
);