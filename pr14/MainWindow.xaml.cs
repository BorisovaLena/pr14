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

namespace pr14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string code;
        public MainWindow()
        {   
            InitializeComponent();
            code = tbCode.Text;
            classes.ClassFrame.mainFrame = frMain;
            classes.ClassBase.Base = new Entities();
            classes.ClassFrame.mainFrame.Navigate(new pages.PageService(code));
        }
    }
}
