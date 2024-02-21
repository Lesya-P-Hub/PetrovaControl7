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
    /// Логика взаимодействия для AccPeriodPage.xaml
    /// </summary>
    public partial class AccPeriodPage : Page
    {
        public AccPeriodPage()
        {
            InitializeComponent();
            
        }

        private void AccDg_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrEmpty(StartDateDp.Text))
            {
                mes += "Выберите начальную дату\n";
            }

            if (string.IsNullOrEmpty(FinishDateDp.Text))
            {
                mes += "Выберите конечную дату\n";
            }

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            var a = (DateTime)StartDateDp.SelectedDate;
            var b = (DateTime)FinishDateDp.SelectedDate;

            var query = App.context.View_1
                .Where(x => x.DateSpoil >= a && x.DateSpoil <= b)
                .GroupBy(y => y.Name)
                .Select(g => new { Сотрудник = g.Key, Сумма = g.Sum(s => s.Amount) })
                .OrderBy(n => n.Сотрудник);
            AccDg.ItemsSource = query.ToList();
        }
    }
}
