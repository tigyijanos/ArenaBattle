namespace ArenaBattle.Models
{
    public class BattleHistory
    {
        public int Round { get; set; }
        public Hero Attacker { get; set; }
        public Hero Defender { get; set; }
        public string Outcome { get; set; }
        public int AttackerHealthAfter { get; set; }
        public int DefenderHealthAfter { get; set; }
    }
}
