namespace Spearhead;

/// <summary>
/// Handles the dispatch of events that occur in a battle.
/// </summary>
public interface IEventDispatcher : IBattleAction
{
    void Dispatch(IBattleEvent @event);
}
