using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Flurl;
using GenshinKit.Data;
using GenshinKit.Data.Request;
using GenshinKit.Query;
using GenshinKit.Utility;

namespace GenshinKin.Runtime
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            //https://api-os-takumi.mihoyo.com/game_record/genshin/api/index?server=os_euro&role_id=709195224
            //
            var index = await "109195224"
                .WithGenshinCookies(Confidentiality.GetCookies())
                .WithLanguage(GenshinLanguage.en_us)
                .GetGenshinIndexAsync();
            Console.WriteLine(index.ToJsonString());
        }

        public static string Output<T>(this IEnumerable<T> sequence)
        {
            var re = sequence.Aggregate(string.Empty, (current, x1) => current + x1);

            return re;
        }
    }
}