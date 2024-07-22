using ArenaBattle.Interfaces.Model;

namespace ArenaBattle.Models
{
    public class Arena : IArena
    {
        public int Id { get; set; }
        public List<IHero>? Heroes { get; set; }
        public List<IBattleHistory> History { get; set; } = [];
    }
}
