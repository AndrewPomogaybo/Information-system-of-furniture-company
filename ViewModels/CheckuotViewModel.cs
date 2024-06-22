using System;
using System.Collections.Generic;
using System.Linq;


namespace ShopMetta.ViewModels
{
    public class CheckuotViewModel
    {
        public static List<string> GetClients()
        {
            using (var context = new DataBaseContext())
            {
                List<string> clientFullName = context.Clients.Select(c => c.FullName).ToList();
                return clientFullName;
            }
        }

        public static DateTime SetDateLimits()
        {
            return  DateTime.Today;
        }


        
    }
}
