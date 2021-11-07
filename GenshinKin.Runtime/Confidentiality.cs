using System.Collections.Generic;
using System.IO;
using System.Linq;
using AHpx.Extensions.StringExtensions;
using GenshinKit.Data.Request;

namespace GenshinKin.Runtime
{
    public static class Confidentiality
    {
        public const string ConfidentialPath = @"C:\Users\ahpx\Desktop\Confidentiality.json";
        
        /// <summary>
        /// Sequence of GenshinConfig objects
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<GenshinCookie> GetCookies()
        {
            var json = File.ReadAllText(ConfidentialPath).ToJArray();

            return json.Select(x => x.ToObject<GenshinCookie>());
        }
    }
}