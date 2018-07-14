using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartKitchen.Models
{
	public class Produtos
	{
		public Produtos()
		{
			ListaDeEncomendas = new HashSet<EncProd>();
			ListaDeImagens = new HashSet<Imagens>();
		}
		[Key]
		public int Prod_ID { get; set; } //chave primária

		//atributos  
		[Required]
		public string NomeProduto { get; set; }
		[Required]
		public string Descricao { get; set; }
		[Required]
		public decimal IVAVenda { get; set; }
		[Required]
		public decimal PrecoVenda { get; set; }
		[Required]
		public int Stock { get; set; }
		

		//Foreign Keys 
		[ForeignKey("Categoria")]
		public int CategoriasFK { get; set; }
		public virtual Categorias Categoria { get; set; }

		//Relação M-N (Parte N)
		public virtual ICollection<EncProd> ListaDeEncomendas { get; set; }
		public virtual ICollection<Imagens> ListaDeImagens { get; set; }

	}
}