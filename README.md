<br />
<img src="https://github.com/mmarlonms/monte-olimpo/blob/master/docs/monte-olimpo-logo.png" width="90" height="90">
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-api/master/docs/dti-logo.jpeg" width="170" height="90">

# Dti Product Manager

**Objetivo:**
------------


Eu como estoquista desejo cadastrar/alterar e excluir produtos no meu sistema de estoque.

Desejo as seguintes informa��es:
* Nome do produto
* Quantidade de itens do produto
* Valor unit�rio do produto

Desejo que seja dispon�vel uma tela de listagem onde eu possa selecionar um produto para exclus�o ou
edi��o (exibir uma nova tela para edi��o).

Nesta tela de listagem tamb�m dever� ser poss�vel chamar uma tela para cadastrar um novo produto.

**Requisitos**  :
A hist�ria dever� ser desenvolvida utilizando os seguinte requisitos n�o funcionais:
1. Linguagem de programa��o: C# ou Java.
2. Front-end: Angular 2+ ou React.
3. Backend: REST WebApi.
4. Persist�ncia de dados: utilizar algum framework de persist�ncia (Ex.: Entity Framework, Dapper, Spring
JPA, Hibernate...).
5. Banco de dados: Sqlite ou qualquer outro banco relacional de sua prefer�ncia.
6. Frameworks de desenvolvimento: se desejar, pode ser utilizado spring-boot ou quaisquer outros
frameworks de desenvolvimento.
7. N�o � necess�rio fazer nenhum tipo de autentica��o/autoriza��o.




# Dti Product Manager Api

**Solu��o:**


Para resolver o problema proposto foi utilizado a plataforma .net core por se tratar de um tecnologia em constante evolu��o e expertise do desenvolver ( no caso eu ) na liguagem. 

A Solu��o foi desenvolvida seguindo as boas pr�ticas de desenvolvimento  DDD e SOLID. 
Como Arquitetura de software foi adotado o padr�o **Hexagonal** por possibilitar melhor coes�o e menor acoplamento entre as camadas, facilitando evolu��es futuras. Para refer�ncias de projetos com arquiteturas exagonais ficam os seguintes links: 

