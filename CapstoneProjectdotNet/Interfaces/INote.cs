using CapstoneProjectdotNet.Models;

namespace CapstoneProjectdotNet.Interfaces
{
    public interface INote
    {
        public bool CreateNote(Note note);

        public bool DeleteNote(int NoteId);

        public bool EditNote(Note note);

        public IEnumerable<Note> GetNotesOfUser(int UserId);
    }
}
