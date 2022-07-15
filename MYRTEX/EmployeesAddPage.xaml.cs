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

namespace MYRTEX
{
    /// <summary>
    /// Логика взаимодействия для EmployeesAddPage.xaml
    /// </summary>
    public partial class EmployeesAddPage : Page
    {
        private Employee _currentAddEmployees = null;

        public EmployeesAddPage(Employee SelectedEmployees)
        {
            InitializeComponent();

            if (SelectedEmployees != null)
                _currentAddEmployees = SelectedEmployees;

            DataContext = _currentAddEmployees;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_currentAddEmployees == null)
            {
                var addEmployee = new Employee
                {
                    Department = TBoxDepartment.Text,
                    FullName = TBoxFullname.Text,
                    Birthdate = (DateTime)Birthdateooo.SelectedDate,
                    DateOfEmployment = (DateTime)DateOfEmployeesooo.SelectedDate,
                    Salary = int.Parse(TBoxSalary.Text),
                    Age = int.Parse(TBoxAge.Text),
                };
                App.Context.Employees.Add(addEmployee);
                App.Context.SaveChanges();
                MessageBox.Show("Данные сохранены !");

            }
        }

    }
}
