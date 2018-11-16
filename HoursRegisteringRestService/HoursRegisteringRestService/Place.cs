namespace HoursRegisteringRestService
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public bool Activated { get; set; }

        public Place()
        {
        }

        public Place(int id, string placeName, bool activated)
        {
            Id = id;
            PlaceName = placeName;
            Activated = activated;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(PlaceName)}: {PlaceName}, {nameof(Activated)}: {Activated}";
        }
    }
}