using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pedals.Services
{
    public class DashboardService : IDashboardService
    {

        private readonly string connectionString;
        public DashboardService(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List <order> GetOrderDetails(DateTime FromDate, DateTime ToDate, string Status, int PageNumber, int PageSize)
        {
            List<order> orderList = new List<order>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_GetOrderDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FromDate", FromDate);
                    command.Parameters.AddWithValue("@ToDate", ToDate);
                    command.Parameters.AddWithValue("@SelectedStatusList", Status);
                    command.Parameters.AddWithValue("@PageNumber", PageNumber);
                    command.Parameters.AddWithValue("@PageSize", PageSize);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            order OrderList = new order
                            {
                                order_id = Convert.ToInt32(reader["Order_Id"]),
                                customer_id = Convert.ToInt32(reader["Customer_Id"]),
                                status = reader["Status"].ToString(),
                                order_date = reader["OrderDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["OrderDate"]),
                                required_date = reader["RequiredDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["RequiredDate"]),
                                shipped_date = reader["ShippedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["ShippedDate"]),
                                store_id = Convert.ToInt32(reader["Store_Id"]),
                                staff_id = Convert.ToInt32(reader["Staff_ID"])
                            };
                            orderList.Add(OrderList);
                        }
                    }
                }
            }

            return orderList;
        }
    }
}