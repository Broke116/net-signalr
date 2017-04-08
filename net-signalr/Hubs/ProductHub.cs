using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNet.SignalR;
using net_signalr.Models;

namespace net_signalr.Hubs
{
    public class ProductHub : Hub
    {
        public ProductHub()
        {

        }

        public override async Task OnConnected()
        {
            var userId = Context.ConnectionId;
            if(User.users.IndexOf(userId) == -1)
            {
                User.users.Add(userId);
            }

            await UserCount(User.users.Count, true);
        }

        public override async Task OnDisconnected(bool stopCalled)
        {
            var userId = Context.ConnectionId;
            if (User.users.IndexOf(userId) > -1)
            {
                User.users.Remove(userId);
            }

            await UserCount(User.users.Count, false);
        }

        public async Task UserCount(int userCount, bool isConnect)
        {
            await Clients.All.showUserCount(userCount);
        }

        public static void Show(ProductViewModel product)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ProductHub>();
            context.Clients.All.displayChanges();
        }

        public void Update(Product product)
        {
            Clients.All.applyChanges(product);
        }
    }
}