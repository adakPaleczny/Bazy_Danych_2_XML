using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;
using System.Reflection;

namespace Final_project_BD2
{
    class Program
    {
        static string database = "";
        static string table = "";
        static string method = "";
        static bool readValues = false;

        public static void executeGetQuery(string sqlconnection, string sqlcommand, List<string> names)
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                
                while (datareader.Read())
                {
                    for(int counter = 0; counter < names.Count; ++counter)
                    {
                        Console.Write($"{names[counter]}: {datareader[names[counter].ToString()]}\t");

                    }
                    Console.WriteLine();
                }
            }
            catch (SqlException ex)
            { Console.WriteLine(ex.Message); }
            finally
            { connection.Close(); }
        }
        public static void executeQuery(string sqlconnection, string sqlcommand)
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlcommand, connection);
                SqlDataReader datareader = command.ExecuteReader();
                Console.WriteLine("Operation Succeeded");
            }
            catch (SqlException ex)
            { Console.WriteLine(ex.Message); }
            finally
            { connection.Close(); }
        }
        public static void executeInsertQuery(List<KeyValuePair<string, string>> values)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;";
            if (database != "public")
                sqlconnection += "INITIAL CATALOG=" + database + "; ";
            sqlconnection += " INTEGRATED SECURITY=SSPI; Server = (local); TrustServerCertificate=True;";

            string sqlcommand = "INSERT INTO dbo." + table +" (";
            foreach(var v in values)
            {
                sqlcommand += v.Key + ", ";
            }
            sqlcommand = sqlcommand.Remove(sqlcommand.Length - 2);
            sqlcommand += ") values (";
            foreach (var v in values)
            {
                if (int.TryParse(v.Value, out int n))
                    sqlcommand += v.Value + ", ";
                else
                {
                    sqlcommand += "'" + v.Value + "', ";
                }
            }
            sqlcommand = sqlcommand.Remove(sqlcommand.Length - 2);
            sqlcommand += ");";
            //Console.WriteLine(sqlconnection);
            //Console.WriteLine(sqlcommand);
            executeQuery(sqlconnection, sqlcommand);
        }

        public static void executeDeleteQuery(List<KeyValuePair<string, string>> values)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;";
            if (database != "public")
                sqlconnection += "INITIAL CATALOG=" + database + "; ";
            sqlconnection += " INTEGRATED SECURITY=SSPI; Server = (local); TrustServerCertificate=True;";

            string sqlcommand = "DELETE FROM dbo." + table + " WHERE ";
            foreach (var v in values)
            {
                sqlcommand += v.Key + " = ";
                if (int.TryParse(v.Value, out int n))
                    sqlcommand += v.Value + " and ";
                else
                {
                    sqlcommand += "'" + v.Value + "' and ";
                }
            }
            sqlcommand = sqlcommand.Remove(sqlcommand.Length - 4);
            sqlcommand += ";";
            //Console.WriteLine(sqlconnection);
            //Console.WriteLine(sqlcommand);
            executeQuery(sqlconnection, sqlcommand);
        }

        public static void executeModifyQuery(List<KeyValuePair<string, string>> values)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;";
            if (database != "public")
                sqlconnection += "INITIAL CATALOG=" + database + "; ";
            sqlconnection += " INTEGRATED SECURITY=SSPI; Server = (local); TrustServerCertificate=True;";

            
        }

        public static void executeGetQuery(List<KeyValuePair<string, string>> values)
        {
            foreach(var v in values){
                Console.WriteLine($"{v.Key}");
            }
            List<string> list = new List<string>();
            string sqlconnection = @"DATA SOURCE=MSSQLServer;";
            if (database != "public")
                sqlconnection += "INITIAL CATALOG=" + database + "; ";
            sqlconnection += " INTEGRATED SECURITY=SSPI; Server = (local); TrustServerCertificate=True;";

            string sqlcommand = "SELECT " ;
            foreach (var v in values)
            {
                list.Add(v.Key);
                sqlcommand += v.Key + ", ";
            }
            sqlcommand = sqlcommand.Remove(sqlcommand.Length - 2);
            sqlcommand += " FROM dbo." + table + ";";
            //Console.WriteLine(sqlconnection);
            //Console.WriteLine(sqlcommand);
            executeGetQuery(sqlconnection, sqlcommand, list);
        }
        public static void executeFindQuery(List<KeyValuePair<string, string>> values)
        {
            List<string> list = new List<string>();
            string sqlconnection = @"DATA SOURCE=MSSQLServer;";
            if (database != "public")
                sqlconnection += "INITIAL CATALOG=" + database + "; ";
            sqlconnection += " INTEGRATED SECURITY=SSPI; Server = (local); TrustServerCertificate=True;";

            string sqlcommand = "SELECT * FROM dbo." + table + " WHERE ";
            foreach (var v in values)
            {
                list.Add(v.Key);
                sqlcommand += v.Key + " = ";
                if (int.TryParse(v.Value, out int n))
                    sqlcommand += v.Value + " and ";
                else
                {
                    sqlcommand += "'" + v.Value + "' and ";
                }
            }
            sqlcommand = sqlcommand.Remove(sqlcommand.Length - 4);
            sqlcommand += ";";
            //Console.WriteLine(sqlconnection);
            //Console.WriteLine(sqlcommand);
            executeGetQuery(sqlconnection, sqlcommand, list);
        }


        public static void checkBasedOnOperation(string operation, List<KeyValuePair<string, string>> values)
        {
            switch (operation)
            {
                case "add": { executeInsertQuery(values); break; }
                case "delete": { executeDeleteQuery(values); break; }
                case "modify": { executeModifyQuery(values); break; }
                case "get": { executeGetQuery(values); break; }
                case "find": { executeFindQuery(values);  break; }

            }
        }
        public static void loadXMLFile(string xmlFile)
        {
            try
            {
                List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

                using (XmlReader reader = XmlReader.Create(xmlFile))
                {
                    // Boolean flag to track whether we're inside the <list> element
                    bool insideList = false;

                    while (reader.Read())
                    {
                        // Check for the start of the <list> element
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "list")
                        {
                            insideList = true;  // Set flag when inside <list>
                            continue;  // Skip further processing and move to next iteration
                        }

                        // Check for the end of the <list> element
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "list")
                        {
                            insideList = false;  // Reset flag when leaving <list>
                            readValues = false;
                            break;  // Stop reading since we only care about content inside <list>
                        }
                        if (insideList && reader.NodeType == XmlNodeType.EndElement && reader.Depth == 1)
                        {
                            readValues = false;
                            checkBasedOnOperation(method, values);
                            values.Clear();
                   
                        }
                        // Process elements only if they are inside <list> and under <operation>
                        if (insideList && reader.NodeType == XmlNodeType.Element && reader.Depth == 2)
                        {
                            string elementName = reader.Name;  // Get the name of the elemen

                            if (reader.Read() && reader.NodeType == XmlNodeType.Text)
                            {                
                                if (!readValues)
                                {
                                    switch (elementName)
                                    {
                                        case "database": { database = reader.Value.Trim(); break; }
                                        case "table": { table = reader.Value.Trim(); break; }
                                        case "method":
                                            {
                                                method = reader.Value.Trim();
                                                //Console.WriteLine($"{database}\t{table}\t{method}");
                                                readValues = true;
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                   values.Add(new KeyValuePair<string, string>(elementName, reader.Value.Trim())); 
                                }


                            }
                            else
                            {
                                values.Add(new KeyValuePair<string, string>(elementName, "adas"));
                            }
                        }

                    }
                }
                Console.ReadKey();
            }
            catch (XmlException xe)
            {
                Console.WriteLine($"XML Exception: {xe.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            loadXMLFile(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\test.xml");
            
        }
    }
}
