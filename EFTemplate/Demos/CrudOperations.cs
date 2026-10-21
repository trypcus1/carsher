using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class CrudOperations
    {
        public static void Run(AppDbContext db)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 1. БАЗОВЫЙ CRUD (Create / Read / Update / Delete) ===");
            Console.ResetColor();

            Console.WriteLine("\n[CREATE] Добавляем автомобиль 'Ford Focus'...");
            var newCar = new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2021,
                LicensePlate = "К321ЛМ 77",
                ClientId = 1
            };
            db.Cars.Add(newCar);
            db.SaveChanges();
            Console.WriteLine($"   Автомобиль добавлен. Сгенерированный Id = {newCar.Id}");

            Console.WriteLine("\n[READ] Ищем автомобиль по Id через метод Find...");
            var car = db.Cars.Find(newCar.Id);
            Console.WriteLine($"   Найдено: {car?.Brand} {car?.Model}, {car?.Year} г., номер: {car?.LicensePlate}");

            Console.WriteLine("\n[UPDATE] Меняем год выпуска на 2020...");
            if (car != null)
            {
                car.Year = 2020;
                db.SaveChanges();
                Console.WriteLine("   Изменение сохранено (EF сгенерировал SQL UPDATE автоматически).");
            }

            Console.WriteLine("\n[DELETE] Удаляем только что созданный автомобиль...");
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
                Console.WriteLine("   Запись удалена (EF сгенерировал SQL DELETE).");
            }
        }
    }
}