using System;

namespace DotnetApi.Models
{
    public class Record
    {
        public string Value { get; set; }

        public Guid AttributeId { get; set; }

        public Guid EntityId { get; set; }

        public int Id { get; set; }
    }
}
