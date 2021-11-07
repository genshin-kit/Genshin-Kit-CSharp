using System;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using GenshinKit.Data;
using GenshinKit.Data.Request;
using GenshinKit.Query;
using GenshinKit.Utility;

namespace GenshinKin.Runtime
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //https://api-os-takumi.mihoyo.com/game_record/genshin/api/index?server=os_euro&role_id=709195224

            var index = await "709195224"
                .WithGenshinCookies(Confidentiality.GetCookies())
                .WithLanguage(GenshinLanguage.ja_jp)
                .GetGenshinIndexAsync();
            Console.WriteLine(index.ToJsonString());
        }
    }
}