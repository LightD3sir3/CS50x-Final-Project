using System.ComponentModel.DataAnnotations;

namespace GameTracker.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public GameScore? Fortnite { get; set; }

        public GameScore? LeagueOfLegends { get; set; }

        public GameScore? CallOfDuty { get; set; }

        public bool IsLoggedIn { get; set; }
    }

    public class GameScore
    {
        public int? Kills { get; set; } = null;
        public string? Deaths { get; set; } = null;
        public string? Assists { get; set; } = null;
        public string? TotalGames { get; set; } = null;
    }
}
