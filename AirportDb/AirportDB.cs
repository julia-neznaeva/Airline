using PresenterLevel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AirportLibrary;

namespace AirportDbLevel
{
   public  class AirportDB : IAirport
{
        string _connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        public static AirportDB Create()
        {
            return new AirportDB();
        }


        public void DoWork()
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

        public void Add(Flight flight)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO dbo.Flights(FlightDirectionId,FlightNumber,City,Terminal,FlightStatusId,At,Airlines ) Values(@flightDirectionId, @flightNumber, @city,@terminal, @status, @at, @airline)";
                    command.Parameters.Add("@flightDirectionId", SqlDbType.Int, 0, "FlightDirectionId").Value = (int)flight.Direction;
                    command.Parameters.Add("@flightNumber", SqlDbType.NVarChar, 255, "FlightNumber").Value = flight.FlightNumber;
                    command.Parameters.Add("@city", SqlDbType.NVarChar, 100, "City").Value = flight.City;
                    command.Parameters.Add("@terminal", SqlDbType.NVarChar, 10 ,"Terminal").Value = flight.Terminal;
                    command.Parameters.Add("@status", SqlDbType.Int, 1, "FlightStatusId").Value = (int)flight.FlightStatus;
                    command.Parameters.Add("@at", SqlDbType.DateTime, 10, "At").Value = flight.DateTime;
                    command.Parameters.Add("@airline", SqlDbType.NVarChar, 10, "Airlines").Value = flight.Airline;
                    command.ExecuteNonQuery();

                }

            }
        }

        public void AddPassenger(string flightNumber, Passenger passender)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "ISERT INTO dbo.Passengers(FirstName,LastName,Passport,Birthday,SexId,TicketId, FlightId)Value(@FirstName,@LastName,@Passport,@Birthday,@SexId,@TicketId, @FlightId)";
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName").Value = passender.Firstname;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar, 255, "LastName").Value = passender.Lastname;
                    command.Parameters.Add("@Passport", SqlDbType.NVarChar, 20, "Passport").Value = passender.Passport;
                    command.Parameters.Add("@Birthday", SqlDbType.DateTime, 0, "Birthday").Value = passender.Birthday;
                    command.Parameters.Add("@SexId", SqlDbType.Int, 0, "SexId").Value = (int)passender.Sex;
                    command.Parameters.Add("@TicketId", SqlDbType.Int, 0, "TicketId").Value = (int)passender.Ticket;
                    command.Parameters.Add("@FlightId", SqlDbType.Int, 0, "FlightId").Value = 1;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFlight(Flight flight)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public bool DeletePassender(Passenger passender, string flightNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public void Edite(Flight flight)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public IEnumerable<Flight> FindByCity(string city)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public Flight FindByNumber(string flightNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public IEnumerable<Flight> FindByTime(DateTime dateTime)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public IEnumerable<Flight> FindNearest()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public IEnumerable<Passenger> FindPassengerByFlight(string flightNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public IEnumerable<Passenger> FindPassengerByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public Passenger FindPassengerPassport(string passport)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }

        public IEnumerable<Flight> GetFlights()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
