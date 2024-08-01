using Claysys_SQLTask.Models;
using static Claysys_SQLTask.Models.TaskModel;
using System.Data.SqlClient;
using System.Data;
namespace Claysys_SQLTask.Repository
{
    public class TaskRepo
    {
        private readonly string _connectionString;

        public TaskRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevConnection");
        }
        public List<Client> GetClients()
        {
            var clients = new List<Client>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT ID, ClientName FROM dbo.ClientDetails", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("ClientName"))
                            });
                        }
                    }
                }
            }

            return clients;
        }

        public List<Project> GetProjects(int clientId)
        {
            var projects = new List<Project>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT ID, ProjectName, ClientID FROM dbo.ProjectDetails WHERE ClientID = @ClientId", connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new Project
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                Name = reader.GetString(reader.GetOrdinal("ProjectName")),
                                ClientId = reader.GetInt32(reader.GetOrdinal("ClientID"))
                            });
                        }
                    }
                }
            }

            return projects;
        }
    }

}
