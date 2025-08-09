using System.Collections;
using UnityEngine;

namespace Spearhead
{
    /// <summary>
    /// Manages the phases of a battle.
    /// </summary>
    public abstract class PhaseManagerBase<TPhase> : MonoBehaviour, IPhaseManager<TPhase>
        where TPhase : IBattlePhase<TPhase>
    {
        public abstract TPhase CurrentPhase { get; }

        public abstract bool IsBattleOver { get; }

        public abstract void AdvancePhase();

        public virtual IEnumerator ProcessPhase()
        {
            // I don't know why this explicit cast is necessary
            yield return StartCoroutine(CurrentPhase.Run(this));
        }

        public abstract void EndBattle();
    }
}