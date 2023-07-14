using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApi.Models
{
    [Table("attribute")]
    public class Attribute
    {
        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("entity_id")]
        public Guid EntityId { get; set; }

        [Column("id")]
        public Guid Id { get; set; }
    }
}
