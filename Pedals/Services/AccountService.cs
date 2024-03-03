using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pedals.Services
{
    public class AccountService : IAccountService
    {

        private readonly string connectionString;
        public AccountService(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<staff> GetStaffDetails(int? staff_id)
        {
            List<staff> staffList = new List<staff>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_GetStaffDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@@staff_id", staff_id);

                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            staff staffMember = new staff
                            {
                                first_name = reader["first_name"].ToString(),
                                last_name = reader["last_name"].ToString(),
                                email = reader["email"].ToString(),
                                phone = reader["phone"].ToString(),
                                store_id = Convert.ToInt32(reader["store_id"])
                            };
                            staffList.Add(staffMember);
                        }
                    }
                }
            }

            return staffList;
        }

    }
}