using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class ChangeTracker
    {
        public static void Run(AppDbContext db)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 2. CHANGE TRACKER (ОТСЛЕЖИВАНИЕ СОСТОЯНИЙ) ===");
            Console.ResetColor();

            var car = new Car
            {
                Brand = "Тест",
                Model = "Тестовый",
                Year = 2024,
                LicensePlate = "ТЕС-001",
                ClientId = 1
            };
            Console.WriteLine($"1. Объект создан в C#:               State = {db.Entry(car).State}");

            db.Cars.Add(car);
            Console.WriteLine($"2. После db.Cars.Add():             State = {db.Entry(car).State}");

            db.SaveChanges();
            Console.WriteLine($"3. После db.SaveChanges():          State = {db.Entry(car).State}");

            car.Model = "Изменённый";
            Console.WriteLine($"4. Изменили свойство в коде:        State = {db.Entry(car).State}");

            db.Cars.Remove(car);
            Console.WriteLine($"5. После db.Cars.Remove():          State = {db.Entry(car).State}");

            db.SaveChanges();
            Console.WriteLine($"6. После удаления и SaveChanges():  State = {db.Entry(car).State}");
        }
    }
}