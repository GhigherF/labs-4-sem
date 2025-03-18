open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main argv =
    // Указываем имя JSON-файла
    Repository.JsonFileName <- "celebrities.json"

    // Создаём репозиторий
    use repository = Repository.Create("Celebrities")

    // Создаём приложение
    let builder = WebApplication.CreateBuilder(argv)
    let app = builder.Build()

    // Определяем маршрут
    app.MapGet("/Celebrities", Func<Celebrity[]>(fun () -> repository.GetAllCelebrities()))

    // Запускаем сервер
    app.Run()

    0 // Exit code
