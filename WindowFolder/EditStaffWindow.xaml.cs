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
using EF041ISP.ClassFolder;
using EF041ISP.DataFolder;
namespace EF041ISP.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        Staffs staffs = new Staffs();
        public EditStaffWindow(Staffs  staffs)
        {
            InitializeComponent();
            DataContext = staffs;
        }

        private void SaveStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            staffs = DBEntities.GetContext().Staffs.FirstOrDefault(s => s.IdStaffs == VariableClass.IdStaffs);
            staffs.LastNameStaffs = LastNameStaffsTb.Text;
            staffs.FirstNameStaffs = FirstNameStaffsTb.Text;
            staffs.MiddleNameStaffs = MiddleNameStaffsTb.Text;
            staffs.NumberPhoneStaffs = NumberPhoneStaffsTb.Text;
            staffs.EmailStaffs = EmailStaffsTb.Text;
            staffs.DateOfBirthStaffs = DateTime.Parse(DateOfBirthStaffsDp.Text);

            DBEntities.GetContext().SaveChanges();
            MessageBoxClass.InfoMessageBox("Успешно");
        }
    }
}
