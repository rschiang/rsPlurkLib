using System;
using System.Collections.Generic;

// Contains Plurk and Response. PlurkBase 
namespace RenRen.Plurk.Entities
{
    /// <summary>
    /// Define common properties shared between plurks and responses.
    /// </summary>
    /// <remarks>Reserved for some convenience case where it's not important 
    /// whether a plurk is either a standalone plurk or as a response.</remarks>
    public class PlurkBase
    {
        public long plurk_id { get; set; }
        public string qualifier { get; set; }
        public string qualifier_translated { get; set; }
        public int user_id { get; set; }
        public DateTime posted { get; set; }
        public string content { get; set; }
        public string content_raw { get; set; }
        public string lang { get; set; }
    }

    /// <summary>
    /// Represents a plurk.
    /// </summary>
    public class Plurk : PlurkBase
    {
        public int is_unread { get; set; }
        public int plurk_type { get; set; }
        public int owner_id { get; set; }
        public int no_comments { get; set; }
        public int response_count { get; set; }
        public int responses_seen { get; set; }
        public string limited_to { get; set; }
        public bool favorite { get; set; }
        public int favorite_count { get; set; }
        public int[] favorers { get; set; }
        public bool replurkable { get; set; }
        public bool replurked { get; set; }
        public string replurker_id { get; set; }
        public int replurkers_count { get; set; }
        public int[] replurkers { get; set; }
    }

    /// <summary>
    /// Represents a plurk response.
    /// </summary>
    public class Response : PlurkBase
    {
        public long id { get; set; }
    }
}
