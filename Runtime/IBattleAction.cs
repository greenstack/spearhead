#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

/// <summary>
/// A basic interface for all battle actions.
/// </summary>
public interface IBattleAction
{
    /// <summary>
    /// Processes the action in real time.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since the last update.</param>
    /// <returns>The current status of the action.</returns>
    ActionStatus Process(double deltaTime);

    /// <summary>
    /// Can this action be reacted to?
    /// </summary>
    bool CanBeginningBeReactedTo { get; }

    bool CanCompletionBeReactedTo { get; }
}

#if UNITY_6000
}
#endif // UNITY