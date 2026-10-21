using EFTemplate.Data;
using EFTemplate.Demos;

Console.Title = "Введение в Entity Framework Core — Автосервис";
Console.OutputEncoding = System.Text.Encoding.UTF8;

using (var db = new AppDbContext())
{
    DbInitializer.ResetAndSeed(db);

    CrudOperations.Run(db);
    ChangeTracker.Run(db);
    RelationshipsDemo.Run(db);
}

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("\nНажмите любую клавишу для завершения...");
Console.ReadKey();