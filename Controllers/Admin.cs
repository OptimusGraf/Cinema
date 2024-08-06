using Cinema.Models;
using Cinema.Models.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
namespace Cinema.Controllers
{
	public class AdminController : Controller
	{
		CinemaContext dataBase;

		public AdminController(CinemaContext dataBase)
		{
			this.dataBase = dataBase;
		}

		public IActionResult Admin()
		{

			AdminViewModel model = new AdminViewModel(dataBase.Cinemas.Include(c => c.Shelude).ToList());

			return View(model);
		}


		[HttpPost]
		public IActionResult CinemaEdit(int? Id)
		{

			if (Id != null)
			{
				return View(new CinemaViewModel(dataBase.Cinemas.FirstOrDefault(c => c.Id == Id)));
			}
			else
				return View();
		}

		public IActionResult ChangeCinema(int? id, string refTrailer, IFormFile photoimage, string name, string genre, string country, int age/*, TimeOnly duration*/, string description) //, продолжительность, асинхроность, добавить отображение результата и оброботку разных вариантов и еще чтобы все параметры были выбраны
		{
			byte[] image = null;
			if (photoimage != null)
			{
				using (var dataStream = new MemoryStream())
				{
					/*await*/
					photoimage.CopyToAsync(dataStream);// ассинхроность??
					image = dataStream.ToArray();
				}
			}

			Models.Cinema cinema = dataBase.Cinemas.FirstOrDefault(c => c.Id == id);
			if (photoimage != null)
			{

				cinema.Image = image;
			}
			cinema.TrailerRef = refTrailer;
			cinema.Name = name;
			cinema.Genre = genre;
			cinema.Country = country;
			cinema.Age = age;
			cinema.Description = description;

			dataBase.Cinemas.Update(cinema);

			dataBase.SaveChanges(); //eсли данные некоректны? обработка искл или if добавить
									//добавить визуальное подтверждение того, что фильм было отредактировано

			return RedirectPermanent("~/Admin/admin");
		}

		[HttpPost] // или на put
		public IActionResult AddCinema(string refTrailer, IFormFile photoimage, string name, string genre, string country, int age/*, TimeOnly duration*/, string description) //, продолжительность, асинхроность, добавить отображение результата и оброботку разных вариантов и еще чтобы все параметры были выбраны
		{
			//photoimage ужасное название
			byte[] image = null;
			if (photoimage != null)
			{
				using (var dataStream = new MemoryStream())
				{
					/*await*/
					photoimage.CopyToAsync(dataStream);// ассинхроность??
					image = dataStream.ToArray();
				}
			}

			Models.Cinema cinema = new Cinema.Models.Cinema(image, name, description, country, genre, age, new TimeOnly(2, 20), refTrailer);
			dataBase.Cinemas.Add(cinema);
			dataBase.SaveChanges(); //eсли данные некоректны? обработка искл или if добавить
									//добавить визуальное подтверждение того, что фильм было добавлен в список
			return RedirectPermanent("~/Admin/admin");
		}
		[HttpPost]
		public IActionResult AddToShelude(int Id, int hall, decimal price, DateTime time)
		{

			Shelude newShelude = new Shelude { RoomNumber = hall, DateTime = time, Cost = price, CinemaId = Id };
			dataBase.Sheludes.Add(newShelude);
			dataBase.SaveChanges();
			return RedirectPermanent("~/Admin/Admin");
		}

		[HttpPost] // или на delete
		public IActionResult DeleteFromShelude(int? id)
		{
			if (id != null)
			{
				Models.Shelude? shelude = dataBase.Sheludes.FirstOrDefault(c => c.Id == id); //поменять на асинх версию
				if (shelude != null)
				{
					dataBase.Sheludes.Remove(shelude);
					dataBase.SaveChanges(); // Тоже наверное на асинх
				}
			}
			return RedirectPermanent("~/Admin/Admin");
		}
		[HttpPost] // или на delete
		public IActionResult DeleteCinema(int? id)
		{
			if (id != null)
			{
				Models.Cinema? cinema = dataBase.Cinemas.FirstOrDefault(c => c.Id == id); //поменять на асинх версию
				if (cinema != null)
				{
					dataBase.Cinemas.Remove(cinema);
					dataBase.SaveChanges(); // Тоже наверное на асинх
				}
			}
			return RedirectPermanent("~/Admin/Admin");
		}
	}
}
