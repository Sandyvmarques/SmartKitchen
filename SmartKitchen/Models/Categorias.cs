using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartKitchen.Models
{
	public class Categorias
	{
		public Categorias()
		{
			ListaDeProdutos = new HashSet<Produtos>();
		}

		[Key]
		public int Cat_ID { get; set; }//chave primária

		//atributos
		[Required]
		public string NomeCateg { get; set; }
		[Required]
		public string Icon { get; set; }

		//Relação 1-N (Parte 1)
		public virtual ICollection<Produtos> ListaDeProdutos { get; set; }

	}
}