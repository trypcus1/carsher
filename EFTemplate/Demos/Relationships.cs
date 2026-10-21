using EFTemplate.Data;
using EFTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Demos
{
    public static class RelationshipsDemo
    {
        public static void Run(AppDbContext db)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== 3. СВЯЗИ И КАСКАДНОЕ УДАЛЕНИЕ ===");
            Console.ResetColor();

            var tempClient = new Client
            {
                FullName = "Временный Клиент",
                Phone = "+7 (000) 000-00-00",
                Email = "temp@example.com",
                Cars = new List<Car>
                {
                    new Car
                    {
                        Brand = "Temp",
                        Model = "TempModel",
                        Year = 2024,
                        LicensePlate = "ВРЕ-001",
                        Passport = new ServicePassport
                        {
                            PassportNumber = "СП-9999",
                            Mileage = 0,
                            LastServiceInfo = "Временная запись"
                        }
                    }
                }
            };

            db.Clients.Add(tempClient);
            db.SaveChanges();
            Console.WriteLine($"Клиент '{tempClient.FullName}' создан вместе с авто и паспортом.");

            Console.WriteLine("\n--> Удаляем клиента 'Временный Клиент' (каскад)...");
            db.Clients.Remove(tempClient);
            db.SaveChanges();

            var orphanCar = db.Cars.FirstOrDefault(c => c.Brand == "Temp");
            var orphanPassport = db.ServicePassports.FirstOrDefault(p => p.PassportNumber == "СП-9999");

            Console.WriteLine($"   Авто после удаления клиента:      {(orphanCar != null ? "ЕСТЬ (плохо)" : "НЕТ (удалено каскадно)")}");
            Console.WriteLine($"   Паспорт после удаления клиента:   {(orphanPassport != null ? "ЕСТЬ (плохо)" : "НЕТ (удалён каскадно)")}");
        }
    }
}