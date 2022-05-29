﻿namespace NotesApp.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Note> Note { get; set; } = new List<Note>();
    }
}
