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

namespace Loppupruju
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillcombobx();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {


        }

        public void fillcombobx()
        {
            SqlConnection con = new SqlConnection("Data Source=Juho-PC;Initial Catalog=Northwind;Integrated Security=True");
            string sql = "Select*from Order Details";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string sname = myreader.GetString(1);
                    comboBox1.Items.Add(sname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Juho-PC;Initial Catalog=Northwind;Integrated Security=True");
            string sql = "Select*from Order Details";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string ProductID = myreader.GetInt32(0).ToString();
                    string UnitPrice = myreader.GetString(1);
                    string Quantity = myreader.GetString(2);
                    string Discount = myreader.GetString(3);
                    ProductID = ProductID;
                    UnitPrice = UnitPrice;
                    Quantity = Quantity;
                    Discount = Discount;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
