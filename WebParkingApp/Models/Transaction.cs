using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParkingApp
{
    public class Transaction
    {
        public string CarId { get; set; }
        public int WriteOffs { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
