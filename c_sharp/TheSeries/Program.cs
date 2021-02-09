using System;

namespace TheSeries
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						ExcludeSerie();
						break;
					case "5":
						ShowSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = GetUserOption();
			}

			Console.WriteLine("Thank you for using our services.");
			Console.ReadLine();
        }

        private static void ListSeries()
		{
			Console.WriteLine("List series");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("No registered series.");
				return;
			}

			foreach (Serie serie in list)
			{
                bool excluded = serie.returnExcluded();
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (excluded ? "*Excluded*" : ""));
			}
		}

        private static void InsertSerie()
		{
			Console.WriteLine("Insert new serie");

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Enter the genre among the above options:  ");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie title: ");
			string title = Console.ReadLine();

			Console.Write("Enter the serie year: ");
			int year = int.Parse(Console.ReadLine());

			Console.Write("Enter the description: ");
			string description = Console.ReadLine();

			Serie serie = new Serie(repository.NextId(),
                                    (Genre)genre,
                                    title,
                                    description,
                                    year);

			repository.Insert(serie);
		}

        private static void ExcludeSerie()
		{
			Console.Write("Enter the serie id: ");
			int serieId = int.Parse(Console.ReadLine());

			repository.Exclude(serieId);
		}
        
		private static void UpdateSerie()
		{
			Console.Write("Enter the serie id: ");
			int id = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}

			Console.Write("Enter the genre among the above options:  ");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie title: ");
			string title = Console.ReadLine();

			Console.Write("Enter the serie year: ");
			int year = int.Parse(Console.ReadLine());

			Console.Write("Enter the description: ");
			string description = Console.ReadLine();

			Serie serie = new Serie(id,
                                            (Genre)genre,
                                            title,
                                            description,
                                            year);

			repository.Update(id, serie);
		}
        
		private static void ShowSerie()
		{
			Console.Write("Enter the serie id: ");
			int serieId = int.Parse(Console.ReadLine());
			var serie = repository.ReturnById(serieId);
			Console.WriteLine(serie);
		}

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("TheSeries at your service!!!\n\n");
			Console.WriteLine("Enter the desired option:\n");

			Console.WriteLine("1- List series");
			Console.WriteLine("2- Insert a new serie");
			Console.WriteLine("3- Update a serie");
			Console.WriteLine("4- Exclude a serie");
			Console.WriteLine("5- Show a serie");
			Console.WriteLine("C- Clean screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
    }
}