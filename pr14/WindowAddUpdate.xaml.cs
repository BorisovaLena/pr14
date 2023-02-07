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
            gbId.Visibility = Visibility.Collapsed;
        }

        public WindowAddUpdate(Service service)
        {
            InitializeComponent();
            add = false;
            tbId.Text = service.ID.ToString();
            Sservice = service;
            tbName.Text = service.Title;
            tbCost.Text = service.Cost.ToString();
            tbDurationInSeconds.Text = service.DurationInSeconds.ToString();
            tbDescription.Text = service.Description;
            tbDiscount.Text = service.Discount.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(tbName.Text=="" || tbCost.Text == "" || tbDurationInSeconds.Text=="")
            {
                MessageBox.Show("Заполните обязательные поля: Название, Стоимость и Длительность!!!");
            }
            else
            {
                if (add == true)
                {
                    Sservice = new Service();
                    List<Service> service = classes.ClassBase.Base.Service.Where(z => z.Title == tbName.Text).ToList();
                    if (service.Count == 0)
                    {
                        Sservice.Title = tbName.Text;
                        Sservice.Cost = (decimal)Convert.ToDouble(tbCost.Text);
                        if (Convert.ToInt32(tbDurationInSeconds.Text) < 14401)
                        {
                            if (Convert.ToInt32(tbDurationInSeconds.Text) > 0)
                            {
                                Sservice.DurationInSeconds = Convert.ToInt32(tbDurationInSeconds.Text);
                                Sservice.Description = tbDescription.Text;
                                if (tbDiscount.Text != "")
                                {
                                    Sservice.Discount = Convert.ToDouble(tbDiscount.Text)/100;
                                }
                                else { Sservice.Discount = null; }
                                classes.ClassBase.Base.Service.Add(Sservice);
                                classes.ClassBase.Base.SaveChanges();
                                MessageBox.Show("Успешное добавление записи!!!");
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Длительность услуги не может быть отрицательным числом!!!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Длительность услуги не может быть больше 14400 секунд (4 часов)!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данное название уже существует!!!");
                    }
                }
                else
                {
                    Sservice.Title = tbName.Text;
                    Sservice.Cost = (decimal)Convert.ToDouble(tbCost.Text);
                    if (Convert.ToInt32(tbDurationInSeconds.Text) < 14401)
                    {
                        if (Convert.ToInt32(tbDurationInSeconds.Text) > 0)
                        {
                            Sservice.DurationInSeconds = Convert.ToInt32(tbDurationInSeconds.Text);
                            Sservice.Description = tbDescription.Text;
                            if (tbDiscount.Text != "")
                            {
                                Sservice.Discount = Convert.ToDouble(tbDiscount.Text)/100;
                            }
                            else { Sservice.Discount = null; }
                            classes.ClassBase.Base.SaveChanges();
                            MessageBox.Show("Успешное добавление записи!!!");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Длительность услуги не может быть отрицательным числом!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Длительность услуги не может быть больше 14400 секунд (4 часов)!!!");
                    }
                }
            }
            
        }

        private void tbCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
