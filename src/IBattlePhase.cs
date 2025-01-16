namespace Spearhead;

public interface IBattlePhase<TBattleContext>
{
    void BeginPhase(PhaseManager<TBattleContext> phaseManager, double deltaTime);

    void Update(PhaseManager<TBattleContext> phaseManager,double deltaTime);

    void EndPhase(PhaseManager<TBattleContext> phaseManager,double deltaTime);
}
