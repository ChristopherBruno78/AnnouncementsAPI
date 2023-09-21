namespace AnnouncementsAPI;

public class Announcement
{
    public Announcement(string author, string subject, string content)
    {
        Id = Guid.NewGuid();
        Date = DateOnly.FromDateTime(DateTime.Now);
        Author = author;
        Subject = subject;
        BodyContent = content;
    }

    public Guid Id { get; }
    
    public DateOnly Date { get; set; }

    public string? Author { get; set; }

    public string? Subject { get; set; }

    public string? BodyContent { get; set; }
}