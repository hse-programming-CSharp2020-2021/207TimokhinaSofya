using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Good : IEntity
    {
        public long Id { get; }
        public string Name { get; }
        public long ShopId { get; }
        public string Category { get; }
        public string Description { get; }

        public Good() { }

        public Good(long id, string name, long shopId)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
        }

        [JsonConstructor]
        public Good(long id, string name, long shopId, string category, string description): this(id, name, shopId)
        {
            Category = category;
            Description = description;
        }

        public override string ToString()
        {
            return $"Good. {Name} {Category} {Description}";
        }
    }
}
