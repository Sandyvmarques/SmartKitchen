using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartKitchen.Models
{
	public class Imagens
	{
		[Key]
		public int Imagem_ID { get; set; } //chave primária

		//atributos
		//[Required(ErrorMessage = "The {0} is required.")]
		public string Img { get; set; }


		public string Ordem { get; set; }

		//Foreign Keys 
		[ForeignKey("Produto")]
		public int ProdutosFK { get; set; }
		public virtual Produtos Produto { get; set; }
	}
}