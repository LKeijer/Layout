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
    /// Interaction logic for CollectionWindow.xaml
    /// </summary>
    public partial class CollectionWindow : Window
    {
        public CollectionWindow()
        {
            InitializeComponent();
            //Classes.Collections collClass = new Classes.Collections();
        }

        private void SendIntoListArrayBtn_Click(object sender, RoutedEventArgs e)
        {
            string stringBox1 = TextBox1.Text;
            string stringBox2 = TextBox2.Text;
            string stringBox3 = TextBox3.Text;
            string stringBox4 = TextBox4.Text;
            string stringBox5 = TextBox5.Text;

            List<string> convertedIntoList = new List<string> { stringBox1, stringBox2, stringBox3, stringBox4, stringBox5 };
            Classes.Collections.ArrayList sendingList = new Classes.Collections.ArrayList(convertedIntoList);

            
        }

        private void GetInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
