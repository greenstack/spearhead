namespace Spearhead;

public interface IBattlePhase<TPhase, TBattleContext>
    //where TPhaseManager : IPhaseManager<TBattleContext, TPhase>
    where TPhase : IBattlePhase<TPhase, TBattleContext>
{
    void BeginPhase(PhaseManagerBase<TBattleContext, TPhase> phaseManager, double deltaTime);

    void Update(PhaseManagerBase<TBattleContext, TPhase> phaseManager,double deltaTime);

    void EndPhase(PhaseManagerBase<TBattleContext, TPhase> phaseManager,double deltaTime);
}
