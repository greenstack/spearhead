using System.Collections;

namespace Spearhead
{
    public interface IPhaseManager
    {
        /// <summary>
        /// Has the battle ended?
        /// </summary>
        bool IsBattleOver { get; }

        /// <summary>
        /// Causes the phase manager to advance to the next phase.
        /// </summary>
        void AdvancePhase();

        IEnumerator ProcessPhase();

        /// <summary>
        /// Immediately ends the battle.
        /// </summary>
        void EndBattle();
    }

    /// <summary>
    /// An interface for phase managers in battles.
    /// </summary>
    /// <typeparam name="TPhase">The phase type managed by this phase manager.</typeparam>
    public interface IPhaseManager<TPhase> : IPhaseManager
        where TPhase : IBattlePhase<TPhase>
    {
        /// <summary>
        /// Retrieves the battle's current phase.
        /// </summary>
        TPhase CurrentPhase { get; }
    }
}