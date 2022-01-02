using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShopSportShoes.Services
{
    public class OrderRealtimeService
    {
        public void UpdateCart()
        {
            Func?.Invoke();
        }

        public event Func<Task> Func;
    }
}
