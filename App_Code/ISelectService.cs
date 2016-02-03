using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISelectService" in both code and config file together.
[ServiceContract]
public interface ISelectService
{
    [OperationContract]
    List<string> GetArtists();
    
    [OperationContract]
    List<string> GetShows();

    [OperationContract]
    List<string> GetVenues();

    [OperationContract]
    List<ReviewInfo> GetShowByArtist(string artistName);

    [OperationContract]
    List<ReviewInfo> GetShowByVenue(string venueName);

}

[DataContract]
public class ReviewInfo
{
    [DataMember]
    public string ArtistName{set; get;}

    [DataMember]
    public string VenueName{set; get;}

    [DataMember]
    public string ShowName{set; get;}

    [DataMember]
    public string ShowDate{set; get;}

    [DataMember]
    public string ShowTime{set; get;}


}
