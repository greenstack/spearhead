using System.Collections.Generic;

namespace Spearhead
{
    /// <summary>
    /// A basic interface for all battle actions.
    /// </summary>
    public interface IBattleAction
    {
        /// <summary>
        /// Processes the action in real time.
        /// </summary>
        /// <returns>The current status of the action.</returns>
        IEnumerator<ActionStatus> Process();

        /// <summary>
        /// Can this action be reacted to?
        /// </summary>
        bool CanBeginningBeReactedTo { get; }

        bool CanCompletionBeReactedTo { get; }
    }
}