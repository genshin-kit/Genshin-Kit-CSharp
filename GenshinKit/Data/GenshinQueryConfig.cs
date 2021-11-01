using System.Collections.Generic;

namespace GenshinKit.Data
{
    public class GenshinQueryConfig
    {
        internal string Ds { get; set; }

        /// <summary>
        /// Version of hoyolab
        /// </summary>
        internal string Version { get; set; }

        internal IEnumerable<string> Cookies { get; set; }

        internal string Uid { get; set; }
    }
}