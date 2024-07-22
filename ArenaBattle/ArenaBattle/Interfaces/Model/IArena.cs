namespace ArenaBattle.Interfaces.Model
{
    public interface IArena
    {
        int Id { get; set; }
        List<IHero>? Heroes { get; set; }
        List<IBattleHistory> History { get; set; }
    }
}
