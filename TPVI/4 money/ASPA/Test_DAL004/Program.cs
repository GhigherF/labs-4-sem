
using (IRepository repository = Repository.Create(Repository.DirectoryPath))
{
    void print (string label)
    {
        Console.WriteLine("----" + label + "----------------");
        foreach(Celebrity celebrity in repository.GetAllCelebrities())
        {
            Console.WriteLine($"Id = {celebrity.Id} Firstname = {celebrity.Name}" +
                    $"Surname = {celebrity.Surname} Photopath = {celebrity.PhotoPath}");
        }
    }
    
    print("start");

    int? testdel1 = repository.AddCelebrity(new Celebrity(0, "TestDel1", "TestDel1", "Photo/TestDel1.jps"));
    int? testdel2 = repository.AddCelebrity(new Celebrity(0, "TestDel2", "TestDel2", "Photo/TestDel1.jps"));
    int? testupd1 = repository.AddCelebrity(new Celebrity(0, "TestUpd1", "TestUpd1", "Photo/TestDel1.jps"));
    int? testupd2 = repository.AddCelebrity(new Celebrity(0, "TestUpd2", "TestUpd2", "Photo/TestDel1.jps"));
    repository.SaveChanges();
    print("add 4");

    if (testdel1 != null )
    {
        if (repository.DeleteCelebrityById((int)testdel1)) Console.WriteLine($" delete {testdel1}");
        else Console.WriteLine($"delete {testdel1} error");
    }
    if (testdel2 != null)
    {
        if (repository.DeleteCelebrityById((int)testdel2)) Console.WriteLine($" delete {testdel2}");
        else Console.WriteLine($"delete {testdel2} error");
    }
    if (repository.DeleteCelebrityById(1000)) Console.WriteLine($" delete {1000}");
    else Console.WriteLine($"delete {1000} error");
    repository.SaveChanges();
    print("del 2");

    if (testupd1 != null)
        if (repository.UpdateCelebrityById((int)testupd1, new Celebrity(0, "updated1", "updated1", "Photo/Updated1.jpg"))!=null)
            Console.WriteLine($" update {testupd1} ");
        else Console.WriteLine($"update {testupd1} error");

    if (testupd2 != null)
        if (repository.UpdateCelebrityById((int)testupd2, new Celebrity(0, "updated2", "updated2", "Photo/Updated2.jpg")) != null)
            Console.WriteLine($" update {testupd2} ");
        else Console.WriteLine($"update {testupd2} error");
    if (repository.UpdateCelebrityById(1000, new Celebrity(0, "Updated 1000", "Updated 1000", "Photo/Updated1000.jpg")) != null)
        Console.WriteLine($" update {1000}");
    else Console.WriteLine($"update {1000} error");
    repository.SaveChanges();
    print("upd 2");
}

