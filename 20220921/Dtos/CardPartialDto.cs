using _20220921.Models;

namespace _20220921.Dtos
{
    /// <summary>
    /// 卡片
    /// </summary>
    public class CardPartialDto
    {
        /// <summary>
        /// 卡片編號
        /// </summary>
        public int Id { get; set; }
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
        public int? Cost { get; set; } = 0;
        /// <summary>
        /// 等級
        /// </summary>
        public CardLevel Level { get; set; } = CardLevel.Poor;
    }

}
