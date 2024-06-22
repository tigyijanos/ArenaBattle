using ArenaBattle.Models;
using ArenaBattle.Models.Enums;

namespace ArenaBattle.Tests.Models
{
    public class CavarlyTests : HeroTests<Cavalry>
    {
        protected override int ExpectedInitialHealth => 150;

        protected override HeroType ExpectedType => ArenaBattle.Models.Enums.HeroType.Cavalry;
    }
}
