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
 
namespace Layout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DataBaseFront.DataBaseFront db = new DataBaseFront.DataBaseFront();

        #region Event handlers
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(db.ValidateLogin(this.UserNameTextBox.Text, this.UserPassTextBox.Password)) //Calls the method ValidateLogin which returns a bool value, the username and password are sent as parameters.
            {
                Windows.MainMenu main = new Windows.MainMenu();
                this.Visibility = Visibility.Collapsed;
                main.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Login Failed, try again!");
            }
        }

        private void LoginUserInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Click!");
            
        }

        private void LoginUserPassInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Pass Click!");
        }

        private void RegisterBtn_CLick(object sender, MouseButtonEventArgs e)
        {
            if(NoDataBaseCheckBox.IsChecked == true)
            {
                throw new ArgumentException();
            }
            else
            {
                if(db.RegisterUncheckedEntityFramework(UserNameTextBox.Text, UserPassTextBox.Password))
                {
                    MessageBox.Show("Successful! Please continue to log in");
                }
                else
                {
                    MessageBox.Show("Nope, try again");
                }
            }

        }
        #endregion
    }
}
