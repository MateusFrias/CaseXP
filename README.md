staging: novo diagrama (API map) e implementação do serviço de alerta via e-mail

o projeto consiste em arquitetura de microsserviços, implementada em .NET 8 e utilizando Entity Framework Core.

o banco de dados é criado e populado na primeira execução do projeto, seguindo as Migrations de cada microsserviço.

para executar: alterar a connection string do appsettings.json do Produto e ProdutoDisponivel, para um novo servidor SQL Server que aceite a criação de bancos e tabelas via Entity Framework Core.

baseado nas entidades e regras descritos nos requisitos do case, gerei o seguinte diagrama de entidades:
![image](https://github.com/MateusFrias/CaseXP/assets/9474242/cbcc4c95-7d33-430f-8cfc-ec972337d1ab)
![Case XP-API-map drawio](https://github.com/MateusFrias/CaseXP/assets/9474242/a2f16a74-fb9f-42a7-a065-1e6f97499dde)

dessas entidades, foram implementados os microsserviços de Produto e ProdutoDisponivel.

a ideia do ProdutoDisponivel é que seja uma entidade voltada para o consumo em tempo real dos usuários e clientes para visualização e negociação de produtos disponíveis neste momento. A tabela Produto guarda mais informações sobre os produtos disponíveis e o histórico de todos os produtos que já foram negociados pela empresa, sendo referenciando na entidade Carteira do Cliente.

os microsserviços foram implementados de forma síncrona, por não existir necessidade explícita (dentro da proposta do case) de incluir assincronismo ou arquitetura de eventos.

