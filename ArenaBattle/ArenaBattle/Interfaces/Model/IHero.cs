using ArenaBattle.Models.Enums;

namespace ArenaBattle.Interfaces.Model
{
    public interface IHero : IHaveId
    {
        /// <summary>
        /// Gets the type of the hero.
        /// </summary>
        HeroType Type { get; }
        /// <summary>
        /// Gets or sets the current health of the hero.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Reduces the hero's health by half. If the health falls below a quarter of the initial health, sets the health to zero.
        /// </summary>
        void ReduceHealth();

        /// <summary>
        /// Increases the hero's current health by the specified amount, without exceeding the initial health.
        /// </summary>
        /// <param name="amount">The amount by which to increase the health.</param>
        void IncreaseHealth(int amount);
    }
}
