namespace Cinema.Models
{
	public class Shelude
	{
		public int Id { get; set; }
		public int RoomNumber { get; set; }
		public DateTime DateTime { get; set; }
		public decimal Cost { get; set; }

		public int CinemaId { get; set; } 
		public Cinema Cinema { get; set;}

	}
}
