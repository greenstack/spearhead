namespace Spearhead;

public interface IBattlePhase<TBattleContext, TPhase, TPhaseManager>
    where TPhaseManager : IPhaseManager<TBattleContext, TPhase, TPhaseManager>
    where TPhase : IBattlePhase<TBattleContext, TPhase, TPhaseManager>
{
    void BeginPhase(TPhaseManager phaseManager, double deltaTime);

    void Update(TPhaseManager phaseManager, double deltaTime);

    void EndPhase(TPhaseManager phaseManager,double deltaTime);
}
