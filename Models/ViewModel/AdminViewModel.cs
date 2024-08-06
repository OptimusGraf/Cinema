namespace Cinema.Models.ViewModel
{
	public class AdminViewModel
	{
		public List<CinemaViewModel> Cinemas { get; set; }

		public AdminViewModel(List<Cinema> cinemas)
		{
			Cinemas = new List<CinemaViewModel>();
			foreach (var cinema in cinemas)
			{
				CinemaViewModel cinemaView = new CinemaViewModel(cinema);
				cinemaView.Shelude = cinema.Shelude.ToList();
				this.Cinemas.Add(cinemaView);
			}
		}
	}
}
