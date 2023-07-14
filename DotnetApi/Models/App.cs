using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApi.Models
{
    [Table("app")]
    public class App
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
