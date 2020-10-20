using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skyrmium.Composed.Entities
{
    public class Company : EntityBase
    {
        public string TIN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public ICollection<StockHistory> Stocks { get; set; }

        public IEnumerable<IngredientStock> GetCurrentAllStock()
        {
            var list = new List<IngredientStock>();

            foreach (var branch in Branches)
                list.AddRange(branch.Warehouse.CurrentStock);

            return list;
        }
    }
}
