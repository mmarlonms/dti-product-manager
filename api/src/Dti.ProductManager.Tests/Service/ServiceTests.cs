using Dti.ProductManager.Domain.Exception;
using Dti.ProductManager.Domain.Models;
using Dti.ProductManager.Domain.Service;
using Dti.ProductManager.Tests.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace Dti.ProductManager.Tests.Service
{
    public class ServiceTests : DtiTestFixture
    {
        private readonly IProdutoService ProdutoService;

        public ServiceTests()
        {
            ProdutoService = this.ServiceProvider.GetRequiredService<IProdutoService>();
        }

        [Fact]
        public void InserirProduto_PrarametroValido()
        {
            //Arrange
            var produto = new Produto()
            {
                Nome = "Teste"
            };

            //Act
            var response = ProdutoService.CriarProduto(produto);

            //Assert
            var result = this.ProdutoService.ListarProdutos();
            Assert.Equal(produto.Nome, result.FirstOrDefault().Nome);
        }


        [Fact]
        public void AlterarProduto_PrarametroValido()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);
            produtoCriado.Nome = "Teste Alterado";
            produtoCriado.Valor = 600;

            //Act
            var produtoAlterado = this.ProdutoService.AlterarProduto(produtoCriado);
            var result = this.ProdutoService.ListarProdutos();

            //Assert
            Assert.Equal(produtoCriado.Nome, result.FirstOrDefault().Nome);
            Assert.Equal(produtoCriado.Valor, result.FirstOrDefault().Valor);
        }

        [Fact]
        public void AlterarProduto_PrarametroInalido()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoParaAlterar = new Produto() { Nome = "Teste", Valor = 500, Id = 4 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            //Assert
            Assert.Throws<ProdutoException>(() => this.ProdutoService.AlterarProduto(produtoParaAlterar));
        }

        [Fact]
        public void RemoverProduto_ProdutoValido()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            this.ProdutoService.RemoverProduto(produtoCriado.Id.Value);
            var result = this.ProdutoService.ListarProdutos();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void RemoverProduto_ProdutoInvalido()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            //Assert
            Assert.Throws<ProdutoException>(() => this.ProdutoService.RemoverProduto(produtoCriado.Id.Value + 1));
        }

        [Fact]
        public void ListarProdutos_SemProdutos()
        {
            //Arrange
            //Act
            var result = this.ProdutoService.ListarProdutos();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ListarProdutos_ComProdutos()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            var result = this.ProdutoService.ListarProdutos();

            //Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void AdicionarQuantidade_ParametrosValidos()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);


            //Act
            this.ProdutoService.AdicionarQuantidade(produtoCriado.Id.Value, 10);
            var result = this.ProdutoService.ObterProduto(produto.Id.Value);

            //Assert
            Assert.Equal(10, result.QuantidadeDisponivel);
        }

        [Fact]
        public void AdicionarQuantidade_ParametrosInvalidos()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoNoCriado = new Produto() { Nome = "Teste", Valor = 500, Id = 4 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            //Assert
            Assert.Throws<ProdutoException>(() => this.ProdutoService.AdicionarQuantidade(produtoNoCriado.Id.Value, 10));
        }


        [Fact]
        public void RemoverQuantidade_ParametrosValidos()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);


            //Act
            this.ProdutoService.AdicionarQuantidade(produtoCriado.Id.Value, 10);
            this.ProdutoService.RemoverQuantidade(produtoCriado.Id.Value, 10);
            var result = this.ProdutoService.ObterProduto(produto.Id.Value);

            //Assert
            Assert.Equal(0, result.QuantidadeDisponivel);
        }

        [Fact]
        public void RemoverQuantidade_ParametrosInvalidos()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoNoCriado = new Produto() { Nome = "Teste", Valor = 500, Id = 4 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            //Assert
            Assert.Throws<ProdutoException>(() => this.ProdutoService.RemoverQuantidade(produtoNoCriado.Id.Value, 10));
        }

        [Fact]
        public void RemoverQuantidade_QuantidadeInvalida()
        {
            //Arrange
            var produto = new Produto() { Nome = "Teste", Valor = 500 };
            var produtoCriado = ProdutoService.CriarProduto(produto);

            //Act
            //Assert
            Assert.Throws<ProdutoException>(() => this.ProdutoService.RemoverQuantidade(produtoCriado.Id.Value, 10));
        }
    }
}