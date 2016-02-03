using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SelectService" in code, svc and config file together.
public class SelectService : ISelectService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public List<string> GetArtists()
    {
        List<string> artists = new List<string>();
        var art = from a in ste.Artists
                  select new { a.ArtistName };
        foreach (var v in art)
        {
            artists.Add(v.ArtistName.ToString());
        }

        return artists;
    }

    public List<string> GetShows()
    {
        List<string> shows = new List<string>();
        var sho = from s in ste.Shows
                  select new { s.ShowName };
        foreach (var v in sho)
        {
            shows.Add(v.ShowName.ToString());
        }

        return shows;
    }

    public List<string> GetVenues()
    {
        List<string> venues = new List<string>();
        var venu = from ve in ste.Venues
                   select new { ve.VenueName };
        foreach (var v in venu)
        {
            venues.Add(v.VenueName.ToString());
     
        }

        return venues;
    }

    public List<ReviewInfo> GetShowByArtist(string artistName)
    {
        List<ReviewInfo> review = new List<ReviewInfo>();
        var rev = from s in ste.Shows
                  from sd in ste.ShowDetails
                  from ve in ste.Venues
                  where sd.Artist.ArtistName.Equals(artistName)
                  select new { s.ShowName, s.ShowDate, s.ShowTime, ve.VenueName };
        foreach (var v in rev)
        {
            ReviewInfo info = new ReviewInfo();
            info.ShowName = v.ShowName;
            info.ShowDate = v.ShowDate.ToString();
            info.ShowTime = v.ShowTime.ToString();
            info.VenueName = v.VenueName;
            review.Add(info);

        }

        return review;
    }

    public List<ReviewInfo> GetShowByVenue(string venueName)
    {
        List<ReviewInfo> review = new List<ReviewInfo>();
        var rev = from ve in ste.Shows
                   where ve.Venue.VenueName.Equals(venueName)
                   select new { ve.ShowName, ve.ShowDate, ve.ShowTime };
        foreach (var v in rev)
        {
            ReviewInfo info = new ReviewInfo();
            info.ShowName = v.ShowName;
            info.ShowDate = v.ShowDate.ToString();
            info.ShowTime = v.ShowTime.ToString();
            review.Add(info);
        }

        return review;
    }
}
