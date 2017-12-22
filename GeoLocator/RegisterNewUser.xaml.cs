using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using IBllForUi;

namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for RegisterNewUser.xaml
    /// </summary>
    public partial class RegisterNewUser : Window
    {
        public RegisterNewUser()
        {
            InitializeComponent();
            bll = new BllForUi();
        }

        IBll bll;
        public string LoginName { get; set; }

        private void OK_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Login_field.Text.Length == 0 || Password_field.Password.Length == 0 || City_combo.Text.Length == 0 || Street_field.Text.Length == 0
                || Number_field.Text.Length == 0)
            {
                MessageBox.Show("Wrong data.");
            }
            else if (Password_field.Password == ConfirmPassword_field.Password)
            {
                if (!bll.IsSuchUserNameInDB(Login_field.Text))
                {
                    LoginName = Login_field.Text;
                    bll.AddNewUser(LoginName, Password_field.Password, City_combo.Text, Street_field.Text, Number_field.Text, "user");
                    MessageBox.Show("New login was added.");
                }
                else
                {
                    MessageBox.Show("Sorry, but such login has been added earlier. Choose other.");
                }

            }
            else
            {
                MessageBox.Show("Different Passwords");
            }
        }
    }
}
