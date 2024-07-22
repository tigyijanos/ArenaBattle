using ArenaBattle.Interfaces.Model;

namespace ArenaBattle.Interfaces.Services
{
    /// <summary>
    /// Provides methods to manage and execute battles in an arena.
    /// </summary>
    public interface IArenaService
    {
        /// <summary>
        /// Creates a new arena with the specified number of heroes.
        /// </summary>
        /// <param name="numberOfHeroes">The number of heroes to be added to the new arena.</param>
        /// <returns>The unique identifier of the created arena.</returns>
        int CreateArena(int numberOfHeroes);

        /// <summary>
        /// Retrieves the arena with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the arena to retrieve.</param>
        /// <returns>The arena with the specified identifier, or null if no such arena exists.</returns>
        IArena? GetArena(int id);

        /// <summary>
        /// Executes a battle in the specified arena until only one hero is left standing.
        /// </summary>
        /// <param name="arena">The arena in which the battle will be executed.</param>
        void ExecuteBattle(IArena arena);
    }
}