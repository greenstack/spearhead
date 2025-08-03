#if !UNITY_6000
namespace Spearhead;
#else
#nullable enable

namespace Spearhead {
#endif // !UNITY

/// <summary>
/// Represents a listerner to battle events.
/// </summary>
public interface IBattleEventListener
{
    IBattleAction? GetReaction(IBattleEvent battleEvent);
}

#if UNITY_6000
}
#endif // UNITY