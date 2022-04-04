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
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {

        Staffs staffs = new Staffs();
        public AddStaffWindow()
        {
            InitializeComponent();
            DataContext = staffs;

        }

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            var staffsAdd = new Staffs()
            {
                LastNameStaffs = LastNameStaffsTb.Text,
                FirstNameStaffs = FirstNameStaffsTb.Text,
                MiddleNameStaffs =MiddleNameStaffsTb.Text,
                NumberPhoneStaffs = NumberPhoneStaffsTb.Text,
                EmailStaffs = EmailStaffsTb.Text,
                DateOfBirthStaffs = DateTime .Parse(DateOfBirthStaffsDp.Text),
            };

            DBEntities.GetContext().Staffs.Add(staffsAdd);
            DBEntities.GetContext().SaveChanges();
            MessageBoxClass.InfoMessageBox("Успешно");
        }
    }
}
