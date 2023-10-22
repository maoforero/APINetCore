using APINetcore.DBManagement;
using APINetcore.Models;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace APINetcore.Repository
{
    public class ProductsSQLServer : IProductsInMemory
    {
        private string _ConnectionString;

        public ProductsSQLServer(DataAccess dataAccess)
        {
            this._ConnectionString = dataAccess.SQLConnectionString;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(_ConnectionString);
        }

        public async Task AddProductAsinc(Product p)
        {
            SqlConnection sqlConnection = conexion();
            SqlCommand cmd = null;

            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.ProductosALta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = p.Name;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 5000).Value = p.Description;
                cmd.Parameters.Add("@Precio", SqlDbType.Float).Value = p.Price;
                cmd.Parameters.Add("@SKU", SqlDbType.VarChar, 100).Value = p.SKU;

                await cmd.ExecuteNonQueryAsync();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error al dar de alta. " + e.ToString());
            }
            finally
            {
                cmd.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsinc(string SKU)
        {
            SqlConnection sqlConnection = conexion();
            SqlCommand cmd = null;

            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "dbo.Productos_Borrar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SKU", SqlDbType.VarChar, 100).Value=SKU;
                await cmd.ExecuteNonQueryAsync();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new Exception("[!] Error deleting a product: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsinc()
        {
            SqlConnection sqlConnection = conexion();
            SqlCommand cmd = null;
            List<Product> products = new List<Product>();
            Product p = null;

            try
            {
                sqlConnection.Open();
                cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (reader.Read())
                {
                    p = new Product
                    {
                        Name = reader["name"].ToString(),
                        Description = reader["description"].ToString(),
                        Price = Convert.ToDouble(reader["price"].ToString()),
                        SKU = reader["SKU"].ToString()
                    };

                    products.Add(p);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("[!] Error getting all products. " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return products;
        }

        public async Task<Product> GetProductAsinc(string SKU)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsinc(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
