using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingalHub
{
    [HubName("tickerMini")]
    public class TickerHub : Hub
    {
        private readonly StockTicker _stockTicker;

        public TickerHub() : this(StockTicker.Instance) { }

        public TickerHub(StockTicker stockTicker)
        {
            _stockTicker = stockTicker;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockTicker.GetAllStocks();
        }

        public string GetMarketState()
        {
            return _stockTicker.MarketState.ToString();
        }

        public void OpenMarket()
        {
            _stockTicker.OpenMarket();
        }

        public void CloseMarket()
        {
            _stockTicker.CloseMarket();
        }

        public void Reset()
        {
            _stockTicker.Reset();
        }

    }

    [HubName("messageMini")]
    public class MessageHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
