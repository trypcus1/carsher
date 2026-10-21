using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EFTemplate.Models;

namespace EFTemplate.Data
{
    public static class DbInitializer
    {
        public static void ResetAndSeed(AppDbContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[БАЗА ДАННЫХ] Удаление старой версии SQLite...");
            context.Database.EnsureDeleted();

            Console.WriteLine("[БАЗА ДАННЫХ] Создание чистой структуры по текущим моделям...");
            context.Database.EnsureCreated();
            Console.ResetColor();

            var ivanov = new Client
            {
                FullName = "Иванов Иван Иванович",
                Phone = "+7 (900) 123-45-67",
                Email = "ivanov@example.com"
            };
            var petrova = new Client
            {
                FullName = "Петрова Мария Сергеевна",
                Phone = "+7 (911) 765-43-21",
                Email = "petrova@example.com"
            };

            var camry = new Car
            {
                Brand = "Toyota",
                Model = "Camry",
                Year = 2020,
                LicensePlate = "А123БВ 77",
                Client = ivanov,
                Passport = new ServicePassport
                {
                    PassportNumber = "СП-0001",
                    Mileage = 45000,
                    LastServiceInfo = "Замена масла, 2024-06"
                }
            };
            var bmw = new Car
            {
                Brand = "BMW",
                Model = "X5",
                Year = 2022,
                LicensePlate = "В456ГД 99",
                Client = ivanov,
                Passport = new ServicePassport
                {
                    PassportNumber = "СП-0002",
                    Mileage = 18000,
                    LastServiceInfo = "ТО-1, 2024-08"
                }
            };
            var kia = new Car
            {
                Brand = "Kia",
                Model = "Rio",
                Year = 2019,
                LicensePlate = "Е789ЖЗ 50",
                Client = petrova,
                Passport = new ServicePassport
                {
                    PassportNumber = "СП-0003",
                    Mileage = 72000,
                    LastServiceInfo = "Замена тормозных колодок, 2024-05"
                }
            };

            context.Clients.AddRange(ivanov, petrova);
            context.Cars.AddRange(camry, bmw, kia);
            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[БАЗА ДАННЫХ] Пересоздано: клиентов = {context.Clients.Count()}, " +
                              $"авто = {context.Cars.Count()}, паспортов = {context.ServicePassports.Count()}");
            Console.ResetColor();
        }
    }
}