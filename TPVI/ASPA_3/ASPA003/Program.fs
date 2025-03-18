open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main argv =
    // ��������� ��� JSON-�����
    Repository.JsonFileName <- "celebrities.json"

    // ������ �����������
    use repository = Repository.Create("Celebrities")

    // ������ ����������
    let builder = WebApplication.CreateBuilder(argv)
    let app = builder.Build()

    // ���������� �������
    app.MapGet("/Celebrities", Func<Celebrity[]>(fun () -> repository.GetAllCelebrities()))

    // ��������� ������
    app.Run()

    0 // Exit code
