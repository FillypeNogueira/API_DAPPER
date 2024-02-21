# API_DAPPER

Esta aplicação tem como objetivo possibilitar a execução dos métodos HTTP(Get, Post, Put e Delete), utilizando apenas duas entidades, as quais estão ligadas entre si por meio do banco de dados.

## Índice

1. [Sobre o Projeto](#sobre-o-projeto)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Instalação](#instalação)
4. [Como Usar](#como-usar)
5. [Configurações de Banco](#configurações-de-Banco)

## Sobre o Projeto

A presente API tem como objetivo tornar possível a execução dos métodos HTTP e efetuar consultas no banco de dados de uma forma eficiente e de fácil compreeensção, sobretudo considerando o objetivo principal, que consiste em aprender e entender de forma tangível como aplicar as tecnologias utilizadas.

## Tecnologias Utilizadas

- .NET 7
- Dapper (ORM)
- PostgreSQL
- C#

## Instalação

As instrunções de uso são muito simples, caso seja necessário, basta executar os comandos para:

* Adicione o pacote NuGet do PostgreSQL ao seu projeto: dotnet add package Npgsql
* Adicione o pacote Nuget do Dapper ao seu projeto: dotnet add package Dapper
* No appsettings.json preencha com cuidado as informações necessárias no NpgsqlConnection, para que haja a conexão com o banco de dados.

## Como Usar

* Execute o comando: dotnet run
* Abra o swagger no navegador e acesse as funcionalidades disponíveis.

## Configurações de Banco

* 1° Abra seu SGBD ou acesse seu banco pelo terminal.
* 2° Execute o script a seguir para criação das tabelas:

CREATE TABLE Category (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Status BOOLEAN NOT NULL
);

CREATE TABLE Product (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Price DECIMAL(18,2) NOT NULL,
    Status BOOLEAN NOT NULL,
    CategoryId BIGINT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);

* 3° Execute o script a seguir para criação dos registros da tabela Category:

INSERT INTO Category (Name, Status) VALUES ('Eletrônicos', true);
INSERT INTO Category (Name, Status) VALUES ('Roupas', true);
INSERT INTO Category (Name, Status) VALUES ('Alimentos', true);
INSERT INTO Category (Name, Status) VALUES ('Cosméticos', true);
INSERT INTO Category (Name, Status) VALUES ('Livros', true);

* 4° Execute o script a seguir para a criação dos registros da tabela Product:

INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Smartphone', 'Smartphone de última geração', 999.99, true, 1);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Notebook', 'Notebook ultrafino e potente', 1499.99, true, 1);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Fone de Ouvido', 'Fone de ouvido sem fio com cancelamento de ruído', 199.99, true, 1);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('TV 4K', 'TV inteligente com resolução 4K', 899.99, true, 1);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Câmera DSLR', 'Câmera digital profissional', 799.99, true, 1);

INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Camiseta', 'Camiseta básica de algodão', 29.99, true, 2);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Calça Jeans', 'Calça jeans de corte reto', 49.99, true, 2);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Sapato Social', 'Sapato social em couro', 79.99, true, 2);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Vestido', 'Vestido casual de verão', 39.99, true, 2);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Blazer', 'Blazer elegante para ocasiões especiais', 99.99, true, 2);

INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Arroz', 'Arroz branco de qualidade', 5.99, true, 3);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Feijão', 'Feijão carioca de primeira', 3.99, true, 3);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Macarrão', 'Macarrão espaguete italiano', 2.99, true, 3);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Carne Bovina', 'Carne bovina magra', 12.99, true, 3);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Frango', 'Peito de frango sem osso', 8.99, true, 3);

INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Shampoo', 'Shampoo suave para todos os tipos de cabelo', 9.99, true, 4);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Condicionador', 'Condicionador hidratante', 9.99, true, 4);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Creme Facial', 'Creme facial anti-idade', 19.99, true, 4);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Perfume', 'Perfume floral delicado', 29.99, true, 4);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Protetor Solar', 'Protetor solar FPS 50', 14.99, true, 4);

INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('O Hobbit', 'Livro de fantasia épica', 19.99, true, 5);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('Orgulho e Preconceito', 'Romance clássico de Jane Austen', 14.99, true, 5);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('1984', 'Distopia futurista de George Orwell', 12.99, true, 5);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('A Arte da Guerra', 'Clássico da estratégia militar', 9.99, true, 5);
INSERT INTO Product (Name, Description, Price, Status, CategoryId) VALUES ('O Poder do Hábito', 'Livro sobre psicologia e autoajuda', 16.99, true, 5);

