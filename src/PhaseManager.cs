namespace Spearhead;

/// <summary>
/// Manages the phases of a battle. Note that regardless of the battle schema
/// (continuous or discrete), phases are always evaluated in realtime, and thus
/// have an update method.
/// </summary>
public abstract class PhaseManagerBase<TBattleContext, TPhase> : IPhaseManager
{
    /// <inheritdoc/>
    public abstract IBattlePhase CurrentPhase {get; }

    /// <inheritdoc/>
    public abstract bool IsBattleOver { get; }

    /// <inheritdoc/>
    public abstract void AdvancePhase();

    /// <inheritdoc/>
    public virtual void Update(float deltaTime)
    {
        // I don't know why this explicit cast is necessary
        CurrentPhase.Update(this, deltaTime);
    }

    /// <inheritdoc/>
    public virtual void Initialize(IBattle battle)
    {
        // TODO: Hook up to the proper components
    }

    public abstract void EndBattle();
}
