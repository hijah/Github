namespace HoursRegisteringRestService
{
    public class User
    {
        /*
         CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [Status] INT NULL
)
         */
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool status { get; set; }

        public User()
        {
        }

        public User(int id, string username, string password, bool status)
        {
            Id = id;
            Username = username;
            Password = password;
            this.status = status;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}, {nameof(status)}: {status}";
        }
    }
}