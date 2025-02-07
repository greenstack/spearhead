namespace Spearhead;

/// <summary>
/// Represents a listerner to battle events.
/// </summary>
public interface IBattleEventListener
{
    IBattleAction? GetReaction(IBattleEvent battleEvent);
}
