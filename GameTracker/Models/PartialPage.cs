namespace GameTracker.Models
{
    public class PartialPage
    {
        public string PageTitle { get; set; }
        public User User { get; set; } = new User();
    }
}
