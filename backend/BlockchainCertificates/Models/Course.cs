using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainCertificates.Helpers;
using MySql.Data.MySqlClient;

namespace BlockchainCertificates.Models
{
    public class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Program { get; set; }
        public string Room { get; set; }
        public int Capacity { get; set; }

        public Course ChangeRoom(string room, int capacity)
        {
            Room = room;
            Capacity = capacity;
            return this;
        }

        public async Task<Course> Save()
        {
            return await SetDb("INSERT INTO course(id,name,program,room,capacity) VALUES(?id,?name,?program,?room,?capacity)");
        }

        public async Task<Course> Update()
        {
            return await SetDb("UPDATE course SET name = ?name, program = ?program, room = ?room, capacity = ?capacity WHERE id = ?id");
        }

        public static async Task<Course> Get(string courseId)
        {
            return (await GetDb($"SELECT * FROM course WHERE id = {courseId}"))?[0];
        }

        public static async Task<Course[]> GetAll()
        {
            return await GetDb("SELECT * FROM course");
        }

        private async Task<Course> SetDb(string query)
        {
            try
            {
                var dbcon = DBConnection.Instance();
                if (!dbcon.IsConnect()) return null;

                var cmd = new MySqlCommand(query, dbcon.Connection);
                cmd.Parameters.Add("?id", MySqlDbType.VarChar).Value = Id;
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = Name;
                cmd.Parameters.Add("?program", MySqlDbType.VarChar).Value = Program;
                cmd.Parameters.Add("?room", MySqlDbType.VarChar).Value = Room;
                cmd.Parameters.Add("?capacity", MySqlDbType.Int16).Value = Capacity;
                await cmd.ExecuteNonQueryAsync();
                return this;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static async Task<Course[]> GetDb(string query)
        {
            try
            {
                var dbcon = DBConnection.Instance();
                if (!dbcon.IsConnect()) return null;

                var cmd = new MySqlCommand(query, dbcon.Connection);
                var reader = await cmd.ExecuteReaderAsync();

                var courses = new List<Course>();
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        Id = (string)reader[0],
                        Name = (string)reader[1],
                        Program = (string)reader[2],
                        Room = (string)reader[3],
                        Capacity = (int)reader[4]
                    });
                }
                reader.Close();
                return courses.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
