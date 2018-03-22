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

namespace Layout.Windows
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            UpdateUI();
        }

        #region Methods
        public void UpdateUI()
        {
            
            //NameContentLbl.Content = Classes.Session.sessionUserName;
            
        }
        #endregion

        #region Event Handlers
        private void TestBtn_Click(object sender, RoutedEventArgs e)
        {
            TestClass test = new TestClass();
            string completeUserInfo = string.Format("The name of the user is {0}, the ID of the user is {1}", Classes.Session.sessionUserName, Classes.Session.sessionUserID.ToString());
            MessageBox.Show(completeUserInfo);

        }

        private void AddInfoBtn_Click(object sender, RoutedEventArgs e) //to be tested
        {
            this.Visibility = Visibility.Collapsed;
            DialogWindows.AddInfo AddDialog = new DialogWindows.AddInfo();
            AddDialog.Visibility = Visibility.Visible;
        }



        private void ChangePassBtn_Click(object sender, RoutedEventArgs e)
        {
            Functions.ChangePassDialog changeDialog = new Functions.ChangePassDialog();

            if(changeDialog.ShowDialog().Value == true)
            {
                MessageBox.Show("Password has been changed!");
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult logoutResult = MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(logoutResult == MessageBoxResult.Yes)
            {
                Classes.Session.ClearSession();
                MainWindow lw = new MainWindow();
                
                this.Visibility = Visibility.Collapsed;
                lw.Visibility = Visibility.Visible;
            }
            else
            {
                return;
            }
        }

        private void CollectionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Layout.Functions.UpdateWindow.CloseThisWindow(this);
            Layout.Functions.UpdateWindow.OpenCollectionsWindow();
        }
        #endregion
    }
}
