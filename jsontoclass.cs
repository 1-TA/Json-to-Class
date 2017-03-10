using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace JsonDomain
{
    public class Location
    {
    //This is the class which have all the properties of the json output (last line of this class). 
    //You can comment the outputs you dont require 
        //public string ip { get; set; }
        //public string country_code { set; get; }
        //public string country_name { set; get; }
        public string region_code { set; get; }
        public string region_name { set; get; }
        //public string city { set; get; }
        //public string zip_code { set; get; }
        //public string time_zone { set; get; }
        //public string latitude { set; get; }
        //public string longitude { set; get; }
        //public string metro_code { set; get; }

        //{"ip":"54.54.54.54","country_code":"US","country_name":"United States","region_code":"NJ","region_name":"New Jersey","city":"Woodbridge","zip_code":"07095","time_zone":"America/New_York","latitude":40.5576,"longitude":-74.2846,"metro_code":501}
    }
    
    public string callGeo(string ipAddress)
    {
        JsonDomain.Location loc= new WinClient.Location();
        var client = new WebClient();
        
        // The below url returns the geo location of an IP address. 
        var output = client.DownloadString("http://freegeoip.net/json/" + ipAddress);
        
        //Creating a json serializer of the class type mentioned above
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(JsonDomain.Location));
        
        //reading the output to the class
        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(output)))
        {
            loc = (JsonDomain.Location)serializer.ReadObject(ms);
        }

        return loc.region_code.ToString();
      }
}
