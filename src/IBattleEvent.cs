namespace Spearhead;

/// <summary>
/// Represents an event that happened in battle.
/// </summary>
public interface IBattleEvent
{
    /// <summary>
    /// Should this event be recorded as the result of an action?
    /// </summary>
    bool ShouldRecord { get; }
}
