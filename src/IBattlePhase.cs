namespace Spearhead;

public interface IBattlePhase<TBattleContext, TPhase>
    //where TPhaseManager : IPhaseManager<TBattleContext, TPhase>
    where TPhase : IBattlePhase<TBattleContext, TPhase>
{
    void BeginPhase(IPhaseManager<TBattleContext, TPhase> phaseManager, double deltaTime);

    void Update(IPhaseManager<TBattleContext, TPhase> phaseManager, double deltaTime);

    void EndPhase(IPhaseManager<TBattleContext, TPhase> phaseManager,double deltaTime);
}

