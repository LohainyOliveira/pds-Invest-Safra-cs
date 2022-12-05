#Banco  de Dados da Safra

create database bd_safra;
use bd_safra;


create table Cliente_Juridico (
id_cliJ int primary key auto_increment not null,
nome_cliJ varchar (100) not null,
cpf_cliJ varchar (100) not null,
rg_cliJ varchar (100) not null,
sexo_cliJ varchar (100) not null,
telefone_cliJ varchar (100) not null,
cidade_cliJ varchar (100) not null,
estado_cliJ varchar (100) not null,
rua_cliJ varchar (100) not null,
bairro_cliJ varchar (100) not null,
cep_cliJ varchar (100) not null,
complemento_cliJ varchar (100) not null,
email_cliJ varchar (100) not null
);



create table Caixa (
id_cai int primary key auto_increment not null,
numero_cai int not null,
saldoinicial_cai double not null,
troco_cai double not null,
valorcreditos_cai double not null,
valordebitos_cai double not null,
saldofinal_cai double not null,
descricao_cai varchar(300),
data_hora_cai DateTime 
);

create table Fornecedor (
id_for int primary key auto_increment not null,
nome_for varchar (100) not null,
cnpj_for varchar (100) not null,
razao_social_for varchar (100) not null,
bairro_for varchar (100) not null,
rua_for varchar (100) not null,
cidade_for varchar (100) not null,
estado_for varchar (100) not null,
cep_for varchar (100) not null,
complemento_for varchar (100) not null,
telefone_pessoal_for varchar (100) not null,
telefone_firma_for varchar (100) not null,
email_for varchar (100) not null
);

create table Compra (
id_com int primary key auto_increment not null,
nome_com varchar (100) not null,
data_com date not null,
quantidade_com int not null,
descricao_com varchar (100) not null,
id_for_fk int not null,
foreign key (id_for_fk) references Fornecedor (id_for)
);

create table Insumo (
id_ins int primary key auto_increment not null,
nome_ins varchar (100) not null,
tipo_ins varchar (100) not null,
marca_ins varchar (100) not null,
descricao_ins varchar (100) not null
);

create table Compra_Insumo (
id_compins int primary key auto_increment not null,
quantidade_comp_ins int not null,
valor_comp_ins double not null,
data_comp_ins date not null,
tipo_comp_ins varchar (100) not null,
id_ins_fk int not null,
id_com_fk int not null,
foreign key (id_com_fk) references Compra (id_com),
foreign key (id_ins_fk) references Insumo (id_ins)
);

create table Semente (
id_sem int primary key auto_increment not null,
marca_sem varchar (100) not null,
descricao_sem varchar (100) not null,
quantidade_sem double not null,
medida_sem double not null
);

create table Compra_Semente (
id_comsem int primary key auto_increment not null,
quantidade_comsem int not null,
valor_comsem double not null,
data_comsem date not null not null,
tipo_comsem varchar (100) not null,
id_sem_fk int not null,
id_com_fk int not null,
foreign key (id_com_fk) references Compra (id_com),
foreign key (id_sem_fk) references Semente (id_sem)
);


create table Funcionario (
id_fun int primary key auto_increment not null,
nome_fun varchar (100) not null,
cpf_fun varchar (100) not null,
rg_fun varchar (100) not null,
sexo_fun varchar (100) not null,
telefone_fun varchar (100) not null,
cidade_fun varchar (100) not null,
estado_fun varchar (100) not null,
rua_fun varchar (100) not null,
bairro_fun varchar (100) not null,
cep_fun varchar (100) not null,
complemento_fun varchar (100) not null,
email_fun varchar (100) not null,
funcao_fun varchar (100) not null,
salario_fun double not null
); 


create table Usuario(
id_user int primary key auto_increment,
usuario_user varchar(80),
senha_user varchar(10),
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun)
);


insert into Funcionario values (null, 'Julia Lima','889.008.999-09','233.797','Femenino','(69)9925-4324','Ji-Paraná','Rondônia','Lindcelma Alves','Nova Brasilia',
'7986-098','nada a declarar','julia@gmail.com','Monitorar a Safra',1999.00);

create table Fazenda (
id_faze int primary key auto_increment not null,
nome_faze varchar (100) not null,
nome_fantasia_faze varchar (100) not null,
proprietario_faze varchar (100) not null,
cnpj_faze varchar (100) not null,
localizacao_faze varchar (100) not null,
complemento_faze varchar (100) not null
);

create table Area (
id_are int primary key auto_increment not null,
nome_terren_are varchar (100) not null,
responsavel_are varchar (100) not null,
metros_are double not null,
cnpj_are varchar (100) not null,
localizacao_are varchar (100) not null,
descricao_are varchar (100) not null
);

