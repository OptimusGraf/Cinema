namespace Cinema.Models.ViewModel
{
    public class IndexViewModel
    {
		public List<CinemaViewModel> Cinemas { get; set; } 

		public IndexViewModel(List<Cinema> cinemas)
		{
			Cinemas = new List<CinemaViewModel>();
			foreach (var cinema in cinemas)
			{
				this.Cinemas.Add(new CinemaViewModel(cinema));
			}
		}
	}
}
