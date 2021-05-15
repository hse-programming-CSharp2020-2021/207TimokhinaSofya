using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class GoodFactory : IEntityFactory<Good>
    {
        private static long _id = 0;
        private long _shopId;
        private string _name;
        private string category;
        private string description;

        public GoodFactory(string name, long shopId, string category, string description)
        {
            _name = name;
            _shopId = shopId;
            this.category = category;
            this.description = description;

        }

        public Good Instance => new Good(_id++, _name, _shopId, category, description);
    }
}
