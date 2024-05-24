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
            connection.Open();
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

        private bool checkIfTableExist(string nameTable)
        {
            SqlConnection con = connectToDatabase();
            string tableName = getTableName();
            string checkTable = "SELECT COUNT(*) AS 'Number' FROM XmlData WHERE Name='" + tableName + "'";
            SqlCommand command = new SqlCommand(checkTable, con);
            SqlDataReader datareader = command.ExecuteReader();

            datareader.Read();
            return !(datareader["Number"].ToString() != "1");
            
        }

        private void Delete_element_Click(object sender, EventArgs e)
        {
            writeToDataStreamer(getElementName());        
        }

        private void Wypisz_Click(object sender, EventArgs e)
        {
            SqlConnection con = connectToDatabase();
            try
            {
                if (!checkIfTableExist(getTableName()))
                {
                    throw new Exception("Table doesn't exist in database");
                }

                // Execute stored procedure to get XML content
                using (SqlCommand command2 = new SqlCommand("GetXmlTable", con))
                {
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@TableName", getTableName());

                    using (SqlDataReader datareader2 = command2.ExecuteReader())
                    {
                        while (datareader2.Read())
                        {
                            writeToDataStreamer(datareader2["XmlContent"].ToString());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                writeToDataStreamer(ex.Message.ToString());
            }
            finally
            {
                disconnectToDatabase(con);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Save_to_file_Click(object sender, EventArgs e)
        {
            // Spytać Bartka jak działa ta funkcja do formatowania i zapisać z funkcji Wypisz_Click()
        }

        private void Find_atributes_Click(object sender, EventArgs e)
        {
            SqlConnection con = connectToDatabase();
            try
            {
                if (!checkIfTableExist(getTableName()))
                {
                    throw new Exception("Table doesn't exist in database");
                }

                // Execute stored procedure to get XML content
                using (SqlCommand command2 = new SqlCommand("FetchXmlData", con))
                {
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@Element", getTableName());

                    using (SqlDataReader datareader2 = command2.ExecuteReader())
                    {
                        data_streamer.Clear();
                        while (datareader2.Read())
                        {
                            data_streamer.Text += (datareader2["ElementName"].ToString()) + "\n";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                writeToDataStreamer(ex.Message.ToString());
            }
            finally
            {
                disconnectToDatabase(con);
            }
        }

        private void Delete_table_Click(object sender, EventArgs e)
        {
            SqlConnection con = connectToDatabase();
            try
            {
                if (!checkIfTableExist(getTableName()))
                {
                    throw new Exception("Table doesn't exist in database");
                }

                // Execute stored procedure to get XML content
                using (SqlCommand command2 = new SqlCommand("Delete_XML", con))
                {
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@Name", getTableName());

                    int rowsAffected = command2.ExecuteNonQuery();
                    writeToDataStreamer($"Rows affected: {rowsAffected}");

                }
            }
            catch (Exception ex)
            {
                writeToDataStreamer(ex.Message.ToString());
            }
            finally
            {
                disconnectToDatabase(con);
            }
        }

        private void Add_file_Click(object sender, EventArgs e)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + getTableName() + ".xml";
            XmlReader reader;
            try
            {
                reader = XmlReader.Create(path);
            }
            catch(Exception ex)
            {
                writeToDataStreamer("File doesn't exist");
                return;
            }
            
            while (reader.Read())
            {
                if (getTableName() != reader.Name && reader.NodeType == XmlNodeType.EndElement && reader.Depth == 1)
                {
                    writeToDataStreamer("Wrong xml file");
                    return;
                }
            }

            SqlConnection con = connectToDatabase();
            try
            {
                // Execute stored procedure to get XML content
                using (SqlCommand command2 = new SqlCommand("AddXMLToDB", con))
                {
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@FileName", getTableName() + ".xml");
                    command2.Parameters.AddWithValue("@DirectoryPath", System.AppDomain.CurrentDomain.BaseDirectory + "\\");

                    int rowsAffected = command2.ExecuteNonQuery();
                    writeToDataStreamer("Element added");

                }
            }
            catch (Exception ex)
            {
                writeToDataStreamer(ex.Message.ToString());
            }
            finally
            {
                disconnectToDatabase(con);
            }

        }
    }
}
