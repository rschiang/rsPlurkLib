using System;
using System.Collections.Generic;
using System.Text;

namespace RenRen.Plurk
{
    /// <summary>Occurs when Plurk threw an error during a request.</summary>
    [Serializable]
    public class PlurkException : ApplicationException
    {
        public PlurkException()
            : base()
        {
        }

        public PlurkException(string message)
            : base(message)
        {
        }

        public PlurkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    /// <summary>Occurs when the specified Plurk was not found during a request.</summary>
    [Serializable]
    public class PlurkNotFoundException : PlurkException
    {
        public PlurkNotFoundException()
            : base("The plurk requested is not found. It could have been deleted by the owner")
        {
        }

        public PlurkNotFoundException(string message)
            : base(message)
        {
        }

        public PlurkNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }


    /// <summary>Occurs when the current user has no permission to perform the specified request.</summary>
    [Serializable]
    public class PlurkPermissionException : PlurkException
    {
        public PlurkPermissionException()
            : base("The current user has no permission to the requested plurk")
        {
        }

        public PlurkPermissionException(string message)
            : base(message)
        {
        }

        public PlurkPermissionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }


    /// <summary>Occurs when the a request was rejected by plurk due to anti-flood mechanism.</summary>
    [Serializable]
    public class PlurkFloodException : PlurkException
    {
        public PlurkFloodException()
            : base("The request was rejected by Plurk anti-flood system")
        {
        }

        public PlurkFloodException(string message)
            : base(message)
        {
        }

        public PlurkFloodException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
