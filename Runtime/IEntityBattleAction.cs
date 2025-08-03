namespace Spearhead;

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
