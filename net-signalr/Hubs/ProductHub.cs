using DAL.Models;
using Microsoft.AspNet.SignalR;

namespace net_signalr.Hubs
{
    public class ProductHub : Hub
    {
        public ProductHub()
        {

        }

        public void Update(Product product)
        {
            Clients.All.applyChanges(product);
        }
    }
}