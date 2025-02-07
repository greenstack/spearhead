namespace Spearhead;

/// <summary>
/// Represents an event that happened in battle.
/// </summary>
public interface IBattleEvent : IBattleAction
{
    /// <summary>
    /// How many reactions remain to be processed?
    /// </summary>
    int ReactionsRemaining { get; }

    /// <summary>
    /// Events are the reaction, so they can't be reacted to.
    /// </summary>
    sealed bool CanBeReactedTo => false;
}

