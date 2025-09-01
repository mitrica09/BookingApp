namespace BookingApp.Models
{
    public class AssistantProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string JobTitle { get; set; }

    }
}
