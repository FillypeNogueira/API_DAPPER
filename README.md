# API_DAPPER

Esta aplicação tem como objetivo possibilitar a execução dos métodos HTTP(Get, Post, Put e Delete), utilizando apenas duas entidades, as quais estão ligadas entre si por meio do banco de dados.

## Índice

1. [Sobre o Projeto](#sobre-o-projeto)
2. [Tecnologias Utilizadas](#tecnologias-utilizadas)
3. [Instalação](#instalação)
4. [Como Usar](#como-usar)

## Sobre o Projeto

A presente API tem como objetivo tornar possível a execução dos métodos HTTP e efetuar consultas no banco de dados de uma forma eficiente e de fácil compreeensção, sobretudo considerando o objetivo principal, que consiste em aprender e entender de forma tangível como aplicar as tecnologias utilizadas.

## Tecnologias Utilizadas

- .NET 7
- Dapper (ORM)
- PostgreSQL
- C#

## Instalação

As instrunções de uso são muito simples, basta executar os comandos para:

* Criação de uma nova webapi com o dotnet 7.0: dotnet new webapi --framework net7.0
* Adicione o pacote NuGet do PostgreSQL ao seu projeto: dotnet add package Npgsql
* Adicione o pacote Nuget do Dapper ao seu projeto: dotnet add package Dapper

## Como Usar

* Execute o comando: dotnet run
* Abra o swagger no navegador e acesse as funcionalidades disponíveis.
