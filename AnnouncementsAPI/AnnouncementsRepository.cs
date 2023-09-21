namespace AnnouncementsAPI;

public class AnnouncementsRepository
{
    /**
     *  For the sample code, using a volatile data structure as
     *  data repository. In the real world, this would use the repository
     *  pattern to connect to a real database for persistence.
     */
    private static readonly SortedList<Guid, Announcement> Data = new SortedList<Guid, Announcement>();

    public AnnouncementsRepository()
    {
        //add some data
        var a1 = new Announcement("John Smith", "New Bug Found", "I found new Bug....");
        AddAnnouncement(a1);
    }
    
    public IEnumerable<Announcement> GetAnnouncements(int start, int length)
    {
        if (start > -1 && start < Data.Count)
        {
            return Data.Values.Skip(start).Take(length);
        }
        
        return Array.Empty<Announcement>();
    }
    
    public Announcement? GetAnnouncement(Guid id)
    {
        return Data.GetValueOrDefault(id);
    }

    public bool AnnouncementExists(Guid id)
    {
        return Data.ContainsKey(id);
    }

    public void AddAnnouncement(Announcement announcement)
    {
        Data.Add(announcement.Id, announcement);
    }

    public bool UpdateAnnouncement(Announcement announcement)
    {
        if (!Data.ContainsKey(announcement.Id)) return false; 
        
        Data.Remove(announcement.Id);
        Data.Add(announcement.Id, announcement);
        return true;
    }

    public bool DeleteAnnouncement(Announcement announcement)
    {
        if (!Data.ContainsKey(announcement.Id)) return false; 

        Data.Remove(announcement.Id);
        return true;
    }
}