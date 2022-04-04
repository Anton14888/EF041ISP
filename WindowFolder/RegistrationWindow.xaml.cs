using EF041ISP.ClassFolder;
using EF041ISP.DataFolder;
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



namespace EF041ISP.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

            string zagl = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjklzxcvbnm";
            string cisl = "1234567890";
            string znaki = "!@#$%^&*()_-";


            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Вы не ввели логин");
                LoginTb.Focus();
            }
            else if (DBEntities.GetContext ().User.FirstOrDefault(u=>u.LoginUser == LoginTb.Text) !=null)
            {
                MessageBoxClass.ErrorMessageBox("Пользователь с таким логином существует");
                LoginTb.Focus();
            }
            else if (string.IsNullOrEmpty(PasswordTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Вы не ввели пароль");
                PasswordTb.Focus();
            }
            else if (string.IsNullOrEmpty(PasswordRepitTb.Text))
            {
                MessageBoxClass.ErrorMessageBox("Вы не ввели повторный пароль");
                PasswordRepitTb.Focus();
            }
            else if (zagl.IndexOfAny(PasswordTb.Text.ToCharArray()) == -1)
            {
                MessageBoxClass.InfoMessageBox("Пароль должен содержать заглавнные буквы");
                PasswordTb.Focus();
                PasswordTb.Clear();
                PasswordRepitTb.Clear();
            }
            else if (mal.IndexOfAny(PasswordTb.Text.ToCharArray()) == -1)
            {
                MessageBoxClass.InfoMessageBox("Пароль должен содержать прописные буквы");
                PasswordTb.Focus();
                PasswordTb.Clear();
                PasswordRepitTb.Clear();
            }
            else if (cisl.IndexOfAny(PasswordTb.Text.ToCharArray()) == -1)
            {
                MessageBoxClass.InfoMessageBox("Пароль должен содержать цифру");
                PasswordTb.Focus();
                PasswordTb.Clear();
                PasswordRepitTb.Clear();
            }
            else if (znaki.IndexOfAny(PasswordTb.Text.ToCharArray()) == -1)
            {
                MessageBoxClass.InfoMessageBox("Пароль должен содержать " +
                    "один из след. символов: !@#$%^&*()_-");
                PasswordTb.Focus();
                PasswordTb.Clear();
                PasswordRepitTb.Clear();
            }
            else if (PasswordRepitTb.Text != PasswordTb.Text)
            {
                MessageBoxClass.ErrorMessageBox("Пароли не совпадают");
                PasswordTb.Focus();
                PasswordRepitTb.Clear();
            }
            else
            {
                try
                {
                    DBEntities.GetContext().User.Add(new User()
                    {
                        LoginUser = LoginTb.Text,
                        PasswordUser =PasswordTb.Text ,
                        IdRole =2,
                    });
                    DBEntities.GetContext().SaveChanges();
                    MessageBoxClass.InfoMessageBox("Вы успершно зарегестрированны"); 
                }
                catch (Exception ex)
                {
                    MessageBoxClass.ErrorMessageBox(ex);
                }
            }

        }
    }
}