- [Furiza](https://github.com/ivanborges/furiza-aspnetcore "Furiza")

- [Manga Clean Architecture](https://github.com/ivanpaulovich/clean-architecture-manga "Manga Clean Architecture")

- [Opala](https://github.com/OleConsignado/opala "Opala")

Foram utilizadas outras fontes para implementar a solu��o: 

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

Onde temos, a camada **Service** Como a camada da regra de neg�cio da aplica��o, nela est� contida toda a regra envolvida da aplica��o. 

A camada **Dominio** � a respons�vel pelo meu dom�nio, nela temos os contratos das interfaces, os objetos de dom�nio e as exce��es que meu neg�cio pode gerar.

A Camada **Infra** � respons�vel pela infra estrutura do projeto. Nela est� contida a parte de contexto e de repositorio da aplica��o, ambas respons�veis pela persist�ncias dos dados. 

A camada **Api* por expor os m�todos que ser�o consumidos pelo cliente da aplica��o.

E por �ltimo mas n�o menos importante a camada **Testes**, no qual s�o escritos testes automatizados para validar as chamadas de servi�os.

**Requisitos para execu��o do projeto:**

O projeto foi desenvolvido na plataforma .net core 2.1 ou seja, � necess�rio este SDK para executa-lo ;).

Para este projeto foi utilizado o ORM Entity FrameWork Core por devido �s facilidades de se gerenciar o banco de dados.

Caso voc� esteja usando o banco de teste que eu criei no servidor 

[Elepahant SQL](https://customer.elephantsql.com) n�o � necess�rio realizar nenhum procedimento, mas,  caso queria alterar o banco � necess�rio aplicar o comando "update-database" no projeto __Dti.ProductManager.Data__ alterando as configura��es do __appsettings.Development__.



**Plus++**
------------
Como pratica, tenho por  criar pequenos pacotes para auxiliar nas arquiteturas nas quais desenvolvo. Neste projeto pude aplicar as seguintes bibliotecas que estou desenvolvendo:

Para as camadas de infra estrutura

* MonteOlimpo.Base.Exception
* MonteOlimpo.Base.CoreException 
* MonteOlimpo.Base.Extensions 
* MonteOlimpo.Base.Filters 
* MonteOlimpo.Base.Log

Para a camada de Neg�cio:

* MonteOlimpo.Base.Core.Domain
* MonteOlimpo.Base.Core.Specification
* MonteOlimpo.Base.Core.Data
* MonteOlimpo.Base.Core.CrossCutting 
* MonteOlimpo.Base.Core.Tests
* MonteOlimpo.Base.Core.Validations

Todas OpenSources dispon�veis no meu [GitHub](https://github.com/mmarlonms)

Elas ainda est�o em **desenvolvimento** e ainda h� muito que se fazer ( como por exemplo melhorar a documenta��o).

Este projeto meu deu a oportunidade de colocas em pr�tica, ent�o, muito obrigado ;) .


**Conclus�o**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos com Inje��o de Depend�ncia, arquitetura exagonal e principalmente utiliza��o de testes mocados na aplica��o, al�m de outros conceitos. 


# Dti Product Manager Client

**Solu��o:**

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

Para resolver o problema proposto foi utilizado a Angular 2 por se tratar de um tecnologia em constante evolu��o e expertise do desenvolver ( no caso eu ) na liguagem. 

A Solu��o foi desenvolvida seguindo o layout [Material Dashboard](https://www.creative-tim.com/product/material-dashboard) devido ao fato do desenvolvedor n�o ser t�o habituado com o desenvolvimento front end e por falta de tempo de criar componentes reutiliz�veis para front-end.

Foi utilizado as seguintes refer�ncias: 
- [Angular Material](https://material.angular.io/](https://material.angular.io/))
- [Angular 5: Making API calls with the HttpClient service](https://www.metaltoad.com/blog/angular-5-making-api-calls-httpclient-service)
- [Introduction to services and dependency injection](https://angular.io/guide/architecture-services)


**Execu��o do projeto**

Para executar o projeto � necess�rio executar a seguinte api : 
[dti-product-manager-api](https://github.com/mmarlonms/dti-product-manager/tree/master/api)

Instalar as depend�ncias do projeto executando o comando:
 
	npm install

Inciar o servidor local com o comando:

	npm start


**Requisitos para execu��o do projeto:**

A Api foi desenvolvida na plataforma .net core 2.1 ou seja, � necess�rio este SDK para executa-lo ;).

Para este projeto foi utilizado o ORM Entity FrameWork Core por devido �s facilidades de se gerenciar o banco de dados.

Caso voc� esteja usando o banco de teste que eu criei no servidor 

[Elepahant SQL](https://customer.elephantsql.com) n�o � necess�rio realizar nenhum procedimento, mas,  caso queria alterar o banco � necess�rio aplicar o comando "update-database" no projeto __Dti.ProductManager.Data__ alterando as configura��es do __appsettings.Development__.

Para a Execu��o do client � necess�rio possuir o [Nodejs](https://nodejs.org/en/) instalado para a execu��o dos projetos.

**Plus++**
------------

Para melhorar o tratamento das exce��es geradas pela api, foi criado um filtro de requisi��es no qual dispara um mensagem pra tela em caso de exce��o de neg�cio ou exce��o do sistema. 

Todas as exce��es s�o logadas e armazenas em arquivo. No caso de exce��es de car�ter 500 � exibido para usu�rio somente um GUID para que se possa buscar entre os logs o real motivo daquele erro, com isso garantimos que a stake trace n�o ser� exibida.

Erro de neg�cio (400)
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Erro400.PNG">
Erro Interno (500)
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Erro500.PNG">
Erro Interno (500) - Log
<img src="https://raw.githubusercontent.com/mmarlonms/dti-product-manager-client/master/docs/Produtos-Erro500-Log.PNG">

**Conclus�o**
------------

O desafio proposto foi muito gratificante de se desenvolver pois pude aplicar diversos conceitos de front end nos quais j� n�o trabalhava a tempo, tive algumas dificuldades na manipula��o dos componentes, mas com bastante leitura pude superar os desafios propostos e entregar uma solu��o est�vel. 

Como melhoria proponho incluir a pagina��o do grid de produtos e desenvolver um layout pr�prio, pois, embora seja mais mais f�cil partir de um layout pronto, tive muita dificuldade ao tentar utilizar alguns componentes do Agular Material. 