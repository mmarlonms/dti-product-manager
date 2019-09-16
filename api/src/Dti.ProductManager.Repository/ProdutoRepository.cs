using Dti.ProductManager.Domain.Models;
using Dti.ProductManager.Domain.Repository;
using MonteOlimpo.Base.Core.Data.Repository;
using MonteOlimpo.Base.Core.Domain.UnitOfWork;

namespace Dti.ProductManager.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void AdicionarQuantidade(int id, int quantidade)
        {
            var produto = this.GetById(id);
            produto.AdicionarQuantidadeDisponivel(quantidade);
            this.Update(produto);
        }

        public void RemoverQuantidade(int id, int quantidade)
        {
            var produto = this.GetById(id);
            produto.RemoverQuantidadeDisponivel(quantidade);
            this.Update(produto);
        }
    }
}