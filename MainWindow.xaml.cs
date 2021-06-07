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
using System.Data.SqlClient;

namespace wpfapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int accountype = 0; // 0 = normal: 1 = admin: 2 = super

        public MainWindow()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e) // event handler for button - insert into database
        {
            if (accountype == 1 || accountype == 2)
            {
            }
            else
            {
                MessageBox.Show("You need to be an admin or superuser to do that");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) // event handler for textbox
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // event handler for button - deletes from the sql database
        {

            if (accountype == 1)
            {
                String query = "DELETE FROM fødselsrate_2017 WHERE ID = '" + Convert.ToInt32(combobox.SelectedItem.ToString()) + "'";

            } else
            {
                MessageBox.Show("You need to be an admin to do that");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // event handler for button - update sql database
        {

            if (accountype == 1 || accountype == 2)
            {
                String query = "UPDATE fødselsrate_2017 SET rang = '" + boxedit.Text + "' " + "WHERE ID = '" + Convert.ToInt32(combobox.SelectedItem.ToString()) + "'";

            }
            else
            {
                MessageBox.Show("You need to be an admin or superuser to do that");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // event handler for button - authenticate login
        {
        }

        private void Button_Click_4(object sender, RoutedEventArgs e) // button handler for button - display data from sql database
        {
        }

        private void Button_Click_5(object sender, RoutedEventArgs e) // button handler for opret bruger fane - opretter bruger i databasen
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e) // button handler for nulstil kodeord fane - nulstiller kodeord for den valgte brugernavn
        {
;
        }
    }
}
