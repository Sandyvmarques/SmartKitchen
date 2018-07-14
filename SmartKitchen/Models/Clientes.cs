using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartKitchen.Models
{
	public class Clientes
	{
		public Clientes()
		{
			ListaDeEncomendas = new HashSet<Encomendas>();
		}

		[Key]
		public int Cliente_ID { get; set; }//chave primária

		//atributos
		[Required(ErrorMessage = "The {0} is required.")]//{0} idice 0 paramentro..corresponde ao nome do atributo 
		[RegularExpression("[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûãõçëüïäö]+(( |'|-| e | da | dos | de | d')[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûãõçëüïäö]+){1,3}",
		ErrorMessage = "The {0} can only contain leters and spaces.Ex: Louis Jack")]
		public string NomeCliente { get; set; }
		[Required(ErrorMessage = "The {0} is required.")]
		public int Contacto { get; set; }
		[Required]
		public string Morada { get; set; }
		[Required]
		public string CodigoPostal { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }

		//Relação M-N (Parte N)
		public virtual ICollection<Encomendas> ListaDeEncomendas { get; set; }

	}
}