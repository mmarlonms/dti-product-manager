using Dti.ProductManager.Domain.Models;
using MonteOlimpo.Base.Core.Domain.Repository;

namespace Dti.ProductManager.Domain.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        void AdicionarQuantidade(int id, int quantidade);
        void RemoverQuantidade(int id, int quantidade);
    }
}