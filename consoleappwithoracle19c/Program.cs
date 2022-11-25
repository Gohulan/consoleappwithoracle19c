using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;



namespace consoleappwithoracle19c
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Please replace the connection string attribute settings

                string constr = "Data Source = (DESCRIPTION = " +
            "(ADDRESS = (PROTOCOL = TCP)(HOST = GCSRV2003)(PORT = 1521))" +
            "(CONNECT_DATA = " +
              " (SERVER = DEDICATED)" +
              " (SERVICE_NAME = MCRSPOS)" +
            " )" +
          "); User Id = DBCREATE ; password=Galadari2022#;";

                //Below I am checking the Oracle database version 

                OracleConnection con = new OracleConnection(constr);
                con.Open();
                Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
                

                //Below running a query to get the results in the console
                // In the database I have created demo table named employee, columns are employeeid and username
                
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "select username from Employee where employeeid=1 ";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Console.WriteLine(dr.GetString(0));
              
                con.Dispose();
                Console.WriteLine("Press RETURN to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0}", ex);
            }
        }
    }
}
