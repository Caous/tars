CREATE DATABASE TARS_MVC;

CREATE TABLE TB_USER (
	id_user int (50) not null AUTO_INCREMENT,
    email varchar(200) not null,
    pass varchar(500) not null,
    fullname varchar(500) not null,
    departament varchar(500) not null,
	dt_inclused TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
     PRIMARY KEY (id_user)
);

insert tb_user (email,pass,fullname,departament) values ('admin@admin.com','P@ssw0rd', 'Admin System', 'TI');