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

namespace Layout.Functions
{
    /// <summary>
    /// Interaction logic for ChangePassDialog.xaml
    /// </summary>
    public partial class ChangePassDialog : Window
    {

        Functions.ChangePassword changePass = new Functions.ChangePassword();

        public ChangePassDialog()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if(changePass.CheckOldPassword(oldPassword.Password))
            {
                if(changePass.ValidateNewPasswords(newPassword.Password, confirm.Password))
                {
                    if (confirm.Password != string.Empty)
                    {
                        if (changePass.ChangeThePassword(confirm.Password))
                        {
                            this.DialogResult = true;
                        }
                        else
                        {
                            MessageBox.Show("Didnt work!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The password obviously has to contain something..");
                    }
                }
                else
                {
                    MessageBox.Show("The new passwords you provided did not match");
                }
            }
            else
            {
                MessageBox.Show("The old password was not correct");
            }
        }
    }
}
