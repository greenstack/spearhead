using System.Collections;

namespace Spearhead
{
    public interface IBattlePhase<TPhase>
        where TPhase : IBattlePhase<TPhase>
    {
        void BeginPhase(IPhaseManager<TPhase> phaseManager);

        IEnumerator Run(IPhaseManager<TPhase> phaseManager);

        void EndPhase(IPhaseManager<TPhase> phaseManager);
    }
}