using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Service service;
        public PageClientRecord(Service service)
        {
            InitializeComponent();
            this.service = service;
            List<Client> clients = classes.ClassBase.Base.Client.ToList();
            for(int i=0; i<clients.Count; i++)
            {
                cmbClient.Items.Add(clients[i].FirstName + " " + clients[i].LastName + " "+ clients[i].Patronymic);
            }
            tbName.Text = service.Title;
            tbTime.Text = (service.DurationInSeconds/60).ToString() + " минут";
        }

        private void btnSaveClientrecord_Click(object sender, RoutedEventArgs e)
        {
            if (cmbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите клиента!!!");
            }
            else
            {
                if (dpDate.SelectedDate == null)
                {
                    MessageBox.Show("Выберите дату!!!");
                }
                else
                {
                    if (tbStartTimeHours.Text=="" || tbStartTimeMin.Text=="")
                    {
                        MessageBox.Show("Введите время!!!");
                    }
                    else
                    {
                        ClientService clientService = new ClientService();
                        string str = cmbClient.SelectedItem.ToString();
                        int i = 1;
                        int n = 0;
                        string surname = "";
                        while (i == 1)
                        {
                            if (str[n] == ' ')
                            {
                                i = 0;
                            }
                            else
                            {
                                surname += str[n];
                                n++;
                            }
                        }
                        Client client = classes.ClassBase.Base.Client.FirstOrDefault(z => z.FirstName == surname);
                        clientService.ClientID = client.ID;
                        clientService.ServiceID = service.ID;
                        DateTime dateT = dpDate.SelectedDate.Value;
                        dateT = dateT.Add(new TimeSpan(Convert.ToInt32(tbStartTimeHours.Text), Convert.ToInt32(tbStartTimeMin.Text), 0));
                        clientService.StartTime = dateT;
                        classes.ClassBase.Base.ClientService.Add(clientService);
                        classes.ClassBase.Base.SaveChanges();
                        MessageBox.Show("Успешная запись на услугу!!!");
                        classes.ClassFrame.mainFrame.Navigate(new PageService());

                    }
                }
            }
        }

        private void tbStartTimeHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void tbStartTimeHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tbStartTimeHours.Text!="" && tbStartTimeMin.Text!="" && tbStartTimeHours.Text.Length==2 && tbStartTimeMin.Text.Length==2)
            {
                int hours = Convert.ToInt32(tbStartTimeHours.Text);
                int min = Convert.ToInt32(tbStartTimeMin.Text);
                if (hours > 23 || min > 59)
                {
                    MessageBox.Show("Введите время корректно!!!");
                    tbStartTimeMin.Text = "";
                    tbStartTimeHours.Text = "";
                }
                else
                {
                    int DurationInMin = service.DurationInSeconds / 60;
                    int startInMin = hours * 60 + min;
                    int endInMin = startInMin + DurationInMin;
                    int hoursEnd = endInMin / 60;
                    int minEnd = endInMin - hoursEnd * 60;
                    if(minEnd<10)
                    {
                        tbEndTime.Text = hoursEnd + ":0" + minEnd;
                    }
                    else
                    {
                        tbEndTime.Text = hoursEnd + ":" + minEnd;
                    }
                    
                }
            }
            
        }
    }
}
