using System;

namespace Autocomplete.Business.Models
{
    public class City : Entity
    {
        
        public string name { get; set; }
        public string country { get; set; }
        public string subcountry { get; set; }
        public string geonameid { get; set; }
        public string Original { get; set; }
        public City()
        {

        }
        public City(string[] str)
        {
            this.name = str[0];
            this.country = str[1]; 
            this.subcountry = str[2]; 
            this.geonameid = str[3];
            this.Original = string.Join(",",str);
        }

        public City(string s)
        {
            var str = s.Split(",");
            this.Original = s;
            this.name = str[0];
            this.country = str[1];
            this.subcountry = str[2];
            this.geonameid = str[3];
        }



    }
}
