using System.Windows.Media;

namespace pr14
{
    public partial class Service
    {
        public string Price
        {
            get
            {
                if (Discount != null)
                {
                    double f = (double)Cost - (double)Cost * (double)Discount;
                    return string.Format("{0:C2} за {1} минут *скидка {2} %", f, DurationInSeconds / 60, Discount * 100);
                }
                else
                {
                    return string.Format("{0:C2} за {1} минут", Cost, DurationInSeconds / 60);
                }
            }
        }

        public string PriceOld
        {
            get
            {
                if (Discount != null)
                {
                    return string.Format("{0:C2} ", Cost);
                }
                else { return ""; }
            }
        }

        public SolidColorBrush Color
        {
            get
            {
                if (Discount != null)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.White;
                }
            }
        }
    }
}
