using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AubreyRussellServer.Hubs
{
    public class DemoHub : Hub
    {
        public async Task SendData()
        {
            float[] testData = new float[100];

            Random rng = new Random();
            for (int i = 0; i < testData.Length; i++)
            {
                testData[i] = (float)rng.Next(0, 1000);
            }

            await Clients.All.SendAsync("ReceiveData", testData, this.Context.GetHttpContext().Request.QueryString.ToUriComponent(), this.Context.GetHttpContext().TraceIdentifier);
        }
    }
}
