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
using System.Data.SqlClient;

namespace MYRTEX
{

    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
         

        public Employees()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Menu());
        }

        private void Btn_Create_Click(object sender, RoutedEventArgs e)
        { 
            Manager.MainFrame.Navigate(new EmployeesAddPage(null));
            
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

            var EmployeesDelete = DGridEmployees.SelectedItems.Cast<Employee>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить элемент - {EmployeesDelete.Count()} ?", "Внимание !",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    MYRTEXEntities.GetEmployees().Employees.RemoveRange(EmployeesDelete);
                    MYRTEXEntities.GetEmployees().SaveChanges();
                    MessageBox.Show("Данные удалены !");

                    DGridEmployees.ItemsSource = MYRTEXEntities.GetEmployees().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
          
        }

        private void DGridEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EmployeesAddPage((sender as Button).DataContext as Employee));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MYRTEXEntities.GetEmployees().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridEmployees.ItemsSource = MYRTEXEntities.GetEmployees().Employees.ToList();
            }
        }
    }
}
