using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceWithDatabaseImplementation.Models;

namespace WorkerServiceWithDatabaseImplementation.Services
{
    public class Service : IService
    {
        private readonly IConfiguration _configuration;
        public Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool AddDetails(Details add)
        {
            int result = 0;
            string? connectionString = _configuration.GetConnectionString("ConnectionString")?.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand("insert into Details(ID,DateTime)values(@param1,@param2)", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@param1", add.ID);
                cmd.Parameters.AddWithValue("@param2", add.DateTime);
                result = cmd.ExecuteNonQuery();
            }
            if (result == 1)
            {
                sqlConnection.Close();
                return true;
            }
            else
            {
                sqlConnection.Close();
                return false;
            }
        }
    }
}

