class Program
{
    private static void Main()
    {
        Repository.JsonFileName = "Celebrities.json";

        using (IRepository repository = Repository.Create(Repository.directoryPath))
        {
            foreach (Celebrity celebrity in repository.GetAllCelebrities())
            {
                Console.WriteLine($"Id={celebrity.Id}, Firstname={celebrity.Name}, Surname={celebrity.Surname}, PhotoPath={celebrity.PhotoPath}");
            }

            void PrintCelebrity(int id)
            {
                var celeb = repository.GetCelebrityById(id);
                if (celeb != null)
                {
                    Console.WriteLine($"Id={celeb.Id}, Firstname={celeb.Name}, Surname={celeb.Surname}, PhotoPath={celeb.PhotoPath}");
                }
                else
                {
                    Console.WriteLine($"Not Found {id}");
                }
            }

            PrintCelebrity(1);
            PrintCelebrity(3);
            PrintCelebrity(222);

            foreach (var surname in new[] { "Chomsky", "Knuth", "XXXX" })
            {
                var celebs = repository.GetCelebritiesBySurname(surname);
                if (celebs.Length == 0)
                {
                    Console.WriteLine($"No celebrities found with surname {surname}");
                }
                else
                {
                    foreach (var celebrity in celebs)
                    {
                        Console.WriteLine($"Id={celebrity.Id}, Firstname={celebrity.Name}, Surname={celebrity.Surname}, PhotoPath={celebrity.PhotoPath}");
                    }
                }
            }

            Console.WriteLine($"PhotoPathById = {repository.GetPhotoPathById(4)}");
            Console.WriteLine($"PhotoPathById = {repository.GetPhotoPathById(6)}");
            Console.WriteLine($"PhotoPathById = {repository.GetPhotoPathById(222)}");
        }
    }
}
