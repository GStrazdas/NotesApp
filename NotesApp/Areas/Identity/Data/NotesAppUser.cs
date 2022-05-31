using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NotesApp.Model;

namespace NotesApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the NotesAppUser class
public class NotesAppUser : IdentityUser
{
    public List<Note> Notes { get; set; } = new List<Note>();
    public List<Category> Categories { get; set; } = new List<Category>();
}