create table Safra (
id_saf int primary key auto_increment not null,
nome_saf varchar (100) not null,
data_inicio_saf date,
data_fim_saf date,
id_sem_fk int not null,
id_fun_fk int not null,
id_faze_fk int not null,
id_are_fk int not null,
foreign key (id_sem_fk) references Semente (id_sem),
foreign key (id_fun_fk) references Funcionario (id_fun),
foreign key (id_faze_fk) references Fazenda (id_faze),
foreign key (id_are_fk) references Area (id_are)
);


create table Estoque (
id_est int primary key auto_increment not null,
qtdd_sement_est double not null,
qtdd_insum_est double not null,
tipo_insum_est varchar (100) not null,
medida_est double not null,
descricao_est varchar (100) not null,
id_saf_fk int not null,
foreign key (id_saf_fk) references Safra (id_saf)
);

create table Safra_Insumos (
id_saf_ins int primary key auto_increment not null,
id_saf_fk int not null,
id_ins_fk int not null,
foreign key (id_saf_fk) references Safra (id_saf),
foreign key (id_ins_fk) references Insumo (id_ins)
);

create table Clima (
id_clim int primary key auto_increment not null,
temperatura_clim varchar (100) not null,
local_clim varchar (100) not null,
clima_clim varchar (100) not null,
data_clim date
);

create table Safra_Clima (
id_saf_clim int primary key auto_increment not null,
descricao_saf_clim varchar (100) not null,
periodo_saf_clim varchar (100) not null,
id_saf_fk int not null,
id_clim_fk int not null,
foreign key (id_saf_fk) references Safra (id_saf),
foreign key (id_clim_fk) references Clima (id_clim)
);

create table Maquinas (
id_maq int primary key auto_increment not null,
descricao_maq varchar (100) not null,
modelo_maq varchar (100) not null,
marca_maq varchar (100) not null,
quantidade_maq varchar (100) not null,
medida_maq varchar (100) not null,
valor_maq varchar (100) not null
);

create table Safra_Maquinas (
id_saf_maq int primary key auto_increment not null,
descricao_saf_maq varchar (100) not null,
id_saf_fk int not null,
id_maq_fk int not null,
foreign key (id_saf_fk) references Safra (id_saf),
foreign key (id_maq_fk) references Maquinas (id_maq)
);


create table Venda (
id_ven int primary key auto_increment not null,
valor_ven double not null,
data_ven date not null,
comprador_ven varchar (100) not null,
id_saf_fk int not null,
id_fun_fk int not null,
foreign key (id_saf_fk) references Safra (id_saf),
foreign key (id_fun_fk) references Funcionario (id_fun)
);



create table Recebimento (
id_rec int primary key auto_increment not null,
valor_venda_rec double not null,
data_rec date not null,
comprador_rec varchar (100),
id_ven_fk int not null,
id_cai_fk int not null,
foreign key (id_ven_fk) references Venda (id_ven),
foreign key (id_cai_fk) references Caixa (id_cai)
);


DELIMITER $$
CREATE PROCEDURE InserirClienteJuridico (nome varchar(100), cpf varchar(100), rg varchar(100), sexo varchar (100), telefone varchar(100), cidade varchar(100), estado varchar(100), 
rua varchar(100), bairro varchar (100), cep varchar(100), complemento varchar(100), email varchar(100))
BEGIN
	declare verificacao varchar(100);
    set verificacao = (select  cpf_cliJ from cliente_juridico where (cpf_cliJ = cpf));
    
    if(verificacao = '' ) or (verificacao is null) then
		insert into cliente_juridico values (null, nome, cpf, rg, sexo, telefone, cidade, estado, rua, bairro, cep, complemento, email);
        select "Cadastro realizado com sucesso" as Resultado;
	else
		select  "Não foi possível realizar o seu cadastro" as Resultado;
	end if;
END;

$$ DELIMITER ;
CALL InserirClienteJuridico('Lohainy Teixeira dos Santos oliveira','077.383.422-23','2345.8765','Femenino','(69)99251 6467',
'Ji-Paraná','RO','Lindcelma alves de jesus','Bosque dos ipes 2','76901-390','Nada a declarar','lohainy@gmalcom');



DELIMITER $$
CREATE PROCEDURE InsertUsuario (nome varchar(80), senha  varchar(10), codigo int)
BEGIN
	declare verificacao varchar(100);
    declare verificacao_fk int;
    set verificacao = (select  usuario_user from usuario where (usuario_user = nome));
    set verificacao_fk = (select id_fun fROM Funcionario WHERE (id_fun = codigo));
    

	if (verificacao_fk is not null) or (verificacao_fk <> '') then
		if ((verificacao is null) or (verificacao = '')) then
			insert into Usuario values (null, nome, senha, codigo);
			select 'O usuário', nome ,' foi inserido com sucesso!' as Confirmacao;
		else
			select concat('O Usuário ', nome, ' já existe no sistema!') as Alerta;
		end if;
	else
		select 'Os dados do Cadastro informado Não existe!' as Alerta;
	end if;
END;
$$ DELIMITER ;
call InsertUsuario ('Julia','1234',1);

select *from clima;