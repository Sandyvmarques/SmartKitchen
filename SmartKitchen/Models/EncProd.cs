using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartKitchen.Models
{
	public class EncProd
	{
		//chave primária
		[System.ComponentModel.DataAnnotations.Key]
		public int ID { get; set; }// PK*, por exigência da Entity Framework

		//atributos do Relacionamento
		[Required]
		public int QuantidVendida { get; set; }
		[Required]
		public decimal PrecoCompra { get; set; }
		[Required]
		public decimal IVA_Compra { get; set; }

		//Foreign Keys 
		[ForeignKey("Produto")]
		public int ProdutosFK { get; set; }
		public virtual Produtos Produto { get; set; }

		[ForeignKey("Encomenda")]
		public int EncomendasFK { get; set; }
		public virtual Encomendas Encomenda { get; set; }
	}
}