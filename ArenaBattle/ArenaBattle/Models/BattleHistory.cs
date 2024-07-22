using ArenaBattle.Interfaces.Model;

namespace ArenaBattle.Models
{
    public class BattleHistory : IBattleHistory
    {
        public int Round { get; set; }
        public IHero? Attacker { get; set; }
        public IHero? Defender { get; set; }
        public string? Outcome { get; set; }
        public int AttackerHealthAfter { get; set; }
        public int DefenderHealthAfter { get; set; }
    }
}
