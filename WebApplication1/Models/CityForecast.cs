using System;

namespace WebApplication1.Models
{
    public class CityForecast
    {
        public DateTime? Date { get; set; }

        public int? Temperature { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
