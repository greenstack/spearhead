namespace Spearhead;

public interface IBattlePhase
{
    void BeginPhase(IPhaseManager phaseManager, double deltaTime);

    void Update(IPhaseManager phaseManager, double deltaTime);

    void EndPhase(IPhaseManager phaseManager,double deltaTime);
}

