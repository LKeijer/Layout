using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Layout.Functions
{
    
    public static class UpdateWindow
    {
        #region Opening / Closing the windows logic

        /// <summary>
        /// This needs improvement badly
        /// </summary>
        /// <param name="windowclose"></param>
        public static void CloseThisWindow(object windowclose)  //Gets the window that calls this method as object.
        {
            string whatWindow = windowclose.GetType().ToString(); //Gets the string of the type of the object that was sent by calling the method.
            string mainMenuWindow = "Layout.Windows.MainMenu";
            string loginWindow =  "Layout.MainWindow";
            string collectionWindow = "Layout.Windows.CollectionWindow";
            string addInfoWindow = "DialogWindows.AddInfo";

            if(whatWindow == mainMenuWindow)    //Checks if its the MainMenu that called the method.
            {
                Windows.MainMenu mainMenu = (Windows.MainMenu)windowclose; //Cast the object sent with the method call into the MainMenu object so i can call the visibility property.
                mainMenu.Visibility = Visibility.Collapsed;
            }
            else if(whatWindow == loginWindow)  //Checks if its the LoginWindow that called the method.
            {
                MainWindow main = (MainWindow)windowclose;
                main.Visibility = Visibility.Collapsed;
            }
            else if(whatWindow == collectionWindow)
            {
                Windows.CollectionWindow collWindow = (Windows.CollectionWindow)windowclose;
                collWindow.Visibility = Visibility.Collapsed;
            }
            else if(whatWindow == addInfoWindow)
            {
                DialogWindows.AddInfo addWindow = (DialogWindows.AddInfo)windowclose;
                addWindow.Visibility = Visibility.Collapsed;
            }

        }

        public static void OpenMainMenuWindow()
        {
            Windows.MainMenu mainMenu = new Windows.MainMenu();
            mainMenu.Visibility = Visibility.Visible;
        }

        public static void OpenCollectionsWindow()
        {
            Windows.CollectionWindow collectionWindow = new Windows.CollectionWindow();
            collectionWindow.Visibility = Visibility.Visible;
        }
        #endregion

    }

    class ChangePassword
    {
        #region Password functions

        DataBaseFront.FakeDBEntities db = new DataBaseFront.FakeDBEntities();

        public bool ChangePass()
        {


            return true;
        }

        private void Tester()
        {
            
        }

        public bool CheckOldPassword(string pass)
        {

            var leOldPassword = db.Users.FirstOrDefault(p => p.Password == pass);
            if(leOldPassword != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateNewPasswords(string pass1, string pass2)
        {
            if(string.Compare(pass1, pass2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeThePassword(string pass)
        {
            using (DataBaseFront.FakeDBEntities db = new DataBaseFront.FakeDBEntities())
            {
                var currentUser = db.Users.FirstOrDefault(u => u.Username == Classes.Session.sessionUserName);
                try
                {
                    currentUser.Password = pass;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }



        }

        #endregion

    }



}
