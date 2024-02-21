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
    /// Логика взаимодействия для MakerPage.xaml
    /// </summary>
    public partial class MakerPage : Page
    {
        public MakerPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrEmpty(MakerTb.Text))
            {
                mes += "Введите имя производителя!";
            }

            if(mes!="")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Manufactura manufactura = new Manufactura()
            {
                Name= MakerTb.Text
            };

            App.context.Manufactura.Add(manufactura);
            App.context.SaveChanges();
            MessageBox.Show("Запись успешно добавлена");
            MakerTb.Clear();
        }
    }
}
