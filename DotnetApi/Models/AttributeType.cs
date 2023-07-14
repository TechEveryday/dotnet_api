using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApi.Models
{
    [Table("attribute_type")]
    public class AttributeType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}
