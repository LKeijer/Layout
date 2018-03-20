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

namespace Layout.DialogWindows
{
    /// <summary>
    /// Interaction logic for AddInfo.xaml
    /// </summary>
    public partial class AddInfo : Window
    {
        DataBaseFront.FakeDBEntities db = new DataBaseFront.FakeDBEntities();

        public AddInfo()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userEmail.Text != string.Empty)
            {
                var currentUser = db.Users.FirstOrDefault(u => u.Username == Classes.Session.sessionUserName);
                currentUser.Email = userEmail.Text;

                try
                {
                    db.SaveChanges();

                    this.Visibility = Visibility.Collapsed;
                    Windows.MainMenu main = new Windows.MainMenu();
                    main.Visibility = Visibility.Visible;
                }
                catch
                {
                    MessageBox.Show("Error updating the email");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid email adress");
            }
            if(BasicRadioBtn.IsChecked == true || AdvancedRadioBtn.IsChecked == true || RadioBtn.IsChecked == true)
            {

            }
            else
            {
                MessageBox.Show("Please select the kind of user you wish to be");
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
