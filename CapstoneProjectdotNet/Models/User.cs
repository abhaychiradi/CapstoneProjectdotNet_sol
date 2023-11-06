namespace CapstoneProjectdotNet.Models
{
    public class User
    {
        public int UserId { get; set; }
        public String Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
