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

        public void Add(Flight flight)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Flights(FlightDirectionId,FlightNumber,City,Terminal,FlightStatusId,At,Airlines ) Values(@flightDirectionId, @flightNumber, @city,@terminal, @status, @at, @airline)";
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
                    command.CommandText = "INSERT INTO dbo.Passengers(FirstName,LastName,Passport,Birthday,SexId,TicketId, FlightNumber) Values (@FirstName,@LastName,@Passport,@Birthday,@SexId,@TicketId, @FlightNumber)";
                    command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20, "FirstName").Value = passender.Firstname;
                    command.Parameters.Add("@LastName", SqlDbType.NVarChar, 255, "LastName").Value = passender.Lastname;
                    command.Parameters.Add("@Passport", SqlDbType.NVarChar, 20, "Passport").Value = passender.Passport;
                    command.Parameters.Add("@Birthday", SqlDbType.DateTime, 0, "Birthday").Value = passender.Birthday;
                    command.Parameters.Add("@SexId", SqlDbType.Int, 0, "SexId").Value = (int)passender.Sex;
                    command.Parameters.Add("@TicketId", SqlDbType.Int, 0, "TicketId").Value = (int)passender.Ticket;
                    command.Parameters.Add("@FlightNumber", SqlDbType.NVarChar, 0, "FlightNumber").Value = flightNumber;
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
                    command.CommandText = "Delete from Flights where FlightNumber = @FlightNumber";
                    command.Parameters.Add("@FlightNumber", SqlDbType.NVarChar, 255, "FlightNumber").Value = flight.FlightNumber;
                    command.ExecuteNonQuery();
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
                    command.CommandText = "Delete from Passengers where Passport = @Passport";
                    command.Parameters.Add("@Passport", SqlDbType.NVarChar, 255, "FlightNumber").Value = passender.Passport;
                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
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
                    command.CommandText="UPDATE Flights SET FlightDirectionId = @flightDirectionId, City = @city, Terminal = @terminal, FlightStatusId = @flightStatusId, At=@at, Airlines = @airlines WHERE  FlightNumber = @flightNumber";
                    command.Parameters.Add("@flightDirectionId", SqlDbType.Int, 2, "FlightDirectionId").Value = (int)flight.Direction;
                    command.Parameters.Add("@city", SqlDbType.NVarChar, 0, "City").Value = flight.City;
                    command.Parameters.Add("@terminal", SqlDbType.NVarChar, 0, "Terminal").Value = flight.Terminal;
                    command.Parameters.Add("@flightStatusId", SqlDbType.Int, 0, "FlightStatusId").Value = (int)flight.FlightStatus;
                    command.Parameters.Add("@at", SqlDbType.DateTime, 0, "At").Value = flight.DateTime;
                    command.Parameters.Add("@airlines", SqlDbType.NVarChar, 0, "Airline").Value = flight.Airline;
                    command.Parameters.Add("@flightNumber", SqlDbType.NVarChar, 0, "FlightNumber").Value = flight.FlightNumber;
                    command.ExecuteNonQuery();
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
                    command.CommandText = "Select FlightNumber, City, Terminal, At, Airlines, FlightDirections.Id as Direction, FlightStatuses.Id as FlightStatus From Flights join FlightDirections on Flights.FlightDirectionId = FlightDirections.Id join FlightStatuses on FlightStatusId = FlightStatuses.Id where City = @City";
                    command.Parameters.Add("@City", SqlDbType.NVarChar, 255, "City").Value = city.ToUpper();
                    SqlDataReader reader= command.ExecuteReader();
                    return MapFlight(reader);
                }
            }
        }

        private IEnumerable<Flight> MapFlight(SqlDataReader reader)
        {
            List<Flight> result = new List<Flight>();
            while (reader.Read())
            {
                Flight flight = new Flight();
                flight.Direction = (Direction)reader.GetInt32(reader.GetOrdinal("Direction"));
                flight.FlightNumber = reader.GetString(reader.GetOrdinal("FlightNumber"));
                flight.DateTime = reader.GetDateTime(reader.GetOrdinal("At"));
                flight.City = reader.GetString(reader.GetOrdinal("City"));
                flight.Terminal = reader.GetString(reader.GetOrdinal("Terminal"));
                flight.Airline = reader.GetString(reader.GetOrdinal("Airlines"));
                flight.FlightStatus = (Status)reader.GetInt32(reader.GetOrdinal("FlightStatus"));
                result.Add(flight);

            }
            return result;
        }

        public Flight FindByNumber(string flightNumber)
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "Select FlightNumber, City, Terminal, At, Airlines, FlightDirections.Id as Direction, FlightStatuses.Id as FlightStatus From Flights join FlightDirections on Flights.FlightDirectionId = FlightDirections.Id join FlightStatuses on FlightStatusId = FlightStatuses.Id where FlightNumber = @flightNumber";
                    command.Parameters.Add("@flightNumber", SqlDbType.NVarChar, 255, "FlightNumber").Value = flightNumber;
                    SqlDataReader reader = command.ExecuteReader();
                    return MapFlight(reader).FirstOrDefault();

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
                    command.CommandText = "Select FlightNumber, City, Terminal, At, Airlines, FlightDirections.Id as Direction, FlightStatuses.Id as FlightStatus From Flights join FlightDirections on Flights.FlightDirectionId = FlightDirections.Id join FlightStatuses on FlightStatusId = FlightStatuses.Id where At = @At";
                    command.Parameters.Add("@At", SqlDbType.NVarChar, 255, "At").Value = dateTime;
                    SqlDataReader reader = command.ExecuteReader();
                    return MapFlight(reader);
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
                    command.CommandText = "Select FlightNumber, City, Terminal, At, Airlines, FlightDirections.Id as Direction, FlightStatuses.Id as FlightStatus From Flights join FlightDirections on Flights.FlightDirectionId = FlightDirections.Id join FlightStatuses on FlightStatusId = FlightStatuses.Id where City = @City";
                    SqlDataReader reader = command.ExecuteReader();
                    return MapFlight(reader);
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
                    command.CommandText = "Select FirstName, LastName, Passport, Birthday, SexId, TicketId, FlightNumber from Passengers where FlightNumber = @flightNumber";
                    command.Parameters.Add("@flightNumber", SqlDbType.NVarChar, 0, "FlightNumber").Value = flightNumber;
                    SqlDataReader reader = command.ExecuteReader();
                    return MapPassenger(reader);
                }
            }
        }

        private IEnumerable<Passenger> MapPassenger(SqlDataReader reader)
        {
            List<Passenger> result = new List<Passenger>();
            while (reader.Read())
            {
                Passenger passenger = new Passenger();
                passenger.Firstname = reader.GetString(reader.GetOrdinal("FirstName"));
                passenger.Lastname = reader.GetString(reader.GetOrdinal("Lastname"));
                passenger.Passport = reader.GetString(reader.GetOrdinal("Passport"));
                passenger.Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
                passenger.Sex = (Sex)reader.GetInt32(reader.GetOrdinal("SexId"));
                passenger.Ticket = (TicketType)reader.GetInt32(reader.GetOrdinal("TicketId"));
                result.Add(passenger);
            }
            return result;
        }

        public IEnumerable<Passenger> FindPassengerByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "Select FirstName, LastName, Passport, Birthday, SexId, TicketId, FlightNumber from Passengers where FirstName ilike %@parametr% or LastName ilike %@parametr%";
                    command.Parameters.Add("@parametr", SqlDbType.NVarChar, 0, "Parametr").Value = name;
                    SqlDataReader reader = command.ExecuteReader();
                    return MapPassenger(reader);
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
                    command.CommandText = "Select FirstName, LastName, Passport, Birthday, SexId, TicketId, FlightNumber from Passengers where Passport = @passport";
                    command.Parameters.Add("@passport", SqlDbType.NVarChar, 10, "Passport").Value = passport;
                    SqlDataReader reader = command.ExecuteReader();
                    return MapPassenger(reader).FirstOrDefault();
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
                    command.CommandText = "Select FlightNumber, City, Terminal, At, Airlines, FlightDirections.Id as Direction, FlightStatuses.Id as FlightStatus From Flights join FlightDirections on Flights.FlightDirectionId = FlightDirections.Id join FlightStatuses on FlightStatusId = FlightStatuses.Id";
                    SqlDataReader reader = command.ExecuteReader();
                    return MapFlight(reader);

                }
            }
        }

        public void EditPassenger(Passenger passenger)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Passengers SET FirstName = @firstName, LastName = @lastName,  Birthday = @birthday, SexId = @sexId, TicketId = @ticketId, FlightNumber = @flightNumber WHERE Passport = @passport";
                    command.Parameters.Add("@firstName", SqlDbType.NChar, 0, "FirstName").Value = passenger.Firstname;
                    command.Parameters.Add("@lastName", SqlDbType.NChar, 0, "LastName").Value = passenger.Lastname;
                    command.Parameters.Add("@birthday", SqlDbType.DateTime, 0, "Birthday");
                    command.Parameters.Add("@sexId", SqlDbType.Int, 0, "SexId");
                    command.Parameters.Add("@ticketId", SqlDbType.Int, 0, "ticketId");
                    command.Parameters.Add("@flightNumber", SqlDbType.NChar, 0, "FlightNumber");
                    command.Parameters.Add("@passport", SqlDbType.NChar, 0, "Passport");
                    command.ExecuteNonQuery();
                    
                }
            }


        }

    }
}
