using Dti.ProductManager.Domain.Exception;
using Dti.ProductManager.Domain.Models;
using Dti.ProductManager.Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonteOlimpo.Base.ApiBoot;
using MonteOlimpo.Base.Core.Validations.ValidationsHelpers;
using System.Collections.Generic;

namespace WDti.ProductManager.WebApi.Controllers
{
    public class ProdutoController : ApiBaseController
    {
        private readonly IProdutoService produtoService;
        private readonly ILogger logger;

        public ProdutoController(IProdutoService produtoService, ILogger<ProdutoController> logger)
        {
            this.produtoService = produtoService;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Produto> ListarProtudos()
        {
            this.logger.LogInformation("Listando Todos os Produtos");
            return this.produtoService.ListarProdutos();
        }

        [HttpGet("{id}")]
        public Produto ObterProduto(int id)
        {
            this.logger.LogInformation("Obtendo produto {id}", id);
            return this.produtoService.ObterProduto(id);
        }

        [HttpGet("filtrar/{nome}")]
        public IEnumerable<Produto> ListarPorNome(string nome)
        {
            this.logger.LogInformation("listando por nome {nome}", nome);
            return this.produtoService.ListarPorNome(nome);
        }

        [HttpPost]
        public Produto CriarProduto([FromBody] Produto produto)
        {
            ValidationHelper.ThrowValidationExceptionIfNotValid(produto);

            this.logger.LogInformation("Criado produto {@produto}", produto);
            return this.produtoService.CriarProduto(produto);
        }

        [HttpPut("{id}")]
        public Produto AlterarProduto(int id, [FromBody] Produto produto)
        {
            ValidationHelper.ThrowValidationExceptionIfNotValid(produto);

            this.logger.LogInformation("Alterando produto {@produto}", produto);
            produto.Id = id;
            return this.produtoService.AlterarProduto(produto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logger.LogInformation("Deletando produto {id}", id);
            this.produtoService.RemoverProduto(id);
        }

        [HttpPatch("{id}/AdiconarQuantidade/{quantidade}")]
        public void AdiconarQuantidade(int id, int quantidade)
        {
            this.logger.LogInformation("Adiconando {quantidade} ao produto {id}",quantidade, id);
            this.produtoService.AdicionarQuantidade(id, quantidade);
        }

        [HttpPatch("{id}/RemoverQuantidade/{quantidade}")]
        public void RemoverQuantidade(int id, int quantidade)
        {
            this.logger.LogInformation("Removiendo   {quantidade} ao produto {id}", quantidade, id);
            this.produtoService.RemoverQuantidade(id, quantidade);
        }
    }
}