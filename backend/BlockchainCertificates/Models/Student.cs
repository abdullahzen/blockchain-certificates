using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlockchainCertificates.Helpers;
using MySql.Data.MySqlClient;

namespace BlockchainCertificates.Models
{
    public class Student
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Program { get; set; }
        public int AvgGrade { get; set; }
        public bool CertIssued { get; set; }
        public string CertIssueDate { get; set; } = "";

        public Student ChangeProgram(string program)
        {
            Program = program;
            return this;
        }

        public async Task<Student> Save()
        {
            return await SetDb("INSERT INTO student(id,firstname,lastname,imageUrl,program,avgGrade,certIssued,certIssueDate) VALUES(?id,?firstname,?lastname,?imageUrl,?program,?avgGrade,?certIssued,?certIssueDate)");
        }

        public async Task<Student> Update()
        {
            return await SetDb("UPDATE student SET firstname=?firstname, lastname=?lastname, imageUrl=?imageUrl, program=?program, avgGrade=?avgGrade, certIssued=?certIssued, certIssueDate=?certIssueDate WHERE id = ?id");
        }

        public static async Task<Student> Get(string studentId)
        {
            return (await GetDb($"SELECT * FROM student WHERE id = \"{studentId}\""))?[0];
        }

        public static async Task<Student[]> GetAll()
        {
            return await GetDb("SELECT * FROM student");
        }

        private async Task<Student> SetDb(string query)
        {
            try
            {
                var dbcon = DBConnection.Instance();
                if (!dbcon.IsConnect()) return null;

                var cmd = new MySqlCommand(query, dbcon.Connection);
                cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = Id;
                cmd.Parameters.Add("?firstname", MySqlDbType.VarChar).Value = FirstName;
                cmd.Parameters.Add("?lastname", MySqlDbType.VarChar).Value = LastName;
                cmd.Parameters.Add("?imageUrl", MySqlDbType.VarChar).Value = ImageUrl;
                cmd.Parameters.Add("?program", MySqlDbType.VarChar).Value = Program;
                cmd.Parameters.Add("?avgGrade", MySqlDbType.Int16).Value = AvgGrade;
                cmd.Parameters.Add("?certIssued", MySqlDbType.Bit).Value = CertIssued;
                cmd.Parameters.Add("?certIssueDate", MySqlDbType.VarChar).Value = CertIssueDate;
                await cmd.ExecuteNonQueryAsync();
                return this;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static async Task<Student[]> GetDb(string query)
        {
            try
            {
                var dbcon = DBConnection.Instance();
                if (!dbcon.IsConnect()) return null;

                var cmd = new MySqlCommand(query, dbcon.Connection);
                var reader = await cmd.ExecuteReaderAsync();

                var students = new List<Student>();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (string)reader[0],
                        FirstName = (string)reader[1],
                        LastName = (string)reader[2],
                        ImageUrl = (string)reader[3],
                        Program = (string)reader[4],
                        AvgGrade = (int)reader[5],
                        CertIssued = (bool)reader[6],
                        CertIssueDate = (string)reader[7]
                    });
                }
                reader.Close();
                return students.ToArray();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
