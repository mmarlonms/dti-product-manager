using Dti.ProductManager.Domain.Models;
using MonteOlimpo.Base.Core.Specification;

namespace Dti.ProductManager.Domain.Specification
{
    public class ProdutoSpecification
    {
        public static BaseSpecification<Produto> ListarPorNome(string nome) =>
          new BaseSpecification<Produto>(p => p.Nome.ToUpperInvariant().Contains(nome.ToUpperInvariant()));
    }
}