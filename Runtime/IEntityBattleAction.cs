#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

/// <summary>
/// Represents an action being performed by an entity
/// </summary>
public interface IEntityBattleAction : IBattleAction
{
    /// <summary>
    /// The entity performing the action.
    /// </summary>
    IBattleEntity Actor { get; }
}

#if UNITY_6000
}
#endif // UNITY