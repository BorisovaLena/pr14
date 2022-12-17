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
    /// Логика взаимодействия для PageService.xaml
    /// </summary>
    public partial class PageService : Page
    {
        List<Service> listFilter;
        public PageService()
        {
            InitializeComponent();
            listServices.ItemsSource = classes.ClassBase.Base.Service.ToList();
            cmbSort.SelectedIndex = 0;
        }

        void Filter()
        {
            listFilter = classes.ClassBase.Base.Service.ToList();
            if (!string.IsNullOrWhiteSpace(tbSearch.Text)) //поиск
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
    }
}
