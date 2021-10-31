using System.Collections.Generic;
using Newtonsoft.Json;

namespace GenshinKit.Data.Query
{
    public class Index
    {
        [JsonProperty("avatars")]
        public IEnumerable<Avatar> Avatars { get; set; }
        
        [JsonProperty("stats")]
        public Stats Stats {get; set;}
        
        [JsonProperty("world_explorations")]
        public IEnumerable<WorldExploration> WorldExplorations {get; set;}
        
        [JsonProperty("homes")]
        public IEnumerable<Home> Homes {get; set;}
    }

    public class Avatar
    {
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("image")]
        public string Image {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("element")]
        public string Element {get; set;}
        
        [JsonProperty("fetter")]
        public string Fetter {get; set;}
        
        [JsonProperty("level")]
        public string Level {get; set;}
        
        [JsonProperty("rarity")]
        public string Rarity {get; set;}
        
        /// <summary>
        /// Activated constellation stacks
        /// </summary>
        [JsonProperty("actived_constellation_num")]
        public string ActivedConstellation {get; set;}
    }

    public class Stats
    {
        /// <summary>
        /// How many days this account has been active
        /// </summary>
        [JsonProperty("active_day_number")]
        public int ActiveDays {get; set;}
        
        /// <summary>
        /// How many achievements this account has
        /// </summary>
        [JsonProperty("achievement_number")]
        public string Achievements {get; set;}
        
        /// <summary>
        /// No certain use
        /// </summary>
        [JsonProperty("win_rate")]
        public string WinRate {get; set;}
        
        /// <summary>
        /// How many anemoculus has collected
        /// </summary>
        [JsonProperty("anemoculus_number")]
        public int Anemoculus {get; set;}
        
        /// <summary>
        /// How many geoculus has collected
        /// </summary>
        [JsonProperty("geoculus_number")]
        public int Geoculus {get; set;}
        
        /// <summary>
        /// How many electroculus has collected
        /// </summary>
        [JsonProperty("electroculus_number")]
        public int Electroculus {get; set;}
        
        /// <summary>
        /// How many avatars does this account possess
        /// </summary>
        [JsonProperty("avatar_number")]
        public int Avatars {get; set;}
        
        /// <summary>
        /// How many way point (teleport point) has unlocked
        /// </summary>
        [JsonProperty("way_point_number")]
        public int WayPoints {get; set;}
        
        /// <summary>
        /// How many domains has unlocked
        /// </summary>
        [JsonProperty("domain_number")]
        public int Domains {get; set;}
        
        /// <summary>
        /// The progress of spiral abyss
        /// </summary>
        [JsonProperty("spiral_abyss")]
        public string SpiralAbyss {get; set;}
        
        /// <summary>
        /// How many precious chests has been opened
        /// </summary>
        [JsonProperty("precious_chest_number")]
        public int PreciousChests {get; set;}
        /// <summary>
        /// How many luxurious chests has been opened
        /// </summary>
        [JsonProperty("luxurious_chest_number")]
        public int LuxuriousChests {get; set;}
        
        /// <summary>
        /// How many exquisite chests has been opened
        /// </summary>
        [JsonProperty("exquisite_chest_number")]
        public int ExquisiteChests {get; set;}
        
        /// <summary>
        /// How many common chests has been opened
        /// </summary>
        [JsonProperty("common_chest_number")]
        public int CommonChests {get; set;}
        
        /// <summary>
        /// How many magic chests has been opened
        /// </summary>
        [JsonProperty("magic_chest_number")]
        public int MagicChests {get; set;}
    }

    public class WorldExploration
    {
        [JsonProperty("level")]
        public int Level {get; set;}
        
        [JsonProperty("exploration_percentage")]
        public int ExplorationPercentage {get; set;}
        
        [JsonProperty("icon")]
        public string Icon {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("type")]
        public string Type {get; set;}
        
        [JsonProperty("id")]
        public int Id {get; set;}
        
        [JsonProperty("offerings")]
        public IEnumerable<Offering> Offerings {get; set;}
        
        public class Offering
        {
            [JsonProperty("name")]
            public string Name {get; set;}
            
            [JsonProperty("level")]
            public int Level {get; set;}
        }
    }

    public class Home
    {
        [JsonProperty("level")]
        public int Level {get; set;}
        
        [JsonProperty("visit_num")]
        public int Visits {get; set;}
        
        [JsonProperty("comfort_num")]
        public int ComfortNum {get; set;}
        
        [JsonProperty("item_num")]
        public int Items {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("icon")]
        public string Icon {get; set;}
        
        [JsonProperty("comfort_level_name")]
        public string ComfortLevelName {get; set;}
        
        [JsonProperty("comfort_level_icon")]
        public string ComfortLevelIcon {get; set;}
    }
}