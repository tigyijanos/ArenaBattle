namespace ArenaBattle.Models
{
    public class Arena
    {
        public int Id { get; set; }
        public List<Hero> Heroes { get; set; }
        public List<BattleHistory> History { get; set; } = new List<BattleHistory>();
    }
}
