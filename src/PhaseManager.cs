namespace Spearhead;

/// <summary>
/// Manages the phases of a battle. This phase manager is implemented
/// in a round-robin style; that is, an A -> B -> C -> A -> B -> C style.
/// </summary>
public abstract class PhaseManagerBase<TBattleContext, TPhase> : IPhaseManager<TBattleContext, TPhase> where TPhase : IBattlePhase<TPhase, TBattleContext>
{
    public abstract TPhase CurrentPhase {get; }

    public abstract bool IsBattleOver { get; }

    public abstract void AdvancePhase();

    public void Update(Battle<TBattleContext> battle, double deltaTime)
    {
        CurrentPhase.Update(this, deltaTime);
    }

    public void Initialize(Battle<TBattleContext> battle)
    {
        // TODO: Hook up to the proper components
    }

    public abstract void EndBattle();
}
