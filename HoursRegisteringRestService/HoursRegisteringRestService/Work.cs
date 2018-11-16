using System;

namespace HoursRegisteringRestService
{
/*
CREATE TABLE [dbo].[Work]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME NULL, 
    [Workhour] DECIMAL NULL, 
    [Drivehour] DECIMAL NULL, 
    [Overtime] DECIMAL NULL, 
    [Timeoff] DECIMAL NULL, 
    [FK_User] INT NULL, 
    [FK_Place] INT NULL, 
    [InternJobNR] NVARCHAR(50) NULL, 
    [EksternJobNR] NVARCHAR(50) NULL
)
*/

    public class Work
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double WorkHour { get; set; }
        public Double DriveHour { get; set; }
        public Double OverTime { get; set; }
        public Double TimeOff { get; set; }
        public string InternJobNr { get; set; }
        public string ExternJobNr { get; set; }
        public int PlaceId { get; set; }
        public int UserId { get; set; }
        public Place Place { get; set; }
        public User User { get; set; }

        public Work()
        {
        }

        public Work(int id, DateTime date, double workHour, double driveHour, double overTime, double timeOff, string internJobNr, string externJobNr, int placeId, int userId)
        {
            Id = id;
            Date = date;
            WorkHour = workHour;
            DriveHour = driveHour;
            OverTime = overTime;
            TimeOff = timeOff;
            InternJobNr = internJobNr;
            ExternJobNr = externJobNr;
            PlaceId = placeId;
            UserId = userId;
        }

        public Work(int id, DateTime date, double workHour, double driveHour, double overTime, double timeOff, string internJobNr, string externJobNr, int placeId, int userId, Place place, User user)
        {
            Id = id;
            Date = date;
            WorkHour = workHour;
            DriveHour = driveHour;
            OverTime = overTime;
            TimeOff = timeOff;
            InternJobNr = internJobNr;
            ExternJobNr = externJobNr;
            PlaceId = placeId;
            UserId = userId;
            Place = place;
            User = user;
        }

        public Work(int id, DateTime date, double workHour, double driveHour, double overTime, double timeOff, string internJobNr, string externJobNr, Place place, User user)
        {
            Id = id;
            Date = date;
            WorkHour = workHour;
            DriveHour = driveHour;
            OverTime = overTime;
            TimeOff = timeOff;
            InternJobNr = internJobNr;
            ExternJobNr = externJobNr;
            Place = place;
            User = user;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Date)}: {Date}, {nameof(WorkHour)}: {WorkHour}, {nameof(DriveHour)}: {DriveHour}, {nameof(OverTime)}: {OverTime}, {nameof(TimeOff)}: {TimeOff}, {nameof(InternJobNr)}: {InternJobNr}, {nameof(ExternJobNr)}: {ExternJobNr}, {nameof(PlaceId)}: {PlaceId}, {nameof(UserId)}: {UserId}";
        }
    }
}