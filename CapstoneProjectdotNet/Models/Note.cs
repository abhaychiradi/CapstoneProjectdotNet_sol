namespace CapstoneProjectdotNet.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //public int UserId { get; set; }// Entity Framework Core can infer the relationship based on the User navigation property
        public User User { get; set; }  
    }
}
