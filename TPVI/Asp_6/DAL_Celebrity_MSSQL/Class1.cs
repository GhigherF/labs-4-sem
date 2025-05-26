using DAL_Celebrity;
using System.Data.Entity;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace DAL_Celebrity_MSSQL
{
    public interface IRepository : DAL_Celebrity.IRepository<Celebrity, Lifeevent> { }

    public class Celebrity
    {
        public int Id { get; set; }                        // Id Знаменитости        
        public string FullName { get; set; }         // полное имя   Знаменитости
        public string Nationality { get; set; }         // гражданство  Знаменитости ( 2 символа ISO )
        public string? ReqPhotoPath { get; set; }         // reguest path  Фотографии   
        public virtual bool Update(Celebrity celebrity)   // --вспомогательный метод  
        {
            if (!string.IsNullOrEmpty(celebrity.FullName)) this.FullName = celebrity.FullName;
            if (!string.IsNullOrEmpty(celebrity.Nationality)) this.Nationality = celebrity.Nationality;
            if (!string.IsNullOrEmpty(celebrity.ReqPhotoPath)) this.ReqPhotoPath = celebrity.ReqPhotoPath;
            return true;     //  изменения были ?
        }
    }

    public class Lifeevent  //  Событие в  жизни знаменитости 
    {
        public Lifeevent() { this.Description = string.Empty; }
        public int Id { get; set; }           // Id События  
        public int CelebrityId { get; set; }           // Id Знаменитости
        public DateTime? Date { get; set; }           // дата События 
        public string Description { get; set; }           // описание События 
        public string? ReqPhotoPath { get; set; }           // reguest path  Фотографии
        public virtual bool Update(Lifeevent lifeevent)       // -- вспомогательный метод                                           
        {
            if (!(lifeevent.CelebrityId <= 0)) this.CelebrityId = lifeevent.CelebrityId;
            if (!lifeevent.Date.Equals(new DateTime())) this.Date = lifeevent.Date;
            if (!string.IsNullOrEmpty(lifeevent.Description)) this.Description = lifeevent.Description;
            if (!string.IsNullOrEmpty(lifeevent.ReqPhotoPath)) this.ReqPhotoPath = lifeevent.ReqPhotoPath;
            return true;     //  изменения были ?
        }
    }
    public class Repository : IRepository
    {
        ContextBoundObject context;
       public Repository(string directoryPath)
        {
          this.context new Context();
        }
        public Repository(string connectionstring) { this.context = new Context(connectionstring)}
        public static IRepository Create()
        {
            return new Repository();
        }
        public static IRepository Create(string connectionstring)
        {
            return new Repository(connectionstring);
        }

        public List<Celebrity> GetAllCelebrities() { return this.context.ToList<Celebrity>() }
        public void Dispose() { }

        private void LoadCelebrities()
        {
            if (File.Exists(jsonFilePath))
            {
                var json = File.ReadAllText(jsonFilePath);
                celebrities = JsonSerializer.Deserialize<List<Celebrity>>(json) ?? new List<Celebrity>();
            }
            else
            {
                celebrities = new List<Celebrity>();
            }
        }

        public Celebrity[] GetAllCelebrities()
        {
            return celebrities.ToArray();
        }

        public Celebrity? GetCelebrityById(int id)
        {
            return celebrities.FirstOrDefault(x => x.Id == id);
        }

        public Celebrity[] GetCelebritiesBySurname(string surname)
        {
            return celebrities
                .Where(x => x.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public string? GetPhotoPathById(int id)
        {
            var celebrity = GetCelebrityById(id);
            return celebrity?.PhotoPath;
        }

        public int? AddCelebrity(Celebrity celebrity)
        {
            if (celebrity == null)
                return null;

            var maxId = celebrities.Any() ? celebrities.Max(x => x.Id) : 0;
            int newId = celebrity.Id != 0 && !celebrities.Any(x => x.Id == celebrity.Id) ? celebrity.Id : maxId + 1;
            var newCelebrity = new Celebrity(newId, celebrity.Name, celebrity.Surname, celebrity.PhotoPath);
            celebrities.Add(newCelebrity);
            return newId;
        }

        public bool DeleteCelebrityById(int id)
        {
            var celebrity = celebrities.FirstOrDefault(x => x.Id == id);
            if (celebrity == null)
                return false;

            celebrities.Remove(celebrity);
            return true;
        }

        public int? UpdateCelebrityById(int id, Celebrity celebrity)
        {
            var index = celebrities.FindIndex(x => x.Id == id);
            if (index == -1)
                return null;

            var updatedCelebrity = new Celebrity(id, celebrity.Name, celebrity.Surname, celebrity.PhotoPath);
            celebrities[index] = updatedCelebrity;
            return id;
        }

       
    }

    public class Context:DbContext
    {
        public string? ConnectionString { get; private set; } = null;
        public Context(string connstring):base()
            {
            this.ConnectionString = connstring;
        }
        public Context():base()
        {

        }
        public DbSet<Celebrity> Celebrities { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Lifeevent> Lifeevents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.ConnectionString is null) this.ConnectionString = @"Data source =;" + ";";
            optionsBuilderUseSqlServer(this.ConnectionString);
        }


}
