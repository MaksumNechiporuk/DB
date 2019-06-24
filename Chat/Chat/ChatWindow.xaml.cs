using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Chat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
            string strConn = ConfigurationManager.ConnectionStrings["SomeeConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConn))
            {
                con.Open();
                string q = "SELECT Name From tblUsers";
                DataSet dataSet = new DataSet();
                SqlCommand cmd = new SqlCommand(q, con);
               SqlDataReader reader = cmd.ExecuteReader();
                int i = 1;
                while (reader.Read())
                {
                    string item;
                  item= (i.ToString());
                    item += ". ";

                    item += reader["Name"].ToString();                                       
                    i++;
                UserListView.Items.Add(item);
                }
                con.Close();
            }
        }
    }
}
