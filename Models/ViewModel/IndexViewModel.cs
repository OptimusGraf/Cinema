namespace Cinema.Models.ViewModel
{
    public class IndexViewModel
    {
		public List<CinemaViewModel> Cinemas { get; set; } 

		public  IndexViewModel(List<Cinema> cinemas)
		{
			Cinemas = new List<CinemaViewModel>();
			foreach (var cinema in cinemas)
			{
				CinemaViewModel cinemaView = new CinemaViewModel(cinema);
				cinemaView.Shelude = cinema.Shelude.Where(s => s.DateTime.Date == DateTime.Now.Date).ToList();
				this.Cinemas.Add(cinemaView);
			}
		}
	}
}
