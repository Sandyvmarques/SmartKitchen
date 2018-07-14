using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartKitchen.Models
{
	public class Encomendas
	{
		public Encomendas()
		{
			ListaDeProdutosComprados = new HashSet<EncProd>();
		}
		[Key]
		//anotador que enibe a hipótese do ID ser auto number
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Encomenda_ID { get; set; }//chave primária

		//atributos
		[Required]
		public DateTime DataVenda { get; set; }
		[Required]
		public decimal PrecoTotal { get; set; }


		// dono da encomenda
		[ForeignKey("Cliente")]
		public int ClienteFK { get; set; }
		public virtual Clientes Cliente { get; set; }

		//Relação M-N (Parte N)
		public virtual ICollection<EncProd> ListaDeProdutosComprados { get; set; }


	}
}