using System.Collections.Generic;
using GenshinKit.Data.Request;
using GenshinKit.Utility;

namespace GenshinKit.Data
{
    public class GenshinQueryConfig
    {
        /// <summary>
        /// 0: Chinese, 1: Oversea
        /// </summary>
        internal GenshinDynamic[] Dynamic { get; } = 
        { 
            new(),
            new() 
        };

        internal string Ds => Uid.IsOversea() ? Dynamic[1].Ds : Dynamic[0].Ds;

        /// <summary>
        /// Version of hoyolab
        /// </summary>
        internal string Version => Uid.IsOversea() ? Dynamic[1].Version : Dynamic[0].Version;

        internal IEnumerable<GenshinCookie> Cookies { get; set; }

        internal string Uid { get; set; }

        public GenshinLanguage? Language { get; set; }
    }
}