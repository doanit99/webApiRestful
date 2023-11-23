using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.WebApiRestful.Domain.Entities
{
	public class Products : BaseEntity
	{
		public string Name { get; set; }
		public int QuatityPerUnit {  get; set; }
		public double UnitPrice { get; set; }
		public int UnitInStock {  get; set; }
		public DateTime CreatedDate { get; set; }
		public int UnitOnOrder {  get; set; }
		public new bool IsActive { get; set; } //new: không muốn kế thừa từ cha nó

		[Required]
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public Categories Categories { get; set; }
	}
}
