using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingManagerApp.Models
{
    public class AppState
    {
        public int Id { get; set; }
        public DateTimeOffset? LastPricesUpdateUtc { get; set; }
        public AppState() { }
    }
}
