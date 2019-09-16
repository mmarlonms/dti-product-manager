using Dti.ProductManager.Domain.Models;
using System.Collections.Generic;

namespace Dti.ProductManager.Domain.Service
{
    public interface IProdutoService
    {
        Produto CriarProduto(Produto produto);
        Produto AlterarProduto(Produto produto);
        void RemoverProduto(int id);
        Produto ObterProduto(int id);
        IList<Produto> ListarProdutos();
        IList<Produto> ListarPorNome(string nome);
        void AdicionarQuantidade(int id, int quantidade);
        void RemoverQuantidade(int id, int quantidade);
    }
}