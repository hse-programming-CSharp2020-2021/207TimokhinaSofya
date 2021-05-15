using System;
namespace DataBaseTask2
{
    public class BuyerFactory: IEntityFactory<Buyer>
    {
        static int id = 1;
        string name, surname, address, city, neighbourhood, country, postalCode;

        public BuyerFactory(string name, string surname, string address, string city, string country, string neighbourhood, string postalCode)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.city = city;
            this.neighbourhood = neighbourhood;
            this.country = country;
            this.postalCode = postalCode;
        }

        public Buyer Instance => new Buyer(id++, name, surname, address, city, neighbourhood, country, postalCode);
    }
}
