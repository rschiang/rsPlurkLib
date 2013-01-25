using System;
using System.Collections.Generic;
using System.Text;

namespace RenRen.Plurk.Entities
{
    public class GetPlurkResponse
    {
        public Plurk plurk { get; set; }
        public User user { get; set; }
    }

    public class GetPlurksResponse
    {
        public Plurk[] plurks { get; set; }
        public Dictionary<int, User> plurk_users { get; set; }
    }

    public class GetResponseResponse
    {
        public Dictionary<int, User> friends { get; set; }
        public int responses_seen { get; set; }
        public Response[] responses { get; set; }
    }

    public class ErrorResponse
    {
        public string error_text { get; set; }
    }
}
