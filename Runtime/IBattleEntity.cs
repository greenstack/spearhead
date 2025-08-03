#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

/// <summary>
/// Represents an entity that's managed by the battle.
/// </summary>
public interface IBattleEntity
{
    /// <summary>
    /// Can this entity presently perform any actions?
    /// </summary>
    bool CanAct { get; }
}

#if UNITY_6000
}
#endif // UNITY