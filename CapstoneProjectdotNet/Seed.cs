using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using CapstoneProjectdotNet.Models;
using CapstoneProjectdotNet.Data;

namespace CapstoneProjectdotNet
{
    

    public class Seed
    {
       
            private readonly DataContext context;
            public Seed(DataContext context)
            {
                this.context = context;
            }
            public void SeedDataContext()
            {
                // Check if the Users and Notes tables are already populated
                if (context.Users.Any() || context.Notes.Any())
                {
                    return; // Database has been seeded
                }

                // Create initial data for Users
                var users = new List<User>
            {
                new User { Name = "John Doe", Email = "john@example.com", Password = "password123" },
                new User { Name = "Alice Smith", Email = "alice@example.com", Password = "securepass" }
            };
                context.Users.AddRange(users);
                context.SaveChanges();

                // Create initial data for Notes
                var notes = new List<Note>
            {
                new Note { Title = "Important Note 1", Content = "This is an important note.", User = users[0] },
                new Note { Title = "Meeting Notes 1", Content = "Notes from the meeting.", User = users[1] },
                new Note { Title = "Important Note 2", Content = "This is another important note.", User = users[0] },
                new Note { Title = "Meeting Notes 2", Content = "More notes from the meeting.", User = users[1] }
            };
                context.Notes.AddRange(notes);
                context.SaveChanges();
            }
     }

}
