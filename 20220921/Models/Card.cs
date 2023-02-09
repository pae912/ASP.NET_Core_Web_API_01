﻿namespace _20220921.Models
{
    /// <summary>
    /// 卡片
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 卡片編號
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 卡片名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 卡片描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 攻擊力
        /// </summary>
        public int Attack { get; set; }
        /// <summary>
        /// 血量
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// 花費
        /// </summary>
        public int? Cost { get; set; }
        /// <summary>
        /// 卡片等級
        /// </summary>
        public CardLevel Level { get; set; }
    }
    /// <summary>
    /// 卡片等級
    /// </summary>
    public enum CardLevel
    {
        Excellent = 5,
        Good = 4,
        Average = 3,
        Fair = 2,
        Poor = 1
    }

}
