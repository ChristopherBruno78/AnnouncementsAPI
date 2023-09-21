using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnouncementsController : ControllerBase
{
    private readonly AnnouncementsRepository _repository = new AnnouncementsRepository();
    private readonly ILogger<AnnouncementsController> _logger;

    public AnnouncementsController(ILogger<AnnouncementsController> logger)
    {
        _logger = logger;
    }

    [HttpPut(Name = "UpdateAnnouncement")]
    public bool Update(Guid id, string author, string subject, string content)
    {
        var announcement = _repository.GetAnnouncement(id);
        if (announcement == null) return false;
        announcement.Author = author;
        announcement.Subject = subject;
        announcement.BodyContent = content;
        return _repository.UpdateAnnouncement(announcement); 
    }

    [HttpDelete(Name = "DeleteAnnouncement")]
    public bool Delete(Guid id)
    {
        var announcement = _repository.GetAnnouncement(id);
        return announcement != null && _repository.DeleteAnnouncement(announcement);
    }

    [HttpPost(Name = "CreateAnnouncement")]
    public Announcement Create(string author, string subject, string content)
    {
        var announcement = new Announcement(author, subject, content); 
        _repository.AddAnnouncement(announcement);
        return announcement;
    }

    [HttpGet(Name = "GetAnnouncements")]
    public IEnumerable<Announcement> Get(int start, int length)
    {
        return _repository.GetAnnouncements(start, length);
    }
}