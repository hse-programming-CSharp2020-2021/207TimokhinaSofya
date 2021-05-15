using System;
using System.Linq;

namespace DataBaseTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase db = new DataBase("ShopDataBase");

            db.CreateTable<Good>();
            db.CreateTable<Shop>();
            db.CreateTable<Buyer>();
            db.CreateTable<Sale>();
            db.InsertInto<Shop>(new ShopFactory("Auchan", "city1", "Auchan", "Auchan", "+1 (123) 456-78-90"));
            db.InsertInto<Shop>(new ShopFactory("Magnit", "city2", "Magnit", "Magnit", "+0 (987) 654 32-10"));

            db.InsertInto<Good>(new GoodFactory("Pepsi", 1, "Pepsi", "Pepsi"));
            db.InsertInto(new GoodFactory("3 korochki", 1, "3 korochki", "3 korochki"));
            db.InsertInto(new GoodFactory("Ohota", 2, "Ohota", "Ohota"));
            db.InsertInto(new GoodFactory("Lays", 3, "Lays", "Lays"));

            db.InsertInto<Buyer>(new BuyerFactory("1", "1", "1", "city1", "1", "1", "1"));
            db.InsertInto<Buyer>(new BuyerFactory("11", "11", "11", "city2", "11", "11", "11"));
            db.InsertInto<Buyer>(new BuyerFactory("111", "111", "111", "city2", "111", "111", "111"));

            db.InsertInto(new SaleFactory(1, 1, 1, 10, 100));
            db.InsertInto(new SaleFactory(2, 2, 3, 100, 12));
            db.InsertInto(new SaleFactory(2, 2, 2, 19, 12));
            db.InsertInto(new SaleFactory(3, 1, 2, 155, 100));
            var auchanId = (from shop in db.Table<Shop>()
                            where shop.Name == "Auchan"
                            select shop.Id).First();

            var allAuchanGoods = from good in db.Table<Good>()
                                 where good.ShopId == auchanId
                                 select good;

            foreach (var good in allAuchanGoods)
                Console.WriteLine(good);

            db.Serialize<Good>();
            db.Serialize<Shop>();
            db.Serialize<Buyer>();
            db.Serialize<Sale>();

            db.Deserialize<Good>();
            db.Deserialize<Shop>();
            db.Deserialize<Buyer>();
            db.Deserialize<Sale>();
            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий вывести все товары, купленные покупателем с самым длинным именем.");
            var products = from good in db.Table<Good>()
                           let goodIds = (from sale in db.Table<Sale>()
                                          let idBuyer = db.Table<Buyer>().OrderByDescending(buyer => buyer.Name.Length).First().Id
                                          where sale.IdBuyer == idBuyer
                                          select sale.IdGood).ToList()
                           where goodIds.Contains(good.Id)
                           select good;

            Console.WriteLine(string.Join(", ", products));

            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий найти категорию самого дорого товара.");
            Console.WriteLine(db.Table<Good>().FirstOrDefault(good => good.Id == db.Table<Sale>().OrderBy(sale => -sale.GoodPrice).First().IdGood).Category);

            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий найти город, в котором общая сумма всех продаж наименьшая.");
            Console.WriteLine(db.Table<Shop>().OrderBy(shop => (from sale in db.Table<Sale>()
                                                                where sale.IdShop == shop.Id
                                                                select sale.Total).Sum()).First().City);

            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий найти фамилии покупателей, купивших самый популярный товар (популярный товар – товар, которого было куплено наибольшее количество среди всех покупок).");
            Console.WriteLine(string.Join(", ", from buyer in db.Table<Buyer>()
                                                let buyerIds = (from sale in db.Table<Sale>()
                                                                group sale by sale.IdGood).OrderByDescending(gr => gr.Select(sl => sl.GoodCount).Sum()).First().Select(sale => sale.IdBuyer).ToList()
                                                where buyerIds.Contains(buyer.Id)
                                                select buyer.Surname));

            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий найти количество магазинов в стране, где их меньше всего.");
            Console.WriteLine((from shop in db.Table<Shop>()
                               group shop by shop.Country into shopCountry
                               orderby shopCountry.Count()
                               select shopCountry.Count()).First());

            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий найти покупки, которые были сделаны не в своем городе, т. е. если покупатель проживает в городе А, а покупку сделал в городе Б.");
            Console.WriteLine(string.Join(", ", from sale in db.Table<Sale>()
                                                join shop in db.Table<Shop>() on sale.IdShop equals shop.Id
                                                join buyer in db.Table<Buyer>() on sale.IdBuyer equals buyer.Id
                                                where buyer.City != shop.City
                                                select sale));
            Console.WriteLine("\nСоздать LINQ-запрос, позволяющий найти общую стоимость всех покупок.");
            Console.WriteLine(db.Table<Sale>().Select(sale => sale.Total).Sum());
        }
    }
}