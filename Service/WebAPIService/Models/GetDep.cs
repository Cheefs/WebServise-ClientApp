using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPIService.Models
{
    public class GetDep
    {
        private SqlConnection sqlConnection;
        public GetDep()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=homework7;
                                        Integrated Security=True;
                                        ";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        /// <summary>
        /// Получение списка департаментов с базы данных
        /// </summary>
        public List<Departament> GetAll()
        {
            List<Departament> list = new List<Departament>();

            string sql = @"SELECT * FROM Departament";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(
                            new Departament()
                            {
                                Id = reader["id"].ToString(),
                                DepName = reader["DepName"].ToString(),
                            });
                    }
                }

            }

            return list;
        }
        /// <summary>
        /// Получение департамента по айди, с базы данных
        /// </summary>
        public Departament DepId(int Id)
        {
            string sql = $@"SELECT * FROM Departament WHERE Id={Id}";
            Departament temp = new Departament();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        temp = new Departament()
                        {
                            Id = reader["Id"].ToString(),
                            DepName = reader["DepName"].ToString(),
                        };
                    }
                }

            }
            return temp;
        }
    }
}
