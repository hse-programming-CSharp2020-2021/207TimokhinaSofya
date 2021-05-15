using System;
using System.Text.Json.Serialization;

namespace DataBaseTask2
{
    public class Buyer: IEntity
    {
        public long Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Address { get; }
        public string City { get; }
        public string Neighbourhood { get; }
        public string Country { get; }
        public string PostalCode { get; }

        public Buyer() { }

        [JsonConstructor]
        public Buyer(long id, string name, string surname, string address, string city,
            string neighbourhood, string country, string postalCode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Address = address;
            City = city;
            Neighbourhood = neighbourhood;
            Country = country;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"Buyer. {Name} {Surname} {City}";
        }
    }
}
