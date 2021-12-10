CREATE DATABASE TARS;
USE TARS;

CREATE TABLE TB_PEOPLE (
	id_people int not null AUTO_INCREMENT,
    username varchar(50) not null,
    email varchar(200) not null,
    pass varchar(500) not null,
    fullname varchar(100) not null,
	dt_inclusion TIMESTAMP NOT NULL default CURRENT_TIMESTAMP,
    dt_excluded datetime,
	PRIMARY KEY (id_people)
);

CREATE TABLE TB_CLASSIFICATION (
	id_classification int not null AUTO_INCREMENT,
    descripti varchar(200) not null,
    dt_inclusion TIMESTAMP NOT NULL default CURRENT_TIMESTAMP,
    dt_excluded datetime,
	PRIMARY KEY (id_classification)
);

CREATE TABLE TB_CLIENT(
	id_client int not null AUTO_INCREMENT,
	id_people int not null,
	id_classification int not null,
	dt_inclusion datetime,
    dt_excluded datetime,
	PRIMARY KEY (id_client),
	FOREIGN KEY (id_people) REFERENCES TB_PEOPLE(id_people),
	FOREIGN KEY (id_classification) REFERENCES TB_CLASSIFICATION(id_classification)
);

CREATE TABLE TB_CITY (
	id_city int not null AUTO_INCREMENT,
    name_city varchar(100) not null,
    state_city varchar(100) not null,
    country varchar(100) not null,
    dt_inclusion TIMESTAMP NOT NULL default CURRENT_TIMESTAMP,
    dt_excluded datetime,
	PRIMARY KEY (id_city)
);

CREATE TABLE TB_ADDRESS (
	id_address int not null AUTO_INCREMENT,
    id_city int not null,
	id_people int not null,
    street varchar(200) not null,
    number_address int not null,
    neighborhood varchar(200) not null,
    cep varchar(8) not null,
    reference_address varchar(200) not null,
    dt_inclusion TIMESTAMP NOT NULL default CURRENT_TIMESTAMP,
    dt_excluded datetime,
	PRIMARY KEY (id_address),	
	FOREIGN KEY (id_city) REFERENCES TB_CITY(id_city),
	FOREIGN KEY (id_people) REFERENCES TB_PEOPLE(id_people)
);


INSERT TB_CLASSIFICATION (descripti) values ('Client CPF');
INSERT TB_CLASSIFICATION (descripti) values ('Client CNPJ');

INSERT TB_CITY (name_city,state_city,country) values ('São Paulo', 'São Paulo', 'Brazil');
INSERT TB_CITY (name_city,state_city,country) values ('Rio de Janeiro', 'Rio de Janeiro', 'Brazil');

INSERT TB_PEOPLE (username,email,pass,fullname) values('SysAdmin','ti@ti.com', 'P@ssw0rd', 'System Admin');
INSERT TB_PEOPLE (username,email,pass,fullname) values('Tars','tars@rh.com', 'T3sT#', 'Tars User');

INSERT TB_CLIENT (id_people,id_classification) values(1,1);
INSERT TB_CLIENT (id_people,id_classification) values(2,2);

INSERT TB_ADDRESS (id_city, id_people, street, number_address,neighborhood,cep,reference_address) values (1,2,'Avenida Copacabana',215,'Copacabana','14522578','Principal AV');
INSERT TB_ADDRESS (id_city, id_people, street, number_address,neighborhood,cep,reference_address) values (2,2,'washington luiz',999,'Brooklin','11155516','Próximo ao aeroporto');
INSERT TB_ADDRESS (id_city, id_people, street, number_address,neighborhood,cep,reference_address) values (2,1,'Paulista',1580,'ALto Paulista','99955521','Centro da Paulista');


SELECT peo.username, peo.email, peo.fullname, ad.street, ad.number_address  FROM TB_CLIENT AS cl
INNER JOIN TB_PEOPLE AS peo on cl.id_people = peo.id_people
INNER JOIN TB_ADDRESS AS ad on ad.id_people = cl.id_people;
