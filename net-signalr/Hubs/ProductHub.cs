using Microsoft.AspNet.SignalR;
using net_signalr.Models;

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