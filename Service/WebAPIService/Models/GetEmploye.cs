using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace WebAPIService.Models
{
    /// <summary>
    /// Описание логики получения данных с БД
    /// </summary>
    public class GetEmploye
    {
        private SqlConnection sqlConnection;
        public GetEmploye()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=homework7;
                                        Integrated Security=True;
                                        ";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        /// <summary>
        /// Получить список сотрудников с базы данных
        /// </summary>
        public List<Employe> GetAll()
        {
            List<Employe> list = new List<Employe>();

            string sql = @"SELECT * FROM Employe";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(
                            new Employe()
                            { Id = reader["id"].ToString(),
                                Name = reader["Name"].ToString(),
                                SecondName = reader["SecondName"].ToString(),
                                Age = reader["Age"].ToString(),
                                DepName = reader["DepartamentID"].ToString(),
                            });
                    }
                }

            }

            return list;
        }
        /// <summary>
        /// Получить сотрудника по Айди с базы данных
        /// </summary>
        /// <param name="Id">айди</param>
        /// <returns> сотрудника</returns>
        public Employe EmpId(int Id)
        {
            string sql = $@"SELECT * FROM Employe WHERE Id={Id}";
            Employe e = new Employe();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        e = new Employe()
                        {
                            Id = reader["Id"].ToString(),
                            Name = reader["Name"].ToString(),
                            SecondName = reader["SecondName"].ToString(),
                            Age = reader["Age"].ToString(),
                            DepName = reader["DepartamentID"].ToString(),

                        };
                    }
                }

            }
            return e;
        }
    }
}