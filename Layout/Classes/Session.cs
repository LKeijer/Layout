using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout.Classes
{
    class Session
    {
        public static string sessionUserName;
        public static int sessionUserID;
        public static string userClass;

        public static void ClearSession()
        {
            //this.ClearSession(); what does this method do?
            sessionUserName = string.Empty;
            sessionUserID = 0;
            userClass = string.Empty;
        }
    }
}
