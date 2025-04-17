namespace Spearhead;

/// <summary>
/// Manages the phases of a battle.
/// </summary>
public abstract class PhaseManagerBase<TBattleContext, TPhase> : IPhaseManager
{
    public abstract IBattlePhase CurrentPhase {get; }

    public abstract bool IsBattleOver { get; }

    public abstract void AdvancePhase();

    public virtual void Update(float deltaTime)
    {
        // I don't know why this explicit cast is necessary
        CurrentPhase.Update(this, deltaTime);
    }

    public virtual void Initialize(IBattle battle)
    {
        // TODO: Hook up to the proper components
    }

    public abstract void EndBattle();
}
