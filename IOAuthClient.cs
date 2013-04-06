using System;
using System.Collections.Generic;
using System.Text;

namespace RenRen.Plurk
{
    /// <summary>
    /// Defines methods to perform basic 3-step OAuth authentication process.
    /// </summary>
    public interface IOAuthClient
    {
        /// <summary>
        /// Retrieves a temporary token from server and stores it in the client.
        /// </summary>
        void GetRequestToken();

        /// <summary>
        /// Retrieves authorization URL after a request token has been obtained.
        /// </summary>
        /// <returns>An URL pointing to the authorization page.</returns>
        string GetAuthorizationUrl();

        /// <summary>
        /// Exchanges a temporary token for a permanent token using the specified verifier.
        /// </summary>
        /// <param name="verifier">The verifier provided by server after user granted access.</param>
        void GetAccessToken(string verifier);

        /// <summary>
        /// Gets or sets the token container the client uses.
        /// </summary>
        IOAuthToken Token { get; set; }
    }

    /// <summary>
    /// Defines properties to access OAuth token.
    /// </summary>
    public interface IOAuthToken
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the token secret.
        /// </summary>
        string Secret { get; set; }
    }
}
