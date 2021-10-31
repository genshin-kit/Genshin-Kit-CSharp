using System;
using System.Runtime.Serialization;

namespace GenshinKit.Data.Exceptions
{
    [Serializable]
    public class GenshinQueryException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public GenshinQueryException()
        {
        }

        public GenshinQueryException(string message) : base(message)
        {
        }

        public GenshinQueryException(string message, Exception inner) : base(message, inner)
        {
        }

        protected GenshinQueryException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}