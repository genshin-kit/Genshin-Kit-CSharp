﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
        /// Generate a new dynamic secret for genshin chinese servers
        /// </summary>
        /// ///
        /// <param name="uid">Specific player's uid</param>
        /// <param name="saltProvider">Use your own salt</param>
        /// <returns></returns>
        public static string GetDs(string uid, Func<string> saltProvider = null)
        {
            return GetDs(uid, string.Empty, saltProvider);
        }

        /// <summary>
        /// Generate a new dynamic secret for genshin chinese servers with body
        /// </summary>
        /// ///
        /// <param name="uid">Specific player's uid</param>
        /// <param name="body"></param>
        /// <param name="saltProvider">Use your own salt</param>
        /// <returns></returns>
        public static string GetDs(string uid, string body, Func<string> saltProvider = null)
        {
            saltProvider ??= () => "xV8v4Qu54lUKrEYFZkJhB8cuOh9Asafs";
            
            var salt = saltProvider();
            var t = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var r = GetRandomString();

            var aftermath =
                $"salt={salt}&t={t}&r={r}&b={body}&q=role_id={uid}&server={uid.DistinguishGenshinServer()}".ToMd5();

            return $"{t},{r},{aftermath}";
        }

        /// <summary>
        /// Generate a new dynamic secret for genshin oversea servers
        /// </summary>
        /// <param name="saltProvider">Use your own salt</param>
        /// <returns></returns>
        public static string GetDs(Func<string> saltProvider = null)
        {
            saltProvider ??= () => "6s25p5ox5y14umn1p61aqyyvbvvl3lrt";
            
            var salt = saltProvider();
            var t = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            var r = GetRandomString();

            var aftermath = $"salt={salt}&t={t}&r={r}".ToMd5();

            return $"{t},{r},{aftermath}";
        }
    }
}