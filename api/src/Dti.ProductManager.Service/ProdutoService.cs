using Dti.ProductManager.Domain.Exception;
using Dti.ProductManager.Domain.Models;
using Dti.ProductManager.Domain.Repository;
using Dti.ProductManager.Domain.Service;
using Dti.ProductManager.Domain.Specification;
using System.Collections.Generic;
using System.Linq;

namespace Dti.ProductManager.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public Produto AlterarProduto(Produto produto)
        {
            var product = this.produtoRepository.GetById(produto.Id.Value);

            if (product == null)
                throw new ProdutoException(ProdutoCoreError.ProdutoNaoCadastrado);

            product.Apply(produto);

            this.produtoRepository.Update(product);

            return product;
        }

        public Produto CriarProduto(Produto produto)
        {
            this.produtoRepository.Add(produto);
            return produto;
        }

        public IList<Produto> ListarProdutos()
        {
            return this.produtoRepository.List().ToList();
        }

        public Produto ObterProduto(int id)
        {
            return this.produtoRepository.GetById(id);
        }

        public void RemoverProduto(int id)
        {
            var product = this.produtoRepository.GetById(id);

            if (product == null)
                throw new ProdutoException(ProdutoCoreError.ProdutoNaoCadastrado);

            this.produtoRepository.Delete(product);
        }

        public void AdicionarQuantidade(int id, int quantidade)
        {
            var product = this.produtoRepository.GetById(id);

            if (product == null)
                throw new ProdutoException(ProdutoCoreError.ProdutoNaoCadastrado);

            this.produtoRepository.AdicionarQuantidade(id, quantidade);
        }

        public void RemoverQuantidade(int id, int quantidade)
        {
            var product = this.produtoRepository.GetById(id);

            if (product == null)
                throw new ProdutoException(ProdutoCoreError.ProdutoNaoCadastrado);

            if(product.QuantidadeDisponivel - quantidade < 0)
                throw new ProdutoException(ProdutoCoreError.QauntidadeMinima);

            this.produtoRepository.RemoverQuantidade(id, quantidade);
        }

        public IList<Produto> ListarPorNome(string nome)
        {
            return this.produtoRepository.ListBySpecfication(ProdutoSpecification.ListarPorNome(nome)).ToList();
        }
    }
}