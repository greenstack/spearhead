#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

public interface IBattlePhase<TBattleContext, TPhase>
    //where TPhaseManager : IPhaseManager<TBattleContext, TPhase>
    where TPhase : IBattlePhase<TBattleContext, TPhase>
{
    void BeginPhase(IPhaseManager<TBattleContext, TPhase> phaseManager, double deltaTime);

    void Update(IPhaseManager<TBattleContext, TPhase> phaseManager, double deltaTime);

    void EndPhase(IPhaseManager<TBattleContext, TPhase> phaseManager,double deltaTime);
}

#if UNITY_6000
}
#endif // UNITY