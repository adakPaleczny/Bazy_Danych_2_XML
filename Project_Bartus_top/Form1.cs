using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Xml;
using System.Xml.Schema;

namespace Project_Bartus_top
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private SqlConnection connectToDatabase()
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer; INTEGRATED SECURITY=SSPI; Server = (local); TrustServerCertificate=True;";
            SqlConnection connection = new SqlConnection(sqlconnection);
            return connection;
        }

        private void disconnectToDatabase(SqlConnection con)
        {
            con.Close();
        }

        private string getTableName()
        {
            string t = textBox1.Text;
            return t;
        }

        private string getElementName()
        {
            return textBox2.Text;
        }

        private string getValue()
        {
            return textBox3.Text;
        }

        private int getNumber()
        {
            int num = -1;
            Int32.TryParse(textBox4.Text, out num);
            return num;
        }

        private void writeToDataStreamer(string text)
        {
            data_streamer.Clear();
            data_streamer.Text = text;
        }

        private void Delete_element_Click(object sender, EventArgs e)
        {
            writeToDataStreamer(getElementName());        
        }
    }
}
