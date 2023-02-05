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

namespace pr14
{
    /// <summary>
    /// Логика взаимодействия для WindowUpcomingEntries.xaml
    /// </summary>
    public partial class WindowUpcomingEntries : Window
    {
        public WindowUpcomingEntries()
        {
            InitializeComponent();
            dgUpcomingEntries.ItemsSource = classes.ClassBase.Base.ClientService.ToList();

        }
    }
}
