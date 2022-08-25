/*
use master
go
if exists(select 1 from sys.databases where name = 'luvancar')
begin
	alter database luvancar set single_user with rollback immediate
	drop database luvancar
end
go 
create database luvancar
go
*/
use luvancar
go

select * from tarefa
create proc sp_inserirtarefa
	@Id int output,
	@Id_Usuario int,
	@Descricao varchar(250),
	@Estatus varchar(50)
as
	insert into Tarefa(Id,Id_Usuario,Descricao,Estatus)
	values(@Id,@Id_Usuario,@Descricao,@Estatus)
go

create proc sp_buscartarefa
	@Filtro varchar(150)
as
	select Id,Id_Usuario,Descricao,Estatus from Tarefa 
	where Descricao like '%' + @Filtro + '%'
go

create proc sp_excluirtarefa
	@Id int
as
	delete from Comentario where Id_Tarefa = @Id
	delete from Tarefa where Id = @Id
go

create proc sp_inserircomentario
	@Id int output,
	@Id_Usuario int,
	@Id_Tarefa int,
	@Descricao varchar(250)
as
	insert into Comentario(Id,Id_Usuario,Id_Tarefa,Descricao)
	values(@Id,@Id_Usuario,@Id_Tarefa,@Descricao)
go

create proc sp_buscarcomentario
	@Id_Tarefa int
as
	select Id,Id_Usuario,Id_Tarefa,Descricao from Comentario 
	where Id_Tarefa = @Id_Tarefa
go


































/*
create table cliente
(
idcliente int primary key identity(1,1),
nome varchar(50),
cpf int, --será necessario uma validacao para aceitar somente numeros
sobrenome varchar(40),
endereco varchar(150),
telefone varchar(20),
)
go
create table funcionario
(
idfuncionario int primary key identity(1,1),
nome varchar(50),
cpf int, --será necessario uma validacao para aceitar somente numeros
sobrenome varchar(40),
endereco varchar(150),
telefone varchar(20),
)
go
create table veiculo
(
idveiculo int primary key identity(1,1),
placa varchar(7), --não pode aceitar sinal de menos
cor varchar(20),
ano int,
modelo varchar(30),
marca varchar(20),
tipo varchar(20), --suv, caminhonete, caminhao
valordiaria float
)

go
create table aluguel
(
data_inicial date,
data_entrega date,-- sera preenchido somente na devolucao do veiculo
valor_total float,
observacao varchar(300),
idcliente int,
idveiculo int,
idfuncionario int
)

go
alter table aluguel
add
constraint fkcliente_aluguel foreign key(idcliente) references cliente(idcliente),
constraint fkveiculo_aluguel foreign key(idveiculo) references veiculo(idveiculo),
constraint fkfuncinario_aluguel foreign key(idfuncionario)references funcionario(idfuncionario)

*/