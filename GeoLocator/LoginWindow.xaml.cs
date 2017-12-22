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
using IBllForUi;

namespace GeoLocator
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            bll = new BllForUi();
        }

        IBll bll;
        public bool IsSuccsesfullLogin { get; set; }
        public string LoginStatusName { get; set; }
        public string LoginName { get; set; }

        private void LoginWindow_btn_OK_Click(object sender, RoutedEventArgs e)
        {
            //DAL dal = new DAL();
            if (bll.IsSuchUserNameInDB(Login_field.Text))
            {
                var data = Encoding.ASCII.GetBytes(Password_field.Password);
                if (bll.IsValidPassword(Login_field.Text, Password_field.Password))
                {
                    //login = bll.GetLoginWithName(Login_field.Text);
                    IsSuccsesfullLogin = true;
                    LoginName = Login_field.Text;
                    LoginStatusName = bll.Get(LoginName);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong login or password");
                    IsSuccsesfullLogin = false;
                }
            }
            else
            {
                MessageBox.Show("Wrong login or password");
                IsSuccsesfullLogin = false;
            }
        }

        private void LoginWindow_btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
