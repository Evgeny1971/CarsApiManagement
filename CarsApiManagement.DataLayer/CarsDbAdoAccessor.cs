using CarsApiManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace CarsApiManagement.DataLayer
{

public class CarsDbAdoAccessor //: IProductsApiRepository
{
    private readonly string connectionString;

    public CarsDbAdoAccessor(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public async Task<List<Car>> GetAllCars()
    {
        List<Car> products = new List<Car>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("stp_GetAllProducts", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                ShopProduct product = MapToShopProduct(reader);
                products.Add(product);
            }
            reader.Close();
        }

        return products;
    }

    public async Task<Xml> CreateOrder(Order order)
    {
            int orderId = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("stp_CreateOrder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CompanyName", companyName);
                    command.Parameters.AddWithValue("@CompanyHp", companyHp);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Comment", comment);

                    SqlParameter orderIdParameter = new SqlParameter("@OrderId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(orderIdParameter);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    // Get the output parameter value (newly inserted OrderId)
                    orderId = Convert.ToInt32(orderIdParameter.Value);
                }
            }
            ///
            foreach (Car car in order.ListCars)
            {
                using (SqlCommand command = new SqlCommand("stp_CreateCar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@OrderId", orderId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CarNumber", carNumber);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@Color", color);

                    SqlParameter carIdParameter = new SqlParameter("@CarId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(carIdParameter);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    // Get the output parameter value (newly inserted CarId)
                    carId = Convert.ToInt32(carIdParameter.Value);
                }                
            }

        return shopProduct;
    }

    public async Task<ShopProduct> GetOrdeById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("stp_GetShopProductById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return MapToShopProduct(reader);
            }
            return null;
        }
    }

    public async Task<bool> DeleteShopProductById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand("DeleteShopProductById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", id);

            await connection.OpenAsync();
            int rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }


    private ShopProduct MapToShopProduct(SqlDataReader reader)
    {
        return new ShopProduct
        {
            ID = Convert.ToInt64(reader["ID"]),
            Code = reader["Code"].ToString(),
            Name = reader["Name"].ToString(),
            Description = reader["Description"].ToString(),
            StartOfPrice = Convert.ToDateTime(reader["StartOfPrice"]),
            Image = reader["Image"].ToString()
        };
    }
}
}