namespace Spearhead;

/// <summary>
/// A basic interface for all battle actions.
/// </summary>
public interface IBattleAction
{
    /// <summary>
    /// Can this action be reacted to?
    /// </summary>
    bool CanBeginningBeReactedTo { get; }

    bool CanCompletionBeReactedTo { get; }
}
