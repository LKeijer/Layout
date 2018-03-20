using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout.Functions
{
    class ChangePassword
    {
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
    }
}
