# DESAFIO TÉCNICO

- [x] Implement a microservice using REST, which will be responsible for controlling an office's legal cases.
- [x] The microservice must support all CRUD (Create, Read, Update, Delete) scenarios.
- [x] The data model of the Case entity is composed of the fields:
  - **Case Number**: A string that represents the case number according to the National Council of Justice (CNJ) standard. It has the format: **NNNNNNNNN.NNNN.N.NN.NNNN**, where N can be any positive integer.
  - **Court Name**: A string that represents the name of the court of origin of the case. Example: Supreme Federal Court.
  - **Name of the Responsible**: String representing the name of the lawyer responsible for the case.
  - **Registration Date**: Date on which the case was registered in the system.
- [x] All fields are mandatory and must be validated.
- [x] The Case Number field must be validated according to its standard format.
- [x] The Registration Date must be generated automatically at the time of registration.
- [x] The solution should not allow duplicate registration of cases, using the case number to verify its uniqueness.

# SOLUÇÃO
- A solução foi escrita em C #, usando .NET Core.
- Nesse repositório existem duas Solution:
  - **SolutionAPI.sln:**
    - Api:
      - Projeto do tipo **ASP.NET Core 5.0 Web API**
      - Usando biblioteca AutoMapper (Conversão das classes), Versioning (Controle de Versão da API) e Swashbuckle (Swagger).
    - Business:
      - Projeto do tipo **Class Library (.NET Core)**
      - Usando biblioteca FuentValidation (Validação)
      - Esse projeto que contem toda a regra de negócio.
    - Data:
      - Projeto do tipo **Class Library (.NET Core)**
      - Usando biblioteca EntityFrameworkCore (Acesso ao banco SQLServer)
    - UnitTest
      - Projeto do tipo **XUnit Test Project (.NET Core)**
      - Usando biblioteca Moq
      
  - **SolutionWeb.sln:**
    - Web:
      - Projeto do tipo ****ASP.NET Core 5.0 Web App (MVC)**
      - Não foi dado muito foco nesse projeto, criado para as chamadas da API
 
# COMPILAR, RODAR E TESTAR A APLICAÇÃO
- Faça do download do código desse [repositório](https://github.com/luisfernandoferracin/TR).
- Abra a **SolutionAPI.sln** no visual studio.
- Em **Package Manager Console** digite os seguintes comandos apontado para o projeto **Data**:
  - EntityFrameworkCore\Add-Migration InitialCreate -Verbose -Context MyDbContext
  - Script-Migration -Context MyDbContext (Se quiser criar um script)
  - Update-Database -Context MyDbContext
- Compile o projeto e rode.
- A API será aberta no Swagger, e pode ser testada pelo mesmo.
- Para rodar através da interface, abra a **SolutionWeb.sln** compile e rode mantendo o projeto da API rodando.
