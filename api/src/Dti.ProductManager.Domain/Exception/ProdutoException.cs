using MonteOlimpo.Base.CoreException;

namespace Dti.ProductManager.Domain.Exception
{
    public class ProdutoException : CoreException<ProdutoCoreError>
    {
        public ProdutoException() : base()
        {

        }

        public ProdutoException(params ProdutoCoreError[] errors)
        {
            AddError(errors);
        }

        public override string Key => "ProdutoException";
    }
}