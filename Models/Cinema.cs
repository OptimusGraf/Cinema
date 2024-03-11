using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
	public class Cinema
	{
		public int Id { get; set; }
		public byte[]? Image { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Country { get; set; }
		public string Genre { get; set; }
		public int Age { get; set; }

		[NotMapped]
		public TimeOnly duration { get; set; }

		public string TrailerRef { get; set; }

		public List<Shelude> Shelude { get; set; } = new();
	}
}
