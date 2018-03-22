using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Layout.Classes
{
    class Collections
    {
        public class ArrayList
        {
            #region Declarations
            List<string> theStringList = new List<string>();
            #endregion

            public ArrayList(List<string> firstRowString)
            {
                foreach (string str in firstRowString)
                {
                    if (str != string.Empty)
                    {
                        theStringList.Add(str);
                    }

                }

            }

            public int CountListCapacity()
            {
                return theStringList.Count;
            }

        }

    }
}
