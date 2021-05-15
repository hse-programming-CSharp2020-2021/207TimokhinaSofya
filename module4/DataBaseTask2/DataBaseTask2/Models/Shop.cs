using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class Shop : IEntity
    {
        public long Id { get; }
        public string Name { get; }
        public string City { get; }
        public string Neighbourhood { get; }
        public string Country { get; }
        public string PhoneNumber { get; }

        public Shop() { }

        [JsonConstructor]
        public Shop(long id, string name, string city,
            string neighbourhood, string country,
            string phoneNumber): this(id, name)
        {
            City = city;
            Neighbourhood = neighbourhood;
            Country = country;
            PhoneNumber = phoneNumber;
        }

        public Shop(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
