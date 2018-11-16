using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HoursRegisteringRestService
{
    public class Service1 : IService1
    {
        private static string connectionString = "Server=tcp:eventservertobias.database.windows.net,1433;Initial Catalog=EventMakerDB;Persist Security Info=False;User ID=TobyAdmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Work> GetListWork()
        {
            List<Work> workList = new List<Work>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"SELECT * FROM dbo.Work INNER JOIN dbo.Place ON Place.Id = FK_Place";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Work work = new Work();
                    
                    work.Id = reader.GetInt32(0);
                    work.Date = reader.GetDateTime(1);
                    work.WorkHour = reader.GetFloat(2);
                    work.DriveHour = reader.GetFloat(3);
                    work.OverTime = reader.GetFloat(4);
                    work.TimeOff = reader.GetFloat(5);
                    work.User = reader.GetInt32(6); //TODO: make a list it can go from.
                    work.Place = reader.GetInt32(7); //TODO: make a list it can go from.
                    work.InternJobNr = reader.GetString(8);
                    work.ExternJobNr = reader.GetString(9);

                    workList.Add(work);
                }
                conn.Close();
            }
            return workList;
        }

        public List<Work> GetWork(DateTime date, string name)
        {
            List<Work> workList = new List<Work>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                String sql = @"SELECT * FROM dbo.Work WHERE date = @date, name = @name";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Work work = new Work();

                    work.Id = reader.GetInt32(0);
                    work.Date = reader.GetDateTime(1);
                    work.WorkHour = reader.GetFloat(2);
                    work.DriveHour = reader.GetFloat(3);
                    work.OverTime = reader.GetFloat(4);
                    work.TimeOff = reader.GetFloat(5);
                    work.User = reader.GetInt32(6); //TODO: make a list it can go from.
                    work.Place = reader.GetInt32(7); //TODO: make a list it can go from.
                    work.InternJobNr = reader.GetString(8);
                    work.ExternJobNr = reader.GetString(9);

                    workList.Add(work);
                }
                conn.Close();
            }
            return workList;
        }

        public string PostWork(Work work)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"INSERT INTO dbo.Work(Date, Workhour, Drivehour, Overtime, Timeoff, User, Place, InternJobNR, ExternJobNR) VALUES (@Date, @WorkHour, @DriveHour, @Overtime, @TimeOff, @User, @Place, @InterJobNr, @ExternJobNr)"; //TODO: Fix after made logic to fix place and user.
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Date", work.Date);
                command.Parameters.AddWithValue("@WorkHour", work.WorkHour);
                command.Parameters.AddWithValue("@DriveHour", work.DriveHour);
                command.Parameters.AddWithValue("@Overtime", work.OverTime);
                command.Parameters.AddWithValue("@TimeOff", work.TimeOff);
                command.Parameters.AddWithValue("@User", work.User); //TODO: make a list it can go from.
                command.Parameters.AddWithValue("@Place", work.Place); //TODO: make a list it can go from.
                command.Parameters.AddWithValue("@InternJobNr", work.InternJobNr);
                command.Parameters.AddWithValue("@ExternJobNr", work.ExternJobNr);

                command.ExecuteNonQuery();
                conn.Close();
                return work.WorkHour + "timers arbejde tilføjet";
            }
        }

        public string PutWork(Work work)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"UPDATE dbo.Work SET Workhour = @WorkHour, Drivehour = @DriveHour, Overtime = @Overtime, Timeoff = @TimeOff, Place = @Place, InternJobNR = @InterJobNr, ExternJobNR = @ExternJobNr WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@WorkHour", work.WorkHour);
                command.Parameters.AddWithValue("@DriveHour", work.DriveHour);
                command.Parameters.AddWithValue("@Overtime", work.OverTime);
                command.Parameters.AddWithValue("@TimeOff", work.TimeOff);
                command.Parameters.AddWithValue("@Place", "Fix");//TODO: Liste ting skal være done
                command.Parameters.AddWithValue("@InternJobNr", work.InternJobNr);
                command.Parameters.AddWithValue("@ExternJobNr", work.ExternJobNr);

                command.ExecuteNonQuery();
                conn.Close();
                return "Arbejdet er blevet opdateret";
            }
        }

        public string AddPlace(string place)
        {
            throw new NotImplementedException();
        }

        public User GetSpecificUser(string username)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public string DeleteUser(string user)
        {
            throw new NotImplementedException();
        }

        public string PostUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
