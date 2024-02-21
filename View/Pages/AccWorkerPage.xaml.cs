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
    /// Логика взаимодействия для AccWorkerPage.xaml
    /// </summary>
    public partial class AccWorkerPage : Page
    {
        public AccWorkerPage()
        {
            InitializeComponent();
            WorkerCmb.SelectedValuePath = "Id";
            WorkerCmb.DisplayMemberPath = "Name";
            WorkerCmb.ItemsSource = App.context.Worker.ToList();

            AccDg.ItemsSource = App.context.Accounting.ToList();
        }

        private void AccDg_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(string.IsNullOrEmpty(StartDp.Text))
            {
                mes += "Выберите начало периода\n";
            }
            if(string.IsNullOrEmpty(FinishDp.Text))
            {
                mes += "Выберите конец периода\n";

            }
            if(string.IsNullOrEmpty(WorkerCmb.Text))
            {
                mes += "Выберите сотрудника\n";
            }
            if(mes !="")
            {
                MessageBox.Show(mes);
                WorkerCmb.Text = "";
                return;
            }
            var aid = WorkerCmb.SelectedIndex + 1;
            var a = (DateTime)StartDp.SelectedDate;
            var b = (DateTime)FinishDp.SelectedDate;
            AccDg.ItemsSource = App.context.Accounting.Where(x => x.WorkerId == aid && x.DateSpoil >= a && x.DateSpoil <= b).ToList();
            var count = App.context.Accounting.Where(x => x.WorkerId == aid && x.DateSpoil >= a && x.DateSpoil <= b).Count();
            CountTb.Text = Convert.ToString(count);
            var sum = App.context.Accounting.Where(x => x.WorkerId == aid && x.DateSpoil >= a && x.DateSpoil <= b).Select(x => x.Amount).Sum();
            SumTb.Text = Convert.ToString(sum);
        }
    }
}
