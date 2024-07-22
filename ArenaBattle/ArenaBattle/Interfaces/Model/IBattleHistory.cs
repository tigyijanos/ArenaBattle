namespace ArenaBattle.Interfaces.Model
{
    public interface IBattleHistory
    {
        int Round { get; set; }
        IHero? Attacker { get; set; }
        IHero? Defender { get; set; }
        string? Outcome { get; set; }
        int AttackerHealthAfter { get; set; }
        int DefenderHealthAfter { get; set; }
    }
}
