using System;
using System.Collections.Generic;
using System.Text;

namespace EFTemplate.Models
{
    public class ServicePassport
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; } = string.Empty; // напр. "СП-0001"
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public int Mileage { get; set; }
        public string LastServiceInfo { get; set; } = string.Empty;

        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}