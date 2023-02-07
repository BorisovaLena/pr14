using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pr14
{
    /// <summary>
    /// Логика взаимодействия для WindowUpcomingEntries.xaml
    /// </summary>
    public partial class WindowUpcomingEntries : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public WindowUpcomingEntries()
        {
            InitializeComponent();
            DateTime tomorrow = DateTime.Today.AddDays(2);
            List<ClientService> clientServices = classes.ClassBase.Base.ClientService.Where(z => z.StartTime >= DateTime.Today && z.StartTime < tomorrow).ToList();
            dgUpcomingEntries.ItemsSource = clientServices.OrderBy(z => z.StartTime);
            Timer();
        }

        public void Timer()
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Tick += new EventHandler(DisTimer_Tick);
            dispatcherTimer.Start();
        }

        private void DisTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            DateTime tomorrow = DateTime.Today.AddDays(2);
            dgUpcomingEntries.ItemsSource = classes.ClassBase.Base.ClientService.Where(z => z.StartTime >= DateTime.Today && z.StartTime < tomorrow).ToList();
            Timer();
        }

    }
}
