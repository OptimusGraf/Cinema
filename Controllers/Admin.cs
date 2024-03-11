using Cinema.Models;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
	public class AdminController:Controller
	{
		CinemaContext dataBase;

		public AdminController(CinemaContext dataBase)
		{
			this.dataBase = dataBase;
		}

		public IActionResult Admin()
		{
			
			IndexViewModel model = new IndexViewModel(dataBase.Cinemas.Include(c=>c.Shelude).ToList());

			return View(model);
		}

		[HttpGet]
		public IActionResult CinemaEdit()
		{
			return View();
		}
		[HttpGet]
		public string AddCinema(string refTrailer, byte[] image, string name, string tegs, string description) // добавить отображение результата и оброботку разных вариантов и еще чтобы все параметры были выбраны
		{
			return $"{refTrailer} , {name}, {tegs}, {description}";


		}
	}
}
