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
using Microsoft.EntityFrameworkCore;
using PharmaceuticalWarehousing.Models;
using PharmaceuticalWarehousing.Utilities;

namespace PharmaceuticalWarehousing.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private readonly PharmaceuticalWarehousingDbContext dbContext;
        public List<UserType> UserTypes { get; set; }
        public AccessRight AccessRight { get; set; }
        public List<AccessRight> AccessRights { get; set; } = new List<AccessRight>();

        public AuthWindow()
        {
            InitializeComponent();
            dbContext = new PharmaceuticalWarehousingDbContext();
            this.DataContext = this;
        }

        private AccessRight AddAccessRight(bool v1, bool v2, bool v3, bool v4, FormType formType)
        {
            AccessRight = new AccessRight();
            AccessRight.Read = v1;
            AccessRight.Write = v2;
            AccessRight.Edit = v3;
            AccessRight.Delete = v4;

            AccessRight.Form = formType;
            return AccessRight;
        }

        private void RegistrButton_Click(object sender, RoutedEventArgs e)
        {
            var Email = RegisterEmailTextBox.Text;

            if (!dbContext.Users.Any(x => x.Email == Email))
            {
                if (RegisterPasswordConfirmTextBox.Password == RegisterPasswordTextBox.Password)
                {
                    var PasswordHash = PasswordEncrypter.GetHash(RegisterPasswordTextBox.Password);
                    User user = new User();
                    user.Email = Email;
                    user.Password = PasswordHash;
                    user.UserType = UserType.user;


                    foreach (var form in Enum.GetValues(typeof(FormType)).Cast<FormType>())
                    {
                        AccessRights.Add(AddAccessRight(false, false, false, false, form));
                    }
                    

                    user.AccessRights = AccessRights;
                    dbContext.Add(user);
                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (DbUpdateException exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    var mainWindow = new MainWindow(dbContext, user);
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Такой емаил уже есть");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var Email = LoginEmailTextBox.Text;
            var PasswordHash = PasswordEncrypter.GetHash(LoginPasswordTextBox.Password);
            User? user = dbContext.Users
                .Include(x => x.AccessRights)
                .FirstOrDefault(u => u.Email == Email && u.Password == PasswordHash);
            if (user != null)
            {
                var mainWindow = new MainWindow(dbContext, user);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}