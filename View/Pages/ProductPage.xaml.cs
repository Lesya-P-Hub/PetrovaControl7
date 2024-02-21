using PetrovaControl7.Model;
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

namespace PetrovaControl7.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            MakerCmb.SelectedValuePath = "Id";
            MakerCmb.DisplayMemberPath = "Name";
            MakerCmb.ItemsSource = App.context.Manufactura.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(string.IsNullOrEmpty(MakerCmb.Text))
            {
                mes += "Выберите производителя\n";
            }

            if (string.IsNullOrEmpty(ProductTb.Text))
            {
                mes += "Введите название продукта\n";
            }

            if (mes !="")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Material material = new Material()
            {
                Name = ProductTb.Text,
                Manufactura = MakerCmb.SelectedItem as Manufactura
            };

            App.context.Material.Add(material);
            App.context.SaveChanges();
            MessageBox.Show("Запись успешно добавлена");
            MakerCmb.Text = "";
            ProductTb.Text = "";
        }
    }
}
