# 📚 BookAPP

Projeto desenvolvido como desafio técnico para cadastro e gerenciamento de livros, autores e assuntos. A arquitetura está separada em camadas (API, Domain, Repository) com Entity Framework Core e SQL Server.

---

## 🏗️ Arquitetura

O projeto segue o padrão de **3 camadas**:

- **BookAPP.API**: Camada de apresentação (controllers, endpoints, configuração do app)
- **BookAPP.Domain**: Entidades e interfaces (models puros, sem dependência de framework)
- **BookAPP.Repository**: Camada de persistência (EF Core, DbContext, Repositórios)

---

## 💻 Tecnologias

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core 9
- SQL Server
- Migrations com EF Tools
- Injeção de Dependência
- Boas práticas de arquitetura

---

## 🚀 Como executar

### Pré-requisitos

- .NET SDK 9
- SQL Server local ou remoto

### Clonar o projeto

```bash
git clone https://github.com/valadaom/BookAPP.git
cd BookAPP
```

### Restaurar os pacotes
```bash
dotnet restore
```

### Gerar o banco de dados
```bash
dotnet ef database update --project BookAPP.Repository/BookAPP.Repository.csproj --startup-project BookAPP.API/BookAPP.API.csproj
```

### Rodar a aplicação
```bash
dotnet run --project BookAPP.API
```