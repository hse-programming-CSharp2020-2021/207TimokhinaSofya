using System;
namespace DataBaseTask2
{
    public class SaleFactory: IEntityFactory<Sale>
    {
        static long id = 1;
        long idBuyer, idShop, idGood, goodCount, goodPrice;
        public SaleFactory(long idBuyer, long idShop, long idGood, long goodCount, long goodPrice)
        {
            this.idBuyer = idBuyer;
            this.idShop = idShop;
            this.idGood = idGood;
            this.goodCount = goodCount;
            this.goodPrice = goodPrice;
        }

        public Sale Instance => new Sale(id, idBuyer, idShop, idGood, goodCount, goodPrice);
    }
}
