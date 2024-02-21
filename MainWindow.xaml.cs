﻿using PetrovaControl7.AppData;
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

namespace PetrovaControl7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameClass.MenuFrame = MenuFrm;
            MenuFrm.Navigate(new View.Pages.MenuPage());
            FrameClass.BodyFrame = BodyFrm;
            BodyFrm.Navigate(new View.Pages.StartPage());
        }
    }
}
