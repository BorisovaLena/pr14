﻿using System;
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
    /// Логика взаимодействия для PageService.xaml
    /// </summary>
    public partial class PageService : Page
    {
        List<Service> listFilter;
        string code;
        public PageService(string code)
        {
            InitializeComponent();
            this.code = code;
            listServices.ItemsSource = classes.ClassBase.Base.Service.ToList();
            cmbSort.SelectedIndex = 0;
            cmbSort2.SelectedIndex = 0;
        }

        void Filter()
        {
            listFilter = classes.ClassBase.Base.Service.ToList();
            if (!string.IsNullOrWhiteSpace(tbSearch.Text))
            {
                listFilter = listFilter.Where(z => z.Title.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            switch (cmbSort.SelectedIndex)
            {
                case 1:
                    listFilter = listFilter.Where(z => z.Discount < 0.05).ToList();
                    break;
                case 2:
                    listFilter = listFilter.Where(z => z.Discount > 0.05 && z.Discount<0.15).ToList();
                    break;
                case 3:
                    listFilter = listFilter.Where(z => z.Discount > 0.15 && z.Discount < 0.3).ToList();
                    break;
                case 4:
                    listFilter = listFilter.Where(z => z.Discount > 0.3 && z.Discount < 0.7).ToList();
                    break;
                case 5:
                    listFilter = listFilter.Where(z => z.Discount > 0.7).ToList();
                    break;
            }

            switch (cmbSort2.SelectedIndex)
            {
                case 1:
                    listFilter.Sort((x, y) => x.Cost.CompareTo(y.Cost));
                    break;
                case 2:
                    listFilter.Sort((x, y) => x.Cost.CompareTo(y.Cost));
                    listFilter.Reverse();
                    break;
            }

            listServices.ItemsSource = listFilter;

            int zap = listFilter.Count;
            int vzap = classes.ClassBase.Base.Service.Count();

            tbData.Text = zap + " из " + vzap;

            if (listFilter.Count == 0)
            {
                MessageBox.Show("нет записей");
            }
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch(MessageBox.Show("Вы уверены, что хотите удалить?", "", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    Button btn = (Button)sender;
                    int index = Convert.ToInt32(btn.Uid);

                    List<ClientService> clientServices = classes.ClassBase.Base.ClientService.Where(z => z.ServiceID == index).ToList();
                    if (clientServices.Count == 0)
                    {
                        Service service = classes.ClassBase.Base.Service.FirstOrDefault(z => z.ID == index);
                        classes.ClassBase.Base.Service.Remove(service);
                        classes.ClassBase.Base.SaveChanges();
                        classes.ClassFrame.mainFrame.Navigate(new PageService(code));
                    }
                    else
                    {
                        MessageBox.Show("Удаление запрещено!!! На данную услугу есть записи!!!");
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Service service = classes.ClassBase.Base.Service.FirstOrDefault(z => z.ID == index);
            classes.ClassFrame.mainFrame.Navigate(new PageClientRecord(service, code));
        }

        private void btnWindowUpcomingEntries_Click(object sender, RoutedEventArgs e)
        {
            WindowUpcomingEntries windowUpcomingEntries = new WindowUpcomingEntries();
            windowUpcomingEntries.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);

            Service service = classes.ClassBase.Base.Service.FirstOrDefault(z => z.ID == index);
            WindowAddUpdate windowAddUpdate = new WindowAddUpdate(service);
            windowAddUpdate.ShowDialog();
            classes.ClassFrame.mainFrame.Navigate(new PageService(code));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddUpdate windowAddUpdate = new WindowAddUpdate();
            windowAddUpdate.ShowDialog();
            classes.ClassFrame.mainFrame.Navigate(new PageService(code));
        }

        private void btnDelete_Loaded(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (code == "0000")
            {
                btn.Visibility = Visibility.Visible;
            }
            else
            {
                btn.Visibility = Visibility.Collapsed;
            }
        }

        private void btnUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (code == "0000")
            {
                btn.Visibility = Visibility.Visible;
            }
            else
            {
                btn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
