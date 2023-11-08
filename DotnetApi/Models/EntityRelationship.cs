using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Models
{
  [Table("entity_relationship")]
  public class EntityRelationship
  {
    [Column("id")]
    public Guid Id { get; set; }
    [Column("child_entity_id")]
    public Guid ChildEntityId { get; set; }
    [Column("entity_id")]
    public Guid EntityId { get; set; }
  }
}
