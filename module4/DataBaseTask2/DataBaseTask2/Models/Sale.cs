using System;
using System.Text.Json.Serialization;

namespace DataBaseTask2
{
    public class Sale : IEntity
    {
        public long Id {get;}
        public long IdBuyer { get; }
        public long IdShop { get; }
        public long IdGood { get; }
        public long GoodCount { get; }
        public long GoodPrice { get; }
        [JsonIgnore]
        public long Total => GoodCount * GoodPrice;

        public Sale() { }

        [JsonConstructor]
        public Sale(long id, long idBuyer, long idShop, long idGood, long goodCount, long goodPrice)
        {
            Id = id;
            IdBuyer = idBuyer;
            IdShop = idShop;
            IdGood = idGood;
            GoodCount = goodCount;
            GoodPrice = goodPrice;
        }

        public override string ToString()
        {
            return $"Sale. Good id {IdGood}, total price {Total}";
        }
    }
}
