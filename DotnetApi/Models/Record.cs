using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApi.Models
{
    [Table("record")]
    public class Record
    {
        [Column("value")]
        public string Value { get; set; }

        [Column("attribute_id")]
        public Guid AttributeId { get; set; }

        [Column("entity_id")]
        public Guid EntityId { get; set; }

        [Column("id")]
        public int Id { get; set; }
    }
}
