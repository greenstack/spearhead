#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

/// <summary>
/// Handles the dispatch of events that occur in a battle.
/// </summary>
public interface IEventDispatcher : IBattleAction
{
    void Dispatch(IBattleEvent @event);
}

#if UNITY_6000
}
#endif // UNITY