namespace Cinema.Models.ViewModel
{
    public class CinemaViewModel:Cinema
    {
	
		public CinemaViewModel(Cinema cinema) 
		{
			this.Id= cinema.Id;
			this.Image = cinema.Image;
			this.Name = cinema.Name;
			this.Description = cinema.Description;
			this.Country = cinema.Country;
			this.Genre = cinema.Genre;
			this.Age = cinema.Age;
			this.duration = cinema.duration;
		
			this.TrailerRef = cinema.TrailerRef;
		}	
	

	}
}
