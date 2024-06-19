using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesForecastingApp
{
    public class DataAccess
    {
        private string connectionString = "Your_SQL_Server_Connection_String";
        
        public DataTable GetSalesData(int year)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        order_id, 
                        order_date, 
                        product_id, 
                        sales, 
                        return_amount
                    FROM Orders
                    WHERE YEAR(order_date) = @Year";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", year);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
    }
}
