using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamsGH.Classes
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Items { get; set; }

        public string RecepientName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public byte[] Picture { get; set; }

        public DateTime OrderDate { get; set; }

        public double AmountPaid { get; set; }

    }
}
