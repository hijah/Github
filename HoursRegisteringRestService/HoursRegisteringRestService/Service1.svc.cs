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

        #region GetListWork

        public List<Work> GetListWork()
        {
            List<Work> workList = new List<Work>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"SELECT * FROM dbo.Work";
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

        #endregion

        #region GetSpecificWork

        public List<Work> GetWork(DateTime date, string name)
        {
            List<Work> workList = new List<Work>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();
                String sql = @"SELECT * FROM dbo.Work WHERE date = @date AND name = @name";
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

        #endregion

        #region PostWork

        public string PostWork(Work work)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"INSERT INTO dbo.Work()"; //TODO: Fix after made logic to fix place and user.
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@date", work.Date);
                command.Parameters.AddWithValue("@workHour", work.WorkHour);
                command.Parameters.AddWithValue("@driveHour", work.DriveHour);
                command.Parameters.AddWithValue("@overTime", work.OverTime);
                command.Parameters.AddWithValue("@timeOff", work.TimeOff);
                command.Parameters.AddWithValue("@user", work.User); //TODO: make a list it can go from.
                command.Parameters.AddWithValue("@place", work.Place); //TODO: make a list it can go from.
                command.Parameters.AddWithValue("@internJobNr", work.InternJobNr);
                command.Parameters.AddWithValue("@externJobNr", work.ExternJobNr);

                command.ExecuteNonQuery();
                conn.Close();
                return work.WorkHour + "timers arbejde tilføjet";
            }
        }

        #endregion

        public string PutWork()
        {
            throw new NotImplementedException();
        }
    }
}
