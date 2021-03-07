# 7196 - Todo App: API com ASP.NET Core, CQRS e EF Core

## Sobre

Curso do balta.io de TodoApp API com .NET Core, CQRS e EF Core

## Antes iniciar, crie a chave local de ambiente

```bash
dotnet user-secrets list
```

```bash
dotnet user-secrets set "firebaseurl" "valor_do_firebase"
```

## Tecnologias

- .NET 5
- CQRS
- EF Core
- InMemoryDatabase + SqlServer
- Google Authentication through Firebase

## Pacotes

```bash
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.3">
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    <PrivateAssets>all</PrivateAssets>
</PackageReference>
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="5.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.3" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="5.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.3">
```

## Pontos interessantes

### SQL Query

```sql
CREATE DATABASE Todos

USE Todos

SELECT Id
,Title
,Done
,Date
,User
FROM Todo
```

### Migrations

```bash
cd .\Todo.Domain.Infra\ && dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

```bash
cd .\Todo.Domain.Api\ && dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

```bash
dotnet tool install --global dotnet-ef
```

```bash
cd .\Todo.Domain.Infra\ && dotnet ef migrations add InitialCreate --startup-project ..\Todo.Domain.Api\
```

```bash
dotnet ef database update --startup-project ..\Todo.Domain.Api\
```