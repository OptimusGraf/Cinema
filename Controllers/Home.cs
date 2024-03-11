
using Cinema.Models;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
	public class HomeController:Controller
	{
		CinemaContext dataBase;

		public HomeController(CinemaContext dataBase)
		{
			this.dataBase = dataBase;
		}

		public IActionResult Index()
		{

			IndexViewModel model = new IndexViewModel(dataBase.GetToDayCinemas());
		
			return View(model);
		}

	//	[Route("image/{id:int}")]
		public async Task<IActionResult> CinemaImage(int id)
		{
			byte[] image= dataBase.Cinemas.FirstOrDefault(c=> c.Id== id)?.Image;
			return File(image, "image/jpg");
		}

	}
}
