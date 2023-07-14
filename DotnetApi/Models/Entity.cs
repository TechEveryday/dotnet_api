using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetApi.Models
{
    [Table("entity")]
    public class Entity
    {
        [Column("type_id")]
        public int TypeId { get; set; }

        [Column("app_id")]
        public int AppId { get; set; }

        [Column("id")]
        public Guid Id { get; set; }
    }
}
