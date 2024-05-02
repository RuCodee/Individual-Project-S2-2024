using Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdministratorDAL
    {

        public int CreateAdministrator(Administrator administrator)
        {
            using (var connection = DBHelper.OpenConnection())
            {
                var query = @"
        INSERT INTO Administrators (UserId, AdministratorJobId)
        VALUES (@UserId, @AdministratorJobId);
        SELECT CAST(SCOPE_IDENTITY() AS int);";  // Retrieve the new Administrator ID

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", administrator.Id);
                    command.Parameters.AddWithValue("@AdministratorJobId", administrator.AdministratorJobId);

                    var result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int newAdministratorId))
                    {
                        administrator.Id = newAdministratorId;
                        return newAdministratorId;
                    }
                    else
                    {
                        // Log the issue and handle it without throwing an exception
                        // Log.Error("Failed to retrieve a valid Administrator ID.");
                        // Return a default or error indicator ID, for example -1 or 0
                        return -1;
                    }
                }
            }
        }

        public Administrator? GetAdministratorById(int administratorId)
        {
            // retrieve an administrator by their ID
            return null;
        }

        public void UpdateAdministrator(Administrator administrator)
        {
            // update an existing administrator's details
        }

        public void DeleteAdministrator(int administratorId)
        {
            // delete an administrator by their ID
        }
    }
}
