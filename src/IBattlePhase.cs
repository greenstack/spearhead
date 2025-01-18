namespace Spearhead;

public interface IBattlePhase<TBattleContext>
{
    void BeginPhase(PhaseManagerBase<TBattleContext> phaseManager, double deltaTime);

    void Update(PhaseManagerBase<TBattleContext> phaseManager,double deltaTime);

    void EndPhase(PhaseManagerBase<TBattleContext> phaseManager,double deltaTime);
}
