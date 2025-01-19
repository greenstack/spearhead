namespace Spearhead;

/// <summary>
/// Manages the phases of a battle.
/// </summary>
public abstract class PhaseManagerBase<TBattleContext, TPhase, TPhaseManager> : IPhaseManager<TBattleContext, TPhase, TPhaseManager>
    where TPhase : IBattlePhase<TBattleContext, TPhase, TPhaseManager>
    where TPhaseManager : PhaseManagerBase<TBattleContext, TPhase, TPhaseManager>
{
    public abstract TPhase CurrentPhase {get; }

    public abstract bool IsBattleOver { get; }

    public abstract void AdvancePhase();

    public virtual void Update(Battle<TBattleContext> battle, double deltaTime)
    {
        // I don't know why this explicit cast is necessary
        CurrentPhase.Update((TPhaseManager)this, deltaTime);
    }

    public virtual void Initialize(Battle<TBattleContext> battle)
    {
        // TODO: Hook up to the proper components
    }

    public abstract void EndBattle();
}
