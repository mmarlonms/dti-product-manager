using MonteOlimpo.Base.Core.DataAnnotations;
using MonteOlimpo.Base.Core.Domain.Model;


namespace Dti.ProductManager.Domain.Models
{
    public class Produto : ModelBase
    {
        [Required(ErrorKey = "NomeEmpty", ErrorMessage ="Nome não pode ser vazio")]
        public string Nome { get; set; }

        [Required(ErrorKey = "ValorEmpty", ErrorMessage = "Valor não pode ser vazio")]
        public decimal? Valor { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string UrlFoto { get; set; }

        public int QuantidadeDisponivel { get; private set; }

        public virtual decimal ValorTotalEmEstoque
        {
            get
            {
                return Valor.Value * QuantidadeDisponivel;
            }
        }

        public void AdicionarQuantidadeDisponivel(int quantidade)
        {
            this.QuantidadeDisponivel += quantidade;
        }

        public void RemoverQuantidadeDisponivel(int quantidade)
        {
            this.QuantidadeDisponivel -= quantidade;
        }

        public void Apply(Produto produto)
        {
            this.Nome = produto.Nome;
            this.Valor = produto.Valor;
            this.Descricao = produto.Descricao;
            this.Categoria = produto.Categoria;
            this.UrlFoto = produto.UrlFoto;
        }
    }
}