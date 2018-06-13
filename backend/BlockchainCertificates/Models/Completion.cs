using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainCertificates.Helpers;
using MySql.Data.MySqlClient;

namespace BlockchainCertificates.Models
{
    public class Completion
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public int Grade { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }

        public async Task<bool> Save()
        {
            try
            {
                var dbcon = DBConnection.Instance();
                if (!dbcon.IsConnect()) return false;

                var query = "INSERT INTO completion(studentId,courseId,grade,semester,year) VALUES(?studentId,?courseId,?grade,?semester,?year)";
                var cmd = new MySqlCommand(query, dbcon.Connection);
                cmd.Parameters.Add("?studentId", MySqlDbType.VarChar).Value = StudentId;
                cmd.Parameters.Add("?courseId", MySqlDbType.VarChar).Value = CourseId;
                cmd.Parameters.Add("?grade", MySqlDbType.Int16).Value = Grade;
                cmd.Parameters.Add("?semester", MySqlDbType.VarChar).Value = Semester;
                cmd.Parameters.Add("?year", MySqlDbType.VarChar).Value = Year;
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
