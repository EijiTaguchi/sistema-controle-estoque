# 📦 Sistema de Controle de Estoque - Backend

API REST desenvolvida em ASP.NET Core para gerenciamento de produtos, fornecedores e movimentações de estoque.

O objetivo do projeto é demonstrar boas práticas no desenvolvimento de APIs utilizando arquitetura em camadas, Entity Framework Core e autenticação com Identity, servindo como projeto de portfólio para estudos em C# e .NET.

***

## 🚀 Tecnologias

- C#
- .NET 10
- ASP.NET Core
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- Scalar / OpenAPI

***

## 📁 Estrutura do Projeto

backend-sistema-de-estoque/
|
|-- Controllers/          # Controladores da API
|-- Dtos/                 # Objetos de Transferência de Dados
|-- Models/               # Modelos de domínio
|-- Data/                 # Contexto do banco de dados e configuração do EF Core
|-- Services/             # Serviços de negócio
!-- Repositories/          # Repositórios para acesso a dados
|-- Middlewares/          # Middleware personalizado
|-- Migrations/           # Migrações do Entity Framework Core

***

## ✨ Funcionalidades

### Produtos
- Cadastrar, atualizar, listar e remover produtos do estoque.
- Consultar produtos por ID ou nome.
- Sku único para cada produto.

### Fornecedores
- Cadastrar, atualizar, listar fornecedores.
- Desativar fornecedores (soft delete).
- Consultar fornecedores por ID.
- Cnpj único para cada fornecedor.

### Movimentações de Estoque
- Registrar entradas e saídas de produtos.
- Atualizar quantidade de produtos em estoque automaticamente.
- historico de movimentações.

### Autenticação e Autorização
- Registro e login de usuários.
- Autenticação baseada em ASP.NET Identity.

***

## 🛠️ Boas Práticas

- Arquitetura em camadas para separar responsabilidades.
- Repositórios para abstrair o acesso a dados.
- Services para encapsular a lógica de negócio.
- Uso de DTOs para transferência de dados entre camadas.
- Validação com Data Annotations e Fluent API.
- Tratamento de erros centralizado com middleware personalizado.
- Soft delete para fornecedores, mantendo histórico de dados.
- Migrações do Entity Framework Core para versionamento do banco de dados.
- Documentação da API com Swagger/OpenAPI.