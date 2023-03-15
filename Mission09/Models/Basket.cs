using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public virtual void AddItem(Project proj, int qty)
        {
            BasketLineItem line = Items
                .Where(p => p.Project.BookId == proj.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Project = proj,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Project proj)
        {
            Items.RemoveAll(x => x.Project.BookId == proj.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Project.Price);

            return sum;
        }
    }
    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Project Project { get; set; }
        public int Quantity { get; set; }

    }
}
