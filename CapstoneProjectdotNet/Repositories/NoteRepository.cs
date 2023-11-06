using CapstoneProjectdotNet.Data;
using CapstoneProjectdotNet.Interfaces;
using CapstoneProjectdotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProjectdotNet.Repositories
{
    public class NoteRepository : INote
    {
        public DataContext _context;
        private readonly UserRepository _userRepository;

        public NoteRepository(DataContext context, UserRepository userRepository) 
        {
            _context = context;
            _userRepository = userRepository;
        }

        public bool CreateNote(Note note)
        {
           _context.Add(note);
            return Save();
        }

        public bool DeleteNote(int NoteId)
        {
            var note = _context.Notes.Where(x => x.NoteId == NoteId).FirstOrDefault();     
            if(note != null)
            {
                _context.Notes.Remove(note);
            }   
            return Save();
        }

        public bool EditNote(Note note)
        {
           _context.Update(note);
            return Save();
        }

        public IEnumerable<Note> GetNotesOfUser(int UserId)
        {
            var user = _userRepository.GetUser(UserId);
            var notes = _context.Notes.Where(x => x.User==user).ToList();   
            return notes;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
