using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Layout.DataBaseFront
{
    class DataBaseFront
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }

        Classes.Session session = new Classes.Session();

        public DataBaseFront()
        {
            
        }


        //public bool RegisterCheckedSQL(string username, string password)
        //{
        //    //var connection = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        //    //SqlConnection regConnection = new SqlConnection(connection); //<--- still have to add the connectionstring here.
        //    //SqlCommand regCommand = new SqlCommand("INSERT INTO Users (Username, Password) VALUES(@user, @pass)", regConnection);
        //    //regCommand.Parameters.Add("@user", SqlDbType.NVarChar).Value = username;
        //    //regCommand.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password;
        //    //try
        //    //{
        //    //    regConnection.Open();
        //    //    regCommand.ExecuteNonQuery();
        //    //    return true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.ToString());
        //    //    return false;
        //    //}
        //    //finally
        //    //{
        //    //    regConnection.Close();
        //    //}

        //}

        public bool RegisterUncheckedEntityFramework(string username, string password)
        {
            using (FakeDBEntities fakeDBClass = new FakeDBEntities()) //Using statement automatically calls the dispose, making sure no clutter remains in memory.
                                                                      //A EDM is created and treats the Database as an class, therefore interaction is the same as dev. created classes as shown below.
            {
                User regUser = new User();
                regUser.Username = username;
                regUser.Password = password;
                fakeDBClass.Users.Add(regUser);
                try
                {
                    fakeDBClass.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

                }
        }

        public bool ValidateLogin(string username, string password)
        {
            using (FakeDBEntities fakeDB = new FakeDBEntities())
            {
                try
                {
                    User currentUser = fakeDB.Users.FirstOrDefault(r => r.Username == username);
                    if (string.Compare(password, currentUser.Password) == 0)
                    {
                        RememberWhoLoggedIn(currentUser.Id, currentUser.Username);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("The password didn't match");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Username not reconized");
                    return false;
                }

                //    User currentUser = fakeDB.Users.FirstOrDefault(r => r.Username == username);
                //if(string.Compare(password, currentUser.Password) == 0)
                //{
                //    RememberWhoLoggedIn(currentUser.Id, currentUser.Username);

                //    //Classes.Session.sessionUserID = currentUser.Id;             //This saves the user id and username of the person logging in for later stages.
                //    //Classes.Session.sessionUserName = currentUser.Username;

                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }

        }

        public void RememberWhoLoggedIn(int id, string userName)
        {
            Classes.Session.sessionUserID = id;
            Classes.Session.sessionUserName = userName;
        }

        public bool ChangePassword()
        {

            return true;
        }

    }
}
