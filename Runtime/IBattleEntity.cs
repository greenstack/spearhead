namespace Spearhead
{
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
}