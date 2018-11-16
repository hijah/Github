using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HoursRegisteringRestService
{
    public class Service1 : IService1
    {
        private static string connectionString = "Server=tcp:eventservertobias.database.windows.net,1433;Initial Catalog=EventMakerDB;Persist Security Info=False;User ID=TobiAdmin;Password=sadaWwd222!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #region Work
        public List<Work> GetListWork()
        {
            List<Work> workList = new List<Work>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"SELECT * FROM Work INNER JOIN Place ON Place.Id=FK_Place"; //TODO: implement User.
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Work work = new Work();
                    Place place = new Place();

                    work.Id = reader.GetInt32(0);
                    work.Date = reader.GetDateTime(1);
                    work.WorkHour = (double)reader.GetDecimal(2);
                    work.DriveHour = (double)reader.GetDecimal(3);
                    work.OverTime = (double)reader.GetDecimal(4);
                    work.TimeOff = (double)reader.GetDecimal(5);
                    //work.UserId = reader.GetInt32(6); //TODO: fix me
                    //work.PlaceId = reader.GetInt32(7); //TODO: fix me
                    work.InternJobNr = reader.GetString(8);
                    work.ExternJobNr = reader.GetString(9);
                    place.Id = reader.GetInt32(10);
                    place.PlaceName = reader.GetString(11);
                    place.Activated = reader.GetBoolean(12);

                    work.Place = place;

                    workList.Add(work);
                }
                conn.Close();
            }
            return workList;
        }

        public List<Work> GetWork(DateTime date, string name)
        {
            List<Work> workList = new List<Work>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"SELECT * FROM dbo.Work WHERE date = @date, name = @name"; //TODO: InnerJoin
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
                    work.UserId = reader.GetInt32(6); //TODO: make a list it can go from.
                    work.PlaceId = reader.GetInt32(7); //TODO: make a list it can go from.
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
                String sql = @"INSERT INTO dbo.Work(Date, Workhour, Drivehour, Overtime, Timeoff, UserId, PlaceId, InternJobNR, ExternJobNR) VALUES (@Date, @WorkHour, @DriveHour, @Overtime, @TimeOff, @UserId, @PlaceId, @InterJobNr, @ExternJobNr)"; //TODO: Fix after made logic to fix place and user.
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Date", work.Date);
                command.Parameters.AddWithValue("@WorkHour", work.WorkHour);
                command.Parameters.AddWithValue("@DriveHour", work.DriveHour);
                command.Parameters.AddWithValue("@Overtime", work.OverTime);
                command.Parameters.AddWithValue("@TimeOff", work.TimeOff);
                command.Parameters.AddWithValue("@UserId", work.UserId);
                command.Parameters.AddWithValue("@PlaceId", work.PlaceId);
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
                String sql = @"UPDATE dbo.Work SET Workhour = @WorkHour, Drivehour = @DriveHour, Overtime = @Overtime, Timeoff = @TimeOff, PlaceId = @PlaceId, InternJobNR = @InterJobNr, ExternJobNR = @ExternJobNr WHERE id = @id";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@WorkHour", work.WorkHour);
                command.Parameters.AddWithValue("@DriveHour", work.DriveHour);
                command.Parameters.AddWithValue("@Overtime", work.OverTime);
                command.Parameters.AddWithValue("@TimeOff", work.TimeOff);
                command.Parameters.AddWithValue("@PlaceId", "Fix");//TODO: Liste ting skal være done
                command.Parameters.AddWithValue("@InternJobNr", work.InternJobNr);
                command.Parameters.AddWithValue("@ExternJobNr", work.ExternJobNr);

                command.ExecuteNonQuery();
                conn.Close();
                return "Arbejdet er blevet opdateret";
            }
        }
        #endregion

        #region PlaceId
        public string PostPlace(Place place)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"INSERT INTO PlaceId(Name, Activated) VALUES (@Name, @Activated)";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Name", place.PlaceName);
                command.Parameters.AddWithValue("@Activated", place.Activated);

                command.ExecuteNonQuery();
                conn.Close();
                return place.PlaceName + " er blevet registreret i databasen";
            }
        }

        public List<Place> GetPlaces()
        {
            List<Place> placeList = new List<Place>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT * FROM Place";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Place place = new Place();

                    place.Id = reader.GetInt32(0);
                    place.PlaceName = reader.GetString(1);
                    place.Activated = reader.GetBoolean(2);

                    placeList.Add(place);
                }
                conn.Close();
            }

            return placeList;
        }
        #endregion

        #region UserId
        public User GetSpecificUser(string username)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"SELECT * FROM AppUser";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();

                    user.Id = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.status = reader.GetInt32(3);

                    userList.Add(user);
                }

                conn.Close();
            }
            return userList;
        }

        public string DeleteUser(string user)
        {
            throw new NotImplementedException();
        }

        public string PostUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                String sql = @"INSERT INTO AppUser(Username, Password, Status) VALUES (@Username, @Password, @Status)";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Status", user.status);

                command.ExecuteNonQuery();
                conn.Close();
                return user.Username + " er blevet oprettet";
            }
        } 
        #endregion
    }
}
