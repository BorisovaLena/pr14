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
    /// Логика взаимодействия для WindowAddUpdate.xaml
    /// </summary>
    public partial class WindowAddUpdate : Window
    {
        bool add;
        Service Sservice;
        public WindowAddUpdate()
        {
            InitializeComponent();
            add = true;
            image.Source = new BitmapImage(new Uri("..\\pictures\\picture.png", UriKind.Relative));
        }

        public WindowAddUpdate(Service service)
        {
            InitializeComponent();
            add = false;
            Sservice = service;
            tbName.Text = service.Title;
            tbCost.Text = service.Cost.ToString();
            tbDurationInSeconds.Text = service.DurationInSeconds.ToString();
            tbDescription.Text = service.Description;
            tbDiscount.Text = service.Discount.ToString();
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (add == true)
            {
                Sservice = new Service();
            }
            Sservice.Title = tbName.Text;
            Sservice.Cost = (decimal)Convert.ToDouble(tbCost.Text);
            Sservice.DurationInSeconds = Convert.ToInt32(tbDurationInSeconds.Text);
            Sservice.Description = tbDescription.Text;
            if(tbDiscount.Text!="")
            {
                Sservice.Discount = Convert.ToDouble(tbDiscount.Text);
            }
            else { Sservice.Discount = null; }
            

            if (add == true)
            {
                classes.ClassBase.Base.Service.Add(Sservice);
            }

            classes.ClassBase.Base.SaveChanges();
            MessageBox.Show("Успешное добавление записи!!!");
            Close();
        }
    }
}
