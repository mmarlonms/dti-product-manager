using MonteOlimpo.Base.CoreException;

namespace Dti.ProductManager.Domain.Exception
{
    public class ProdutoCoreError : CoreError
    {
        protected ProdutoCoreError(string key, string message) : base(key, message)
        {
        }

        public static readonly ProdutoCoreError ProdutoNaoCadastrado = new ProdutoCoreError("Produto Nao Cadastrado", "O produto informado não existe na base da dados.");
        public static readonly ProdutoCoreError QauntidadeMinima = new ProdutoCoreError("Qauntidade Minima", "O produto não pode possuir quantidades negativas em estoque.");
    }
}