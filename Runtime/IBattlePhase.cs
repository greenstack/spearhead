using System.Collections;

namespace Spearhead
{
    public interface IBattlePhase<TPhase>
        where TPhase : IBattlePhase<TPhase>
    {
        void BeginPhase(IPhaseManager<TPhase> phaseManager, double deltaTime);

        IEnumerator Run(IPhaseManager<TPhase> phaseManager);

        void EndPhase(IPhaseManager<TPhase> phaseManager, double deltaTime);
    }
}