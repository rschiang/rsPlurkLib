using System;
using System.Collections.Generic;
using System.Text;

namespace RenRen.Plurk
{
    /// <summary>Occurs when an OAuth request encounters an error.</summary>
    [Serializable]
    public class OAuthException : ApplicationException
    {
        public OAuthException()
            : base("An error occured during OAuth authentication")
        {
        }

        public OAuthException(string message)
            : base(message)
        {
        }

        public OAuthException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>Occurs when an OAuth request encounters authorization error (401).</summary>
    [Serializable]
    public class OAuthAuthorizationException : OAuthException
    {
        public OAuthAuthorizationException()
            : base("OAuth authorization error")
        {
        }

        public OAuthAuthorizationException(string message)
            : base(message)
        {
        }

        public OAuthAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>Occurs when an OAuth request was rejected due to 
    /// nonce or timestamp invalidity.</summary>
    [Serializable]
    public class OAuthNonceException : OAuthException
    {
        public OAuthNonceException()
            : base("Invalid nonce or timestamp in an OAuth request")
        {
        }

        public OAuthNonceException(string nonce, string timestamp)
            : this()
        {
            Nonce = nonce;
            Timestamp = timestamp;
            Data.Add("Nonce", nonce);
            Data.Add("Timestamp", timestamp);
        }

        /// <summary>Gets the last known nonce of the OAuthInstance.</summary>
        public string Nonce { get; private set; }

        /// <summary>Gets the last known timestamp of the OAuthInstance.</summary>
        public string Timestamp { get; private set; }
    }

    /// <summary>Occurs when an OAuth request encounters an error. 
    /// This class is thrown only when the server returned further 
    /// information during 400 Bad Request.</summary>
    [Serializable]
    public class OAuthRequestException : OAuthException
    {
        public OAuthRequestException(string response)
            : base("Bad OAuth request")
        {
            ResponseData = response;
            Data.Add("ResponseData", response);
        }

        public OAuthRequestException(string response, Exception innerException)
            : base("Bad OAuth request", innerException)
        {
            ResponseData = response;
        }

        /// <summary>Gets the text representation of server response.</summary>
        public string ResponseData { get; private set; }
    }
}
