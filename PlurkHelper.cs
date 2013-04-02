using System;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RenRen.Plurk
{
    /// <summary>
    /// Provides functionalities of interacting with Plurk.
    /// </summary>
    public sealed class PlurkHelper
    {
        #region "Constructor"
        public PlurkHelper()
        {
            instance = new OAuthInstance();
            // You can assign your token here if you aren't making an interactive client
            // e.g. instance.Token = new OAuthToken(content, secret, OAuthTokenType.Permanent);
        }
        #endregion

        #region "Private Fields"
        private OAuthInstance instance;
        #endregion

        #region "Properties"
        /// <summary>
        /// Gets the OAuth client implementation used by this instance.
        /// </summary>
        public IOAuthClient Client
        {
            get { return instance; }
        }
        #endregion

        #region "Timeline/"

        public Entities.GetPlurkResponse GetPlurk(long plurk_id)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("plurk_id", plurk_id.ToString());

            string req = instance.SendRequest("Timeline/getPlurk", nvc);
            return CreateEntity<Entities.GetPlurkResponse>(req);
        }

        public Entities.GetPlurksResponse GetUnreadPlurks()
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("limit", "200");

            string req = instance.SendRequest("Timeline/getUnreadPlurks", nvc);
            return CreateEntity<Entities.GetPlurksResponse>(req);
        }

        public Entities.GetPlurksResponse GetPublicPlurks(int userId, DateTime offset, 
                                                    PlurkType type = PlurkType.All, int limit = 20)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("user_id", userId.ToString());
            nvc.Add("limit", limit.ToString());
            if (offset <= DateTime.Now)
                nvc.Add("offset", offset.ToString("yyyy-MM-ddTHH:mm:ss"));

            switch (type) {
                case PlurkType.MyPlurks:
                    nvc.Add("filter", "only_user"); break;
                case PlurkType.RespondedPlurks:
                    nvc.Add("filter", "only_responded"); break;
                case PlurkType.PrivatePlurks:
                    nvc.Add("filter", "only_private"); break;
                case PlurkType.FavoritePlurks:
                    nvc.Add("filter", "only_favorite"); break;
            }

            string req = instance.SendRequest("Timeline/getPublicPlurks", nvc);
            return CreateEntity<Entities.GetPlurksResponse>(req);
        }

        public void AddPlurk(string qualifier, string message)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("qualifier", qualifier);
            nvc.Add("content", message);

            string req = instance.SendRequest("Timeline/plurkAdd", nvc);
        }

        public void MutePlurks(long[] plurk_ids)
        {
            NameValueCollection nvc = new NameValueCollection();

            StringBuilder sb = new StringBuilder();
            string prefix = "[";
            foreach (long id in plurk_ids)
                { sb.Append(prefix).Append(id); prefix = ","; }
            sb.Append("]");
            nvc.Add("ids", sb.ToString());

            string req = instance.SendRequest("Timeline/mutePlurks", nvc);
        }

        #endregion

        #region "Responses/"

        public void AddResponse(long plurk_id, string qualifier, string message)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("qualifier", qualifier);
            nvc.Add("content", message);
            nvc.Add("plurk_id", plurk_id.ToString());

            string req = instance.SendRequest("Responses/responseAdd", nvc);
        }

        public Entities.GetResponseResponse GetResponses(long plurk_id)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("plurk_id", plurk_id.ToString());

            string req = instance.SendRequest("Responses/get", nvc);
            return CreateEntity<Entities.GetResponseResponse>(req);
        }

        #endregion

        #region "FriendsFans/"

        public IEnumerator<Entities.User> EnumerateFriends(int userId)
        {
            int offset = 0;
            do
            {
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("user_id", userId.ToString());
                nvc.Add("limit", "25");
                if (offset > 0)
                    nvc.Add("offset", offset.ToString());

                string req = instance.SendRequest("FriendsFans/getFriendsByOffset", nvc);
                Entities.User[] users = new Entities.User[] {};

                users = CreateEntity<Entities.User[]>(req);
                offset += users.Length;
                if (users.Length <= 0) break;

                foreach (Entities.User u in users)
                    yield return u;

            } while (offset > 0);
        }

        #endregion

        #region "Private Functions"

        private string SendAPIRequest(string uri, NameValueCollection param)
        {
            try
            {
                return instance.SendRequest(uri, param);
            }
            catch (OAuthRequestException ex)
            {
                try
                {
                    Entities.ErrorResponse err =
                             JsonConvert.DeserializeObject<Entities.ErrorResponse>(ex.ResponseData);
                    if (err.error_text == "Plurk not found")
                        throw new PlurkNotFoundException();
                    else if (err.error_text == "No permissions")
                        throw new PlurkPermissionException();
                    else if (err.error_text.StartsWith("anti-flood-"))
                        throw new PlurkFloodException();
                    else
                        throw new PlurkException(
                            String.Format("Plurk rejected the request due to {0}.", err.error_text));
                }
                catch (JsonSerializationException) {} throw;
            }
        }

        private T CreateEntity<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (JsonSerializationException ex)
            {
                var err = new InvalidCastException("An error occured parsing JSON", ex);
                err.Data.Add("RequestEntity", Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString)));
                throw err;
            }
        }

        #endregion
    }
}
