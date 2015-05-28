using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CritterMVC.Hubs
{
    public class CritsHub : Hub
    {
        public void PostCrits(string text)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.postCritToPage(text);
        }
    }
}