using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Cinema.Models
{
	public class CinemaContext : DbContext
	{
		public DbSet<Cinema> Cinemas => Set<Cinema>();
		public DbSet<Shelude> Sheludes => Set<Shelude>();

		public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ //мб стоит сделать рид ол байтс асинхронным
			List<Cinema> cinemas = new List<Cinema>
			{
				new Cinema { Id=1, Age=18, Image=File.ReadAllBytes("..\\sitedrawing\\images\\lotr2.jpg"), Country="New Zeland", duration= new TimeOnly(2,20), Name="Властелин колец 1", Genre="Фэнтези", Description= "Сказания о Средиземье — это хроника Великой войны за Кольцо, войны, длившейся не одну тысячу лет. Тот, кто владел Кольцом, получал власть над всеми живыми тварями, но был обязан служить злу.",TrailerRef="https://www.youtube.com/watch?v=v6TjKMQisn0&t=39s&ab_channel=WBRussia" },
				new Cinema { Id=2, Age=18, Image=File.ReadAllBytes("..\\sitedrawing\\images\\lotr1.jpg"), Country="New Zeland", duration= new TimeOnly(2,20), Name="Властелин колец 2 ", Genre="Фэнтези", Description= "Сказания о Средиземье — это хроника Великой войны за Кольцо, войны, длившейся не одну тысячу лет. Тот, кто владел Кольцом, получал власть над всеми живыми тварями, но был обязан служить злу." ,TrailerRef="https://www.youtube.com/watch?v=v6TjKMQisn0&t=39s&ab_channel=WBRussia" },
				new Cinema { Id=3, Age=18, Image=File.ReadAllBytes("..\\sitedrawing\\images\\lotr2.jpg"), Country="New Zeland", duration= new TimeOnly(2,20), Name="Властелин колец 3 ", Genre="Фэнтези", Description= "Сказания о Средиземье — это хроника Великой войны за Кольцо, войны, длившейся не одну тысячу лет. Тот, кто владел Кольцом, получал власть над всеми живыми тварями, но был обязан служить злу." ,TrailerRef="https://www.youtube.com/watch?v=v6TjKMQisn0&t=39s&ab_channel=WBRussia" }
			};

			List<Shelude> sheludes = new List<Shelude> {
				new Shelude { Id=1, CinemaId = 1,  DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16,0,0),RoomNumber=1,Cost=100 } ,
				new Shelude { Id=2, CinemaId = 1,  DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19,0,0),RoomNumber=1, Cost=200} ,
				new Shelude { Id=3, CinemaId = 1,  DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19,0,0),RoomNumber=2, Cost=300 } ,
				new Shelude { Id=4, CinemaId = 2,  DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16,0,0),RoomNumber=3, Cost=500  },
				new Shelude { Id=5, CinemaId = 3,  DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18,0,0),RoomNumber=3, Cost=600  },
				new Shelude { Id=6, CinemaId = 2,  DateTime= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, 16,0,0),RoomNumber=3, Cost=666  },
			};
			modelBuilder.Entity<Cinema>().HasData(cinemas);
			modelBuilder.Entity<Shelude>().HasData(sheludes);


		}

		public List<Cinema> GetToDayCinemas() //переделать в асинх
		{
			this.Sheludes.Load();
			// фильмы которые в прокате сегодня
			List<Cinema> list = this.Cinemas.Where(c => c.Shelude.Any(s => s.DateTime.Date == DateTime.Now.Date)).ToList();
			return list;
			
		}
}
}
