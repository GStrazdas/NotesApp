namespace NotesApp.Model
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public int? CategoryId { get; set; }
        public string NotesAppUserId { get; set; }  //  pagalvoti ar reikia
    }
}
