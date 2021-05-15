using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class ShopFactory : IEntityFactory<Shop>
    {
        private static long _id = 1;
        private string name;
        private string city;
        private string neighbourhood;
        private string country;
        private string phoneNumber;

        public ShopFactory(string name, string city, string neighbourhood, string country, string phoneNumber)
        {
            this.name = name;
            this.city = city;
            this.neighbourhood = neighbourhood;
            this.country = country;
            this.phoneNumber = phoneNumber;
        }

        public Shop Instance => new Shop(_id++, name, city, neighbourhood, country, phoneNumber);
    }
}
