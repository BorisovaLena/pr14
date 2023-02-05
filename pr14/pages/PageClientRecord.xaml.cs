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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr14.pages
{
    /// <summary>
    /// Логика взаимодействия для PageClientRecord.xaml
    /// </summary>
    public partial class PageClientRecord : Page
    {
        public PageClientRecord(Service service)
        {
            InitializeComponent();
            List<Client> clients = classes.ClassBase.Base.Client.ToList();
            for(int i=0; i<clients.Count; i++)
            {
                cmbClient.Items.Add(clients[i].FirstName + " " + clients[i].LastName + " "+ clients[i].Patronymic);
            }
            tbName.Text = service.Title;
            tbTime.Text = (service.DurationInSeconds/60).ToString() + " минут";
        }

        private void cmbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
