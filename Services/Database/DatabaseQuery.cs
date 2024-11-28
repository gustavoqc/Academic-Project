using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Services.Database
{
    internal class DatabaseQuery
    {
        private const string connectionString = "Host=localhost;Username=root;Password=password;Database=uninove-02-2024";

        public DataTable? SelectQuery(SelectQueryParams queryParams)
        {
            DataTable dataTable = new();

            string selectedColumns = queryParams.Columns == null ? "*" :
                string.Join(", ", queryParams.Columns.Select(c =>
                    $"{c.Name}{(string.IsNullOrEmpty(c.Alias) ? "" : $" AS \"{c.Alias}\"")}"
                ));

            string query = $"SELECT {selectedColumns} FROM {queryParams.TableName}";
            
            if (queryParams.InnerJoin != null && queryParams.InnerJoin.Length > 0)
            {
                foreach (var condition in queryParams.InnerJoin)
                {
                    query += $" INNER JOIN {condition}";
                }
            }

            if (queryParams.LeftJoin != null && queryParams.LeftJoin.Length > 0)
            {
                foreach (var condition in queryParams.LeftJoin)
                {
                    query += $" LEFT JOIN {condition}";
                }
            }

            if (!string.IsNullOrEmpty(queryParams.Where))
            {
                query += $" WHERE {queryParams.Where}";
            }

            if (!string.IsNullOrEmpty(queryParams.OrderBy))
            {
                query += $" ORDER BY {queryParams.OrderBy}";
            }

            using (MySqlConnection conn = new(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataAdapter dataAdapter = new(query, conn))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    conn.Close();

                    return dataTable;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro ao conectar ou executar a consulta: " + ex.Message);
                    conn.Close();
                    return null;
                }
            }
        }

        public int InsertQuery(InsertQueryParams queryParams)
        {
            int rows = 0;
            string Columns = string.Join(", ", queryParams.Columns);
            string Values = string.Join(", ", queryParams.Values);

            string query = $"INSERT INTO {queryParams.TableName} ({Columns}) Values ({Values})";

            using (MySqlConnection conn = new(connectionString))
            {
                using (MySqlCommand oCommand = new(query, conn))
                {
                    try
                    {
                        conn.Open();
                        rows = oCommand.ExecuteNonQuery();
                        conn.Close();
                        return rows;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ou executar a consulta: " + ex.Message);
                        conn.Close();
                        return rows;
                    }
                }
            }
        }

        public void DeleteQuery(DeleteQueryParams queryParams)
        {
            string where = $"{queryParams.Where.Column} = {queryParams.Where.Value}";

            string query = $"DELETE FROM {queryParams.TableName} WHERE {where}";

            using (MySqlConnection conn = new(connectionString))
            {
                using (MySqlCommand oCommand = new(query, conn))
                {
                    try
                    {
                        conn.Open();
                        oCommand.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ou executar a consulta: " + ex.Message);
                        conn.Close();
                    }
                }
            }
        }
        public int UpdateQuery(UpdateQueryParams queryParams)
        {
            int rows = 0;
            string where = $"{queryParams.Where.Column} = {queryParams.Where.Value}";
            string columns = string.Join(", ", queryParams.Columns.Select(c => $"{c.Name} = {c.Value}"));

            string query = $"UPDATE {queryParams.TableName} SET {columns} WHERE {where}";
            
            using (MySqlConnection conn = new(connectionString))
            {
                using (MySqlCommand oCommand = new(query, conn))
                {
                    try
                    {
                        conn.Open();
                        rows = oCommand.ExecuteNonQuery();
                        conn.Close();
                        return rows;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ou executar a consulta: " + ex.Message);
                        conn.Close();
                        return rows;
                    }
                }
            }
        }
    }
}
