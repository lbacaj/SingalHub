using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalREngine;
using SignalREngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalREngine
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

        public void Heartbeat()
        {
            Clients.All.heartbeat();
        }

        public void SendHelloObject(HelloModel hello)
        {
            Clients.All.sendHelloObject(hello);
        }

        public override Task OnConnected()
        {
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            return (base.OnDisconnected());
        }
    }
}
