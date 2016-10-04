using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AirportDb
{
    public static class Class1
    {
        public static void DoWork()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;
            DataSet dataSet = new DataSet("FlightsDataSet");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select * from dbo.Flights", connection))
                {
                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataSet, "Flights");
                    }
                }
            }
            var flightTable = dataSet.Tables["Flights"];
            Print(flightTable);



        }

        private static void Print(DataTable flightTable)
        {
            foreach (DataRow row in flightTable.Rows)
            {
                for (int i = 0; i < flightTable.Columns.Count; i++)
                {
                    Console.Write("{0, 20}", row[i]);
                }
                Console.Write('\n');
            }
        }
    }
}
