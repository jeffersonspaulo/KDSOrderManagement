 1. Estrutura da Solução: 

A arquitetura utilizada no projeto é a Clean Architecture. Essa arquitetura proporciona uma clara separação de responsabilidades, facilita muito o entendimento e a manutenção da aplicação.
A Solução foi dividida pensando da seguinte forma: 
- Apresentação: Contém a API com a exposição dos endpoints e comunicação com o cliente.
- Aplicação: Onde se encontram as Services. Contém a lógica de negócios e realiza a integração entre a camada de apresentação e a camada de dados.
- Domínio: Define os modelos de domínios e entidades como também as DTOs.
- Dados/Infraestrutura: Implementação da camada de dados.

--------------------------------------------------------------------------------------------------------------------------
 2. Persistência de Dados: 

Foi utilizado o SQL Server para a persistência de dados, em combinação com o Entity Framework Core (EF Core) como ORM. A abordagem adotada foi a Code First com o uso de Migrations.
A utilização do Code First facilita a modelagem do banco de dados, promovendo uma melhor integração entre o modelo de dados e a lógica da aplicação.

Para garantir a integridade e a precisão dos dados, foi utilizado o FluentValidation para validar as entradas antes que sejam processadas e armazenadas no banco de dados.

--------------------------------------------------------------------------------------------------------------------------
 3. Desempenho e Escalabilidade: 

A Clean Architecture também contribui para a escalabilidade da aplicação ao promover uma clara separação de responsabilidades.
Com essa abordagem, as diferentes camadas da aplicação são isoladas, permitindo que cada uma delas seja escalada de forma independente se necessário.

Para garantir o desempenho da aplicação, foram utilizados métodos assíncronos em várias partes do código, especialmente nas operações de acesso a dados e chamadas de API.
A utilização de métodos assíncronos ajuda a melhorar a escalabilidade da aplicação ao permitir que as operações de I/O sejam realizadas de forma livre, liberando recursos para atender outras requisições.

--------------------------------------------------------------------------------------------------------------------------
 4. Segurança: 

A segurança da aplicação é gerenciada através da utilização de JSON Web Tokens (JWT) para autenticação e autorização.

O JWT é usado para garantir que apenas usuários autenticados e autorizados possam acessar os endpoints da API. 

--------------------------------------------------------------------------------------------------------------------------
 5. Infraestrutura: 

Optei por utilizar o Serilog no gerenciamento de logs de erros. O Serilog disponibiliza uma flexibilidade de customização, os logs são bem estruturados e fáceis de entendimento.

A aplicação é implantada em containers Docker, o que inclui tanto a API quanto o banco de dados.
O uso de Docker simplifica o processo de deployment e proporciona uma solução consistente e portável.
O Docker Compose é utilizado para gerenciar e configurar os containers, garantindo que a aplicação e o banco de dados sejam executados em conjunto conforme necessário.
