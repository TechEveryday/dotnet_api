using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Models
{
  [Table("entity_relationship")]
  [Keyless]
  public class EntityRelationship
  {
    [Column("child_entity_id")]
    public Guid ChildEntityId { get; set; }

    [Column("entity_id")]
    public Guid EntityId { get; set; }
  }
}
