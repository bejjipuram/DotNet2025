using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using FlightSearchEngine.Models;

namespace FlightSearchEngine.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            // Read named connection string from configuration (appsettings.json)
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured. Set it in appsettings.json under ConnectionStrings.");
            }
        }

        public async Task<FlightResult?> GetFlightByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetFlightById", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FlightId", id);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new FlightResult
                {
                    FlightId = reader.GetInt32(reader.GetOrdinal("FlightId")),
                    FlightName = reader.GetString(reader.GetOrdinal("FlightName")),
                    FlightType = reader.GetString(reader.GetOrdinal("FlightType")),
                    Source = reader.GetString(reader.GetOrdinal("Source")),
                    Destination = reader.GetString(reader.GetOrdinal("Destination")),
                    PricePerSeat = reader.IsDBNull(reader.GetOrdinal("PricePerSeat")) ? 0 : reader.GetDecimal(reader.GetOrdinal("PricePerSeat"))
                };
            }
            return null;
        }

        public async Task<FlightHotelResult?> GetFlightHotelByFlightIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetFlightHotelByFlightId", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@FlightId", id);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new FlightHotelResult
                {
                    FlightId = reader.GetInt32(reader.GetOrdinal("FlightId")),
                    FlightName = reader.GetString(reader.GetOrdinal("FlightName")),
                    Source = reader.GetString(reader.GetOrdinal("Source")),
                    Destination = reader.GetString(reader.GetOrdinal("Destination")),
                    HotelName = reader.GetString(reader.GetOrdinal("HotelName")),
                    TotalCost = reader.IsDBNull(reader.GetOrdinal("TotalCost")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalCost"))
                };
            }
            return null;
        }
        

        public async Task<List<string>> GetSourcesAsync()
        {
            var list = new List<string>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetSources", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(reader.GetString(0));
            }
            return list;
        }

        public async Task<List<string>> GetDestinationsAsync()
        {
            var list = new List<string>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetDestinations", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(reader.GetString(0));
            }
            return list;
        }

        public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
        {
            var list = new List<FlightResult>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_SearchFlights", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Source", source);
            cmd.Parameters.AddWithValue("@Destination", destination);
            cmd.Parameters.AddWithValue("@Persons", persons);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var item = new FlightResult
                {
                    FlightId = reader.GetInt32(reader.GetOrdinal("FlightId")),
                    FlightName = reader.GetString(reader.GetOrdinal("FlightName")),
                    FlightType = reader.GetString(reader.GetOrdinal("FlightType")),
                    Source = reader.GetString(reader.GetOrdinal("Source")),
                    Destination = reader.GetString(reader.GetOrdinal("Destination")),
                    TotalCost = reader.GetDecimal(reader.GetOrdinal("TotalCost"))
                };
                list.Add(item);
            }
            return list;
        }

        public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
        {
            var list = new List<FlightHotelResult>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_SearchFlightsWithHotels", conn) { CommandType = System.Data.CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Source", source);
            cmd.Parameters.AddWithValue("@Destination", destination);
            cmd.Parameters.AddWithValue("@Persons", persons);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var item = new FlightHotelResult
                {
                    FlightId = reader.GetInt32(reader.GetOrdinal("FlightId")),
                    FlightName = reader.GetString(reader.GetOrdinal("FlightName")),
                    Source = reader.GetString(reader.GetOrdinal("Source")),
                    Destination = reader.GetString(reader.GetOrdinal("Destination")),
                    HotelName = reader.GetString(reader.GetOrdinal("HotelName")),
                    TotalCost = reader.GetDecimal(reader.GetOrdinal("TotalCost"))
                };
                list.Add(item);
            }
            return list;
        }
    }
}