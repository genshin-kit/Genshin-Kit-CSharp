using System;
using GenshinKit.Data;

namespace GenshinKit.Utility
{
    public static class RequestHelper
    {
        /// <summary>
        /// Get endpoint of genshin query api that distinguished by specific server region
        /// </summary>
        /// <param name="server">Various of genshin server specification</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string GetGenshinApiEndpoint(this GenshinServer server)
        {
            return server switch
            {
                GenshinServer.os_euro
                    or GenshinServer.os_asia
                    or GenshinServer.os_usa
                    or GenshinServer.os_cht => "https://bbs-api-os.mihoyo.com/game_record/genshin/api/",
                GenshinServer.cn_gf01
                    or GenshinServer.cn_qd01 => "https://api-takumi.mihoyo.com/game_record/app/genshin/api/",
                _ => throw new ArgumentOutOfRangeException(nameof(server), server, null)
            };
        }

        /// <summary>
        /// Distinguish diverse genshin server by player's uid
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static GenshinServer GetGenshinServer(this string uid)
        {
            return Convert.ToInt32(uid[0].ToString()) switch
            {
                1 or 2 => GenshinServer.cn_gf01,
                5 => GenshinServer.cn_qd01,
                6 => GenshinServer.os_usa,
                7 => GenshinServer.os_euro,
                8 => GenshinServer.os_asia,
                9 => GenshinServer.os_cht,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>
        /// Distinguish genshin server type(international(oversea) server or Chinese server)
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static GenshinServerType GetGenshinServerType(this string uid)
        {
            return uid.GetGenshinServer().GetGenshinServerType();
        }

        /// <summary>
        /// Check if a uid belongs to oversea servers
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool IsOversea(this string uid)
        {
            return uid.GetGenshinServerType() == GenshinServerType.Oversea;
        }
        
        /// <summary>
        /// Check if a uid belongs to chinese servers
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static bool IsChinese(this string uid)
        {
            return uid.GetGenshinServerType() == GenshinServerType.Chinese;
        }

        /// <summary>
        /// Distinguish genshin server type(international(oversea) server or Chinese server)
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static GenshinServerType GetGenshinServerType(this GenshinServer server)
        {
            return server switch
            {
                GenshinServer.os_euro
                    or GenshinServer.os_asia
                    or GenshinServer.os_usa
                    or GenshinServer.os_cht => GenshinServerType.Oversea,
                GenshinServer.cn_gf01
                    or GenshinServer.cn_qd01 => GenshinServerType.Chinese,
                _ => throw new ArgumentOutOfRangeException(nameof(server), server, null)
            };
        }
    }
}