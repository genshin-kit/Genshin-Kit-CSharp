using System.Collections.Generic;
using GenshinKit.Data.Request;
using GenshinKit.Utility;

namespace GenshinKit.Data
{
    public class GenshinQueryConfig
    {
        internal string Ds { get; set; }
        /// <summary>
        /// Version of hoyolab
        /// </summary>
        internal string Version { get; set; }

        internal IEnumerable<GenshinCookie> Cookies { get; set; }

        internal string Uid { get; set; }

        public GenshinLanguage? Language { get; set; }
    }
}