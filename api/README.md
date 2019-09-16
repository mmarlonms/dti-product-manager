[![Build Status](https://dev.azure.com/MMarlonMs/MonteOlimpo/_apis/build/status/mmarlonms.dti-product-manager-api)](https://dev.azure.com/MMarlonMs/MonteOlimpo/_build/latest?definitionId=1)


## ![SonarCloud](https://sonarcloud.io/images/project_badges/sonarcloud-white.svg)
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=dti-product-manager-api&metric=ncloc)](https://sonarcloud.io/dashboard?id=dti-product-manager-api)
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=dti-product-manager-api&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=dti-product-manager-api)
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=dti-product-manager-api&metric=bugs)](https://sonarcloud.io/dashboard?id=dti-product-manager-api)
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=dti-product-manager-api&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=dti-product-manager-api)
[![SonarCloud](https://sonarcloud.io/api/project_badges/measure?project=dti-product-manager-api&metric=code_smells)](https://sonarcloud.io/dashboard?id=dti-product-manager-api)



<br />
<div>
<img src="https://github.com/mmarlonms/monte-olimpo/blob/master/docs/monte-olimpo-logo.png" width="90" height="90">
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-api/master/docs/dti-logo.jpeg" width="170" height="90">
</div>

# Dti Product Manager Api


**Objetivo:**
------------


Eu como estoquista desejo cadastrar/alterar e excluir produtos no meu sistema de estoque.

Desejo as seguintes informações:
* Nome do produto
* Quantidade de itens do produto
* Valor unitário do produto

Desejo que seja disponível uma tela de listagem onde eu possa selecionar um produto para exclusão ou
edição (exibir uma nova tela para edição).

Nesta tela de listagem também deverá ser possível chamar uma tela para cadastrar um novo produto.

**Requisitos**  :
A história deverá ser desenvolvida utilizando os seguinte requisitos não funcionais:
1. Linguagem de programação: C# ou Java.
2. Front-end: Angular 2+ ou React.
3. Backend: REST WebApi.
4. Persistência de dados: utilizar algum framework de persistência (Ex.: Entity Framework, Dapper, Spring
JPA, Hibernate...).
5. Banco de dados: Sqlite ou qualquer outro banco relacional de sua preferência.
6. Frameworks de desenvolvimento: se desejar, pode ser utilizado spring-boot ou quaisquer outros
frameworks de desenvolvimento.
7. Não é necessário fazer nenhum tipo de autenticação/autorização.



**Solução:**
------------

Para resolver o problema proposto foi utilizado a plataforma .net core por se tratar de um tecnologia em constante evolução e expertise do desenvolver ( no caso eu ) na liguagem. 

A Solução foi desenvolvida seguindo as boas práticas de desenvolvimento  DDD e SOLID. 
Como Arquitetura de software foi adotado o padrão **Hexagonal** por possibilitar melhor coesão e menor acoplamento entre as camadas, facilitando evoluções futuras. Para referências de projetos com arquiteturas exagonais ficam os seguintes links: 

- [Furiza](https://github.com/ivanborges/furiza-aspnetcore "Furiza")

- [Manga Clean Architecture](https://github.com/ivanpaulovich/clean-architecture-manga "Manga Clean Architecture")

- [Opala](https://github.com/OleConsignado/opala "Opala")

Foram utilizadas outras fontes para implementar a solução: 

[# Utilizando Log em ASP .NET Core]([https://medium.com/@fernando.abreu/utilizando-log-em-asp-net-core-171e90732ec5](https://medium.com/@fernando.abreu/utilizando-log-em-asp-net-core-171e90732ec5))


[# Advanced Architecture for ASP.NET Core Web API](https://www.infoq.com/articles/advanced-architecture-aspnet-core)

**Estrutura do projeto:**

O projeto segue com as seguintes camadas: 

 **Service**
 
	Dti.ProductManager.Service

**Dominio**   

	Dti.ProductManager.Domain
**Infra**  

	Dti.ProductManager.Data
	Dti.ProductManager.Repository
**Api**

	WDti.ProductManager.WebApi
	
**Testes**

	WDti.ProductManager.Tests

Onde temos, a camada **Service** Como a camada da regra de negócio da aplicação, nela está contida toda a regra envolvida da aplicação. 

A camada **Dominio** é a responsável pelo meu domínio, nela temos os contratos das interfaces, os objetos de domínio e as exceções que meu negócio pode gerar.

A Camada **Infra** é responsável pela infra estrutura do projeto. Nela está contida a parte de contexto e de repositorio da aplicação, ambas responsáveis pela persistências dos dados. 

A camada **Api* por expor os métodos que serão consumidos pelo cliente da aplicação.

E por último mas não menos importante a camada **Testes**, no qual são escritos testes automatizados para validar as chamadas de serviços.

**Requisitos para execução do projeto:**

O projeto foi desenvolvido na plataforma .net core 2.1 ou seja, é necessário este SDK para executa-lo ;).

Para este projeto foi utilizado o ORM Entity FrameWork Core por devido às facilidades de se gerenciar o banco de dados.

Caso você esteja usando o banco de teste que eu criei no servidor 

[Elepahant SQL](https://customer.elephantsql.com) não é necessário realizar nenhum procedimento, mas,  caso queria alterar o banco é necessário aplicar o comando "update-database" no projeto __Dti.ProductManager.Data__ alterando as configurações do __appsettings.Development__.



**Plus++**
------------
Como pratica, tenho por  criar pequenos pacotes para auxiliar nas arquiteturas nas quais desenvolvo. Neste projeto pude aplicar as seguintes bibliotecas que estou desenvolvendo:

Para as camadas de infra estrutura

* MonteOlimpo.Base.Exception Version="1.0.4" 
* MonteOlimpo.Base.CoreException Version="1.0.4" 
* MonteOlimpo.Base.Extensions Version="1.0.4"
* MonteOlimpo.Base.Filters Version="1.0.4" 
* MonteOlimpo.Base.Log Version="1.0.4"


Para a camada de Negócio:

* MonteOlimpo.Base.Core.Domain	 Version="1.0.4" 
* MonteOlimpo.Base.Core.Specification Version="1.0.4" 
* MonteOlimpo.Base.Core.Data Version="1.0.4" 
* MonteOlimpo.Base.Core.CrossCutting Version="1.0.1" 


Todas OpenSources disponíveis no meu [GitHub](https://github.com/mmarlonms)

Elas ainda estão em **desenvolvimento** e ainda há muito que se fazer ( como por exemplo melhorar a documentação).

Este projeto meu deu a oportunidade de colocas em prática, então, muito obrigado ;) .


**Conclusão**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos com Injeção de Dependência, arquitetura exagonal e principalmente utilização de testes mocados na aplicação, além de outros conceitos. 
