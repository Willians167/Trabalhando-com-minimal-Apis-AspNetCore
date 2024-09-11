

---

# Trabalhando com Minimal APIs - ASP.NET Core

Este repositório contém um conjunto de exemplos e guias práticos para a criação de APIs minimalistas utilizando **ASP.NET Core**. A ideia é explorar o uso de Minimal APIs para acelerar o desenvolvimento de APIs RESTful, focando em simplicidade, performance e boas práticas.

## Funcionalidades

- Criação e consumo de rotas HTTP (GET, POST, PUT, DELETE) com Minimal APIs.
- Integração com **Entity Framework Core** para persistência de dados.
- Autenticação e autorização usando **JWT (JSON Web Tokens)**.
- Middleware personalizados para controle de requisições.
- Implementação de **Testes de Unidade** e **Testes de Integração** para validar funcionalidades.

- Otimização de performance com boas práticas para produção.
## Arquitetura

![Arquitetura-projeto](./images/Arquitetura.png)


## Pré-requisitos

Antes de rodar o projeto, certifique-se de ter instalado:

- [.NET 6 SDK ou superior](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (ou outro banco de dados configurável com o **Entity Framework**)
- Um gerenciador de pacotes como **NuGet** para restaurar dependências

## Configuração do Projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/trabalhando-com-minimal-apis.git
   ```

2. Navegue até o diretório do projeto:
   ```bash
   cd trabalhando-com-minimal-apis
   ```

3. Restaure as dependências:
   ```bash
   dotnet restore
   ```

4. Configure a conexão com o banco de dados no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=MinimalApiDb;User Id=seu_usuario;Password=sua_senha;"
   }
   ```

5. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update
   ```

6. Execute a aplicação:
   ```bash
   dotnet run
   ```

## Autenticação JWT

Este projeto implementa autenticação com **JWT**. Para testar as rotas protegidas, siga os passos abaixo:

1. Crie um usuário ou faça login na rota `/auth/login` e obtenha o token JWT.
2. Use o token JWT nas requisições às rotas protegidas passando-o no cabeçalho `Authorization`:
   ```
   Authorization: Bearer <seu_token_jwt>
   ```

## Rodando os Testes

Os testes de unidade e integração estão localizados na pasta `Tests`. Para rodá-los, utilize o seguinte comando:

```bash
dotnet test
```

## Contribuição

Sinta-se à vontade para abrir **issues** ou enviar **pull requests**. Sugestões, melhorias e correções são sempre bem-vindas.

## Licença

Este projeto é licenciado sob a [MIT License](LICENSE).

