namespace HoursRegisteringRestService
{
    public class User
    {
        /*
         CREATE TABLE [dbo].[UserId]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Status] INT NULL
)
         */
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int status { get; set; }

        public User()
        {
        }

        public User(int id, string username, string email, int status)
        {
            Id = id;
            Username = username;
            Email = email;
            this.status = status;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Username)}: {Username}, {nameof(Email)}: {Email}, {nameof(status)}: {status}";
        }
    }
}