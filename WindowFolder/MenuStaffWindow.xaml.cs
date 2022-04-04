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
using System.Windows.Shapes;
using EF041ISP.DataFolder;
using EF041ISP.ClassFolder;

namespace EF041ISP.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuStaffWindow.xaml
    /// </summary>
    public partial class MenuStaffWindow : Window
    {
        public MenuStaffWindow()
        {
            InitializeComponent();

            DgStaff.ItemsSource = DBEntities.GetContext().Staffs
                .ToList().OrderBy(u=>u.LastNameStaffs);
        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.AddStaffWindow addStaffWindow = new AddStaffWindow();
            addStaffWindow.ShowDialog();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                DgStaff.ItemsSource = DBEntities.GetContext().Staffs.Where
                    (s => s.LastNameStaffs.StartsWith(SearchTb.Text)).ToList();
                if (DgStaff.Items.Count <= 0)
                    MessageBoxClass.ErrorMessageBox("Сотрудник не добавлен в систему");

            }
            catch (Exception ex)
            {
                MessageBoxClass.ErrorMessageBox(ex);
            }
        }

        private void DgStaff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgStaff.SelectedItem == null)
            {
                MessageBoxClass.ErrorMessageBox("Не выбран сотрудник для редактирования");
            }
            else
            {
                Staffs staffs = DgStaff.SelectedItem as Staffs;
                VariableClass.IdStaffs = staffs.IdStaffs;
                new EditStaffWindow(DgStaff.SelectedItem as Staffs).ShowDialog();
                DgStaff.ItemsSource = DBEntities.GetContext().Staffs
               .ToList().OrderBy(u => u.LastNameStaffs);

            }
        }
    }
}
