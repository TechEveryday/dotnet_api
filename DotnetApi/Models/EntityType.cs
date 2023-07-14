using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApi.Models
{
    [Table("entity_type")]
    public class EntityType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
