using System;
using System.Collections.Generic;
using System.Text;

namespace RenRen.Plurk.Entities
{
    /// <summary>
    /// Contains information of a Plurk user.
    /// </summary>
    public class User
    {
        public int id { get; set; }
        public string nick_name { get; set; }
        public string display_name { get; set; }
        public bool has_profile_image { get; set; }
        public int? avatar { get; set; }
        public string location { get; set; }
        public string default_lang { get; set; }
        public DateTime? date_of_birth { get; set; }
        public int bday_privacy { get; set; }
        public string full_name { get; set; }
        public int gender { get; set; }
        public string page_title { get; set; }
        public float karma { get; set; }
        public int recruited { get; set; }
        public string relationship { get; set; }
    }
}
