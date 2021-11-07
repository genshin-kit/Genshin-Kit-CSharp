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

            var index = await "199246390"
                .WithGenshinCookie(
                    "UM_distinctid=17cb8647a207eb-0c5a5af248f86c-3e604809-144000-17cb8647a217cb; ltoken=K2GNJaOMqmZ6loC5L7MrsPpjSmcHUXKT26jeNVo1; ltuid=157133154; _gid=GA1.2.1996259294.1635600354; CNZZDATA1275023096=2024938131-1635173839-%7C1635649319; _gat=1")
                .WithGenshinCookie(new GenshinCookie(
                    "UM_distinctid=17cb8647a207eb-0c5a5af248f86c-3e604809-144000-17cb8647a217cb; ltoken=f7wcNBqPLmFW6ZWiKe8T91L516wKdZ9i6oMiiWqj; ltuid=88723574; _gid=GA1.2.864923146.1636272067; _gat_gtag_UA_115635327_39=1"))
                .WithLanguage(GenshinLanguage.ja_jp)
                .GetGenshinIndexAsync();
            Console.WriteLine(index.ToJsonString());
        }
    }
}