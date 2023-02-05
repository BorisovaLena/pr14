using System;
using System.Windows.Media;

namespace pr14
{
    public partial class ClientService
    {
        int hours = 0, min = 0;
        public string TimeLeft
        {

            get
            {
                hours = 0; min = 0;
                if (StartTime < DateTime.Now)
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

        public SolidColorBrush Color
        {
            get
            {
                if (hours < 1) { return Brushes.Red; }
                else { return Brushes.Black; }
            }
        }
    }
}
