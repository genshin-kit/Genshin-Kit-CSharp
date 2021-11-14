using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Flurl;
using GenshinKit.Data;

namespace GenshinKit.Utility
{
    /// <summary>
    /// Algorithm provider
    /// </summary>
    public static class AlgorithmHelper
    {
        /// <summary>
        /// Convert a string to its MD5
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string ToMd5(this string origin)
        {
            var md5 = MD5.Create();
            var buffer = Encoding.UTF8.GetBytes(origin);
            var md5Buffer = md5.ComputeHash(buffer);

            return string.Join(string.Empty, md5Buffer.Select(t => t.ToString("x2")));
        }

        /// <summary>
        /// Get a random string
        /// </summary>
        /// <param name="length">Length of expected string, default is 6</param>
        /// <returns></returns>
        public static string GetRandomString(int length = 6)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generate new dynamic secret with request body
        /// </summary>
        /// <param name="config"></param>
        /// <param name="body"></param>
        /// <param name="saltProvider"></param>
        /// <returns></returns>
        public static string GetDs(this GenshinQueryConfig config, string body, Func<string> saltProvider = null)
        {
            var url = new Url(config.Url);
            var queryParams = url.QueryParams.Select(valueTuple =>
            {
                (string name, string value) tuple = (valueTuple.Name, valueTuple.Value.ToString());
                return tuple;
            });

            var query = string.Join("&", queryParams
                .OrderBy(x => x.name)
                .Select(tuple => $"{tuple.name}={tuple.value}"));


            saltProvider ??= () => "xV8v4Qu54lUKrEYFZkJhB8cuOh9Asafs";
            var currentTimeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var randomString = GetRandomString();
            var salt = saltProvider();
            
            var aftermath =
                ($"salt={salt}" +
                $"&t={currentTimeStamp}" +
                $"&r={randomString}" +
                $"&b={body}" +
                $"&q={query}").ToMd5();

            return $"{currentTimeStamp},{randomString},{aftermath}";
        }

        /// <summary>
        /// Generate new dynamic secret
        /// </summary>
        /// <param name="config"></param>
        /// <param name="saltProvider"></param>
        /// <returns></returns>
        public static string GetDs(this GenshinQueryConfig config, Func<string> saltProvider = null)
        {
            if (config.Uid.IsChinese()) return GetDs(config, string.Empty, saltProvider);
            
            saltProvider ??= () => "6s25p5ox5y14umn1p61aqyyvbvvl3lrt";
                
            var currentTimeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var randomString = GetRandomString();

            var aftermath = ($"salt={saltProvider()}" +
                             $"&t={currentTimeStamp}" +
                             $"&r={randomString}").ToMd5();

            return $"{currentTimeStamp},{randomString},{aftermath}";

        }
    }
}