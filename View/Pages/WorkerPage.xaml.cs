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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrEmpty(WorkerTb.Text))
            {
                mes += "Введите имя сотрудника!";
            }

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Worker worker = new Worker()
            {
                Name = WorkerTb.Text
            };

            App.context.Worker.Add(worker);
            App.context.SaveChanges();
            MessageBox.Show("Запись успешно добавлена");
            WorkerTb.Clear();

        }
    }
}
