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
    /// Логика взаимодействия для AccAddPage.xaml
    /// </summary>
    public partial class AccAddPage : Page
    {
        public AccAddPage()
        {
            InitializeComponent();
            WorkerCmb.SelectedValuePath = "Id";
            WorkerCmb.DisplayMemberPath = "Name";
            WorkerCmb.ItemsSource = App.context.Worker.ToList();

            MakerCmb.SelectedValuePath = "Id";
            MakerCmb.DisplayMemberPath = "Name";
            MakerCmb.ItemsSource = App.context.Manufactura.ToList();

            MaterialCmb.SelectedValuePath = "Id";
            MaterialCmb.DisplayMemberPath = "Name";
            MaterialCmb.ItemsSource = App.context.Material.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(string.IsNullOrEmpty(DateDp.Text))
            {
                mes +="Введите дату\n";
            }
            if(string.IsNullOrEmpty(WorkerCmb.Text))
            {
                mes += "Выберите сотрудника\n";
            }
            if(string.IsNullOrEmpty(MakerCmb.Text))
            {
                mes += "Выберите производителя\n";
            }
            if(string.IsNullOrEmpty(MaterialCmb.Text))
            {
                mes += "Выберите материал\n";
            }
            if (string.IsNullOrEmpty(PriceTb.Text))
            {
                mes += "Введите цену\n";
            }
            if (string.IsNullOrEmpty(CountTb.Text))
            {
                mes += "Введите количество\n";
            }
            if( mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Accounting acc = new Accounting()
            {
                DateSpoil = (DateTime)DateDp.SelectedDate,
                Worker = WorkerCmb.SelectedItem as Worker,
                Material = MaterialCmb.SelectedItem as Material,
                Price = Convert.ToDecimal(PriceTb.Text),
                Quantity = Convert.ToInt32(CountTb.Text)
            };

            App.context.Accounting.Add(acc);
            App.context.SaveChanges();
            MessageBox.Show("Запись успешно добавлена");
            DateDp.Text = "";
            WorkerCmb.Text = "";
            MakerCmb.Text = "";
            MaterialCmb.Text = "";
            PriceTb.Text = "";
            CountTb.Text = "";
        }

        private void MakerCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedMaker = Convert.ToInt32(MakerCmb.SelectedValue);
            MaterialCmb.ItemsSource = App.context.Material.Where(x => x.ManufacturaId == SelectedMaker).ToList();
        }
    }
}
