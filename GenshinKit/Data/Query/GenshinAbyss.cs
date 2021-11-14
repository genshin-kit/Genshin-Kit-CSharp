
namespace GenshinKit.Data.Query
{
    public class GenshinAbyss
    {
        /// <summary>
        /// Issue number of certain spiral abyss
        /// </summary>
        [JsonProperty("schedule_id")]
        public string ScheduleId { get; set; }
        
        /// <summary>
        /// When it stared
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }
        
        /// <summary>
        /// When does it end
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_battle_times")]
        public int TotalBattleTimes { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_win_times")]
        public int TotalWinTimes { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("max_floor")]
        public string MaxFloor { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_star")]
        public int TotalStar { get; set; }
        
        /// <summary>
        /// Has unlocked Spiral Abyss from the Spiral Corridor
        /// </summary>
        [JsonProperty("is_unlock")]
        public bool IsUnlock { get; set; }
        
        /// <summary>
        /// Most played characters
        /// </summary>
        [JsonProperty("reveal_rank")]
        public IEnumerable<Avatar> RevealRank { get; set; }
        
        /// <summary>
        /// Most defeats characters
        /// </summary>
        [JsonProperty("defeat_rank")]
        public IEnumerable<Avatar> DefeatRank { get; set; }
        
        /// <summary>
        /// Strongest single strike characters
        /// </summary>
        [JsonProperty("damage_rank")]
        public IEnumerable<Avatar> DamageRank { get; set; }
        
        /// <summary>
        /// Most damage taken characters
        /// </summary>
        [JsonProperty("take_damage_rank")]
        public IEnumerable<Avatar> TakeDamageRank { get; set; }
        
        /// <summary>
        /// Most elemental skills cast
        /// </summary>
        [JsonProperty("normal_skill_rank")]
        public IEnumerable<Avatar> NormalSkillRank { get; set; }
        
        /// <summary>
        /// Most elemental bursts unleashed
        /// </summary>
        [JsonProperty("energy_skill_rank")]
        public IEnumerable<Avatar> EnergySkillRank { get; set; }
        
        /// <summary>
        /// Details of certain floor
        /// </summary>
        [JsonProperty("floors")]
        public IEnumerable<Floor> Floors { get; set; }
        
        public class Avatar
        {
            /// <summary>
            /// Icon url of certain character
            /// </summary>
            [JsonProperty("avatar_icon")]
            public string AvatarIcon { get; set; }

            [JsonProperty("icon")] 
            public string Icon { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("value")]
            public int Value { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("rarity")]
            public int Rarity { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("level")]
            public int Level { get; set; }
        }
        
        public class Floor
        {
            /// <summary>
            /// Index of floor
            /// </summary>
            [JsonProperty("index")]
            public int Index { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("is_unlock")]
            public string IsUnlock { get; set; }
            
            /// <summary>
            /// UNKNOWN 
            /// </summary>
            [JsonProperty("settle_time")]
            public string SettleTime { get; set; }
            
            /// <summary>
            /// EMPTY
            /// </summary>
            [JsonProperty("icon")]
            public string Icon { get; set; }
            
            /// <summary>
            /// Attained stars in this floor
            /// </summary>
            [JsonProperty("star")]
            public int Star { get; set; }
            
            /// <summary>
            /// Maximum stars of this floor
            /// </summary>
            [JsonProperty("max_star")]
            public int MaxStar { get; set; }
            
            /// <summary>
            /// Detailed chamber
            /// </summary>
            [JsonProperty("levels")]
            public IEnumerable<Chamber> Levels { get; set; }
        }
        
        public class Chamber
        {
            /// <summary>
            /// Index of chamber
            /// </summary>
            [JsonProperty("index")]
            public int Index { get; set; }
            
            /// <summary>
            /// Attained stars in this chamber
            /// </summary>
            [JsonProperty("star")]
            public int Star { get; set; }
            
            /// <summary>
            /// Maximum stars of this chamber
            /// </summary>
            [JsonProperty("max_star")]
            public int MaxStar { get; set; }
            
            /// <summary>
            /// Battles of certain detailed certain chamber
            /// </summary>
            [JsonProperty("battles")]
            public IEnumerable<Battle> Battles { get; set; }
        }
        
        public class Battle
        {
            /// <summary>
            /// 1 = first half 2 = second half
            /// </summary>
            [JsonProperty("index")]
            public int Index { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("timestamp")]
            public string Timestamp { get; set; }
            
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty("avatars")]
            public IEnumerable<Avatar> Avatars { get; set; }
        }
    }
}