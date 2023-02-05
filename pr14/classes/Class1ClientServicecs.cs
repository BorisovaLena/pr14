using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr14
{
    public partial class ClientService
    {
        int hours = 0, min = 0;
        public string TimeLeft
        { 
            get
            {
                
                if(StartTime < DateTime.Now)
                {
                    return "0 ч. 0 мин.";
                }
                else
                {
                    TimeSpan dateTime = StartTime - DateTime.Now;
                    if (dateTime.Days > 0)
                    {
                        hours += 24 * Convert.ToInt32(dateTime.Days);
                    }
                    hours += Convert.ToInt32(dateTime.ToString("hh"));
                    min = Convert.ToInt32(dateTime.ToString("mm"));
                    return hours + " ч. " + min + " мин.";
                }
                
            }
        }
    }
}
