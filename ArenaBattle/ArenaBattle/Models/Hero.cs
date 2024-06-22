using ArenaBattle.Models.Enums;

namespace ArenaBattle.Models
{
    /// <summary>
    /// Represents the base class for all heroes.
    /// </summary>
    public abstract class Hero
    {
        /// <summary>
        /// Gets or sets the unique identifier of the hero.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets the type of the hero.
        /// </summary>
        public abstract HeroType Type { get; }
        /// <summary>
        /// Gets or sets the current health of the hero.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class with a unique identifier and initial health.
        /// </summary>
        public Hero()
        {
            Id = Guid.NewGuid();
            Health = GetInitialHealth();
        }

        /// <summary>
        /// Gets the initial health of the hero
        /// </summary>
        /// <returns>The initial health value.</returns>
        protected abstract int GetInitialHealth();

        /// <summary>
        /// Reduces the hero's health by half. If the health falls below a quarter of the initial health, sets the health to zero.
        /// </summary>
        public void ReduceHealth()
        {
            if (Health > 0)
            {
                Health /= 2;
                if (Health < GetInitialHealth() / 4)
                {
                    Health = 0;
                }
            }
        }

        /// <summary>
        /// Increases the hero's current health by the specified amount, without exceeding the initial health.
        /// </summary>
        /// <param name="amount">The amount by which to increase the health.</param>
        public void IncreaseHealth(int amount)
        {
            Health = Math.Min(Health + amount, GetInitialHealth());
        }
    }
}
