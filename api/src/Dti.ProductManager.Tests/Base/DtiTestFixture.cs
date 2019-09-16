using Dti.ProductManager.Data;
using Dti.ProductManager.Repository;
using Dti.ProductManager.Service;
using MonteOlimpo.Base.Core.Tests;
using System.Collections.Generic;
using System.Reflection;

namespace Dti.ProductManager.Tests.Base
{
    public class DtiTestFixture : TestsFixture<DtiContext>
    {
        protected override IEnumerable<Assembly> GetAditionalAssemblies()
        {
            yield return typeof(ProdutoRepository).Assembly;
            yield return typeof(ProdutoService).Assembly;
        }
    }
}