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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Вы не ввели логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrEmpty(PasswrodPb.Password))
            {
                MessageBoxClass.ErrorMessageBox("Вы не ввели пароль");
                PasswrodPb.Focus();
            }
            else
            {
                var user = DBEntities.GetContext().User.FirstOrDefault(u => u.LoginUser == LoginTb.Text);

                if(user == null)
                {
                    MessageBoxClass.ErrorMessageBox("Введен не правильный логин");
                    LoginTb.Focus();
                }
                else if(user.PasswordUser!=PasswrodPb.Password)
                {
                    MessageBoxClass.ErrorMessageBox("Введен не правильный пароль");
                    PasswrodPb.Focus();
                }
                else
                {
                    switch(user.IdRole)
                    {
                        case 1:
                            WindowFolder.MenuStaffWindow menuStaffWindow = new MenuStaffWindow();
                            menuStaffWindow.ShowDialog();
                            break;

                        case 2:
                            MessageBoxClass.InfoMessageBox("Юзер");
                            break;
                    }
                }
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowFolder.RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();

        }
    }
}
