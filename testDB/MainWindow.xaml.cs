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
using MySql.Data.MySqlClient;

namespace testDB
{

    public class data
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public partial class MainWindow : Window
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=zirka3371;database=test;port=3306");
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT login, pass FROM users", conn);

                conn.Open();

                MySqlDataReader read = cmd.ExecuteReader();

                while(read.Read())
                {
                    dataGrid1.Items.Add(new data { Login = read[0].ToString(), Password = read[1].ToString() });
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка соединения с базой данных. \n\n\n\n\nПодробнее:\n" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
