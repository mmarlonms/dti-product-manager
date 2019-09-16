<br />
<img src="https://github.com/mmarlonms/monte-olimpo/blob/master/docs/monte-olimpo-logo.png" width="90" height="90">
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-api/master/docs/dti-logo.jpeg" width="170" height="90">

# Dti Product Manager

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




# Dti Product Manager Api

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

	Dti.ProductManager.WebApi
	
**Testes**

	Dti.ProductManager.Tests

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

* MonteOlimpo.Base.Exception
* MonteOlimpo.Base.CoreException 
* MonteOlimpo.Base.Extensions 
* MonteOlimpo.Base.Filters 
* MonteOlimpo.Base.Log

Para a camada de Negócio:

* MonteOlimpo.Base.Core.Domain
* MonteOlimpo.Base.Core.Specification
* MonteOlimpo.Base.Core.Data
* MonteOlimpo.Base.Core.CrossCutting 
* MonteOlimpo.Base.Core.Tests
* MonteOlimpo.Base.Core.Validations

Todas OpenSources disponíveis no meu [GitHub](https://github.com/mmarlonms)

Elas ainda estão em **desenvolvimento** e ainda há muito que se fazer ( como por exemplo melhorar a documentação).

Este projeto meu deu a oportunidade de colocas em prática, então, muito obrigado ;) .


**Conclusão**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos com Injeção de Dependência, arquitetura exagonal e principalmente utilização de testes mocados na aplicação, além de outros conceitos. 


# Dti Product Manager Client

**Solução:**

Dashboard
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Dashboard.PNG">
Produtos
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos.PNG">
Novo Produto
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Adicionar.PNG">
Alterar Produto
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Menu-Editar.PNG">
Remover Produto
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Menu-Deletar.PNG">

Adicionar Quantidade em Estoque
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Menu-Adicionar.PNG">

Remover Quantidade em Estoque
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Menu-Retirar.PNG">

Para resolver o problema proposto foi utilizado a Angular 2 por se tratar de um tecnologia em constante evolução e expertise do desenvolver ( no caso eu ) na liguagem. 

A Solução foi desenvolvida seguindo o layout [Material Dashboard](https://www.creative-tim.com/product/material-dashboard) devido ao fato do desenvolvedor não ser tão habituado com o desenvolvimento front end e por falta de tempo de criar componentes reutilizáveis para front-end.

Foi utilizado as seguintes referências: 
- [Angular Material](https://material.angular.io/](https://material.angular.io/))
- [Angular 5: Making API calls with the HttpClient service](https://www.metaltoad.com/blog/angular-5-making-api-calls-httpclient-service)
- [Introduction to services and dependency injection](https://angular.io/guide/architecture-services)


**Execução do projeto**

Para executar o projeto é necessário executar a seguinte api : 
[dti-product-manager-api](https://github.com/mmarlonms/dti-product-manager-api)

Instalar as dependências do projeto executando o comando:
 
	npm install

Inciar o servidor local com o comando:

	npm start


**Requisitos para execução do projeto:**

A Api foi desenvolvida na plataforma .net core 2.1 ou seja, é necessário este SDK para executa-lo ;).

Para este projeto foi utilizado o ORM Entity FrameWork Core por devido às facilidades de se gerenciar o banco de dados.

Caso você esteja usando o banco de teste que eu criei no servidor 

[Elepahant SQL](https://customer.elephantsql.com) não é necessário realizar nenhum procedimento, mas,  caso queria alterar o banco é necessário aplicar o comando "update-database" no projeto __Dti.ProductManager.Data__ alterando as configurações do __appsettings.Development__.

Para a Execução do client é necessário possuir o [Nodejs](https://nodejs.org/en/) instalado para a execução dos projetos.

**Plus++**
------------

Para melhorar o tratamento das exceções geradas pela api, foi criado um filtro de requisições no qual dispara um mensagem pra tela em caso de exceção de negócio ou exceção do sistema. 

Todas as exceções são logadas e armazenas em arquivo. No caso de exceções de caráter 500 é exibido para usuário somente um GUID para que se possa buscar entre os logs o real motivo daquele erro, com isso garantimos que a stake trace não será exibida.

Erro de negócio (400)
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Erro400.PNG">
Erro Interno (500)
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Erro500.PNG">
Erro Interno (500) - Log
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Erro500-Log.PNG">

**Conclusão**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos de front end nos quais já não trabalhava a tempo, tive algumas dificuldades na manipulação dos componentes, mas com bastante leitura pude superar os desafios propostos e entregar uma solução estável. 

Como melhoria proponho incluir a paginação do grid de produtos e desenvolver um layout próprio, pois, embora seja mais mais fácil partir de um layout pronto, tive muita dificuldade ao tentar utilizar alguns componentes do Agular Material. 
