using System;

namespace Autocomplete.Business.Models
{
    public class City : Entity
    {
        
        public string name { get; set; }
        public string country { get; set; }
        public string subcountry { get; set; }
        public string geonameid { get; set; }
        public string original { get; set; }
        public City()
        {

        }
        public City(string[] str)
        {
            this.name = str[0];
            this.country = str[1]; 
            this.subcountry = str[2]; 
            this.geonameid = str[3];
            this.original = string.Join(",",str);
        }

        public City(string s)
        {
            string[] str;
            if (s.Contains(","))
                str = s.Split(",");
            else
                str = s.Split(";");
            this.original = s;
            this.name = str[0];
            this.country = str[1];
            this.subcountry = str[2];
            this.geonameid = str[3];
        }

        public bool IsOk()
        {
            if (string.IsNullOrEmpty(name.Trim()))
                return false;
            if (string.IsNullOrEmpty(country.Trim()))
                return false;
            if (string.IsNullOrEmpty(subcountry.Trim()))
                return false;
            if (string.IsNullOrEmpty(geonameid.Trim()))
                return false;
            return true;
        }

    }
}
