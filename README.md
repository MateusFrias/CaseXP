o projeto consiste em arquitetura de microsserviços, implementada em .NET 8 e utilizando Entity Framework Core.

o banco de dados é criado e populado na primeira execução do projeto, seguindo as Migrations de cada microsserviço.

as entidades envolvidas nos requisitos do case geraram o seguinte diagrama:
![image](https://github.com/MateusFrias/CaseXP/assets/9474242/cbcc4c95-7d33-430f-8cfc-ec972337d1ab)

dessas entidades, foram implementados os microsserviços de Produto e ProdutoDisponivel.

a ideia do ProdutoDisponivel é que seja uma entidade voltada para o consumo em tempo real dos usuários e clientes para negociação de produtos disponíveis neste momento. A tabela Produto guarda mais informações sobre os produtos disponíveis e o histórico de todos os produtos que já foram negociados pela empresa, sendo referenciando na entidade Carteira do Cliente.

os microsserviços foram implementados de forma síncrona, por não existir necessidade explícita (dentro da proposta do case) de incluir assincronismo ou arquitetura de eventos.

