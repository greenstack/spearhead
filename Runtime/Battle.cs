using System.Collections;
using UnityEngine;

namespace Spearhead {

    /// <summary>
    /// Manages the update logic for a battle.
    /// </summary>
    /// <typeparam name="TContext">The type that provides context to the battle. This can be whatever you need it to be - a grid, etc.</typeparam>
    
    public class Battle : MonoBehaviour, IBattle
    {
        private IPhaseManager _phaseManager;
        public IPhaseManager PhaseManager => _phaseManager;
        private IActionManager _actionManager;
        public IActionManager ActionManager => _actionManager;

        void Start()
        {
            _phaseManager = GetComponent<IPhaseManager>();
            _actionManager = GetComponent<IActionManager>();
            StartCoroutine(RunBattle());
        }

        protected IEnumerator RunBattle()
        {
            while (!PhaseManager.IsBattleOver)
            {
                // TODO: yield return phase manager coroutine or the action manager
                yield return StartCoroutine(_phaseManager.ProcessPhase());
                yield return StartCoroutine(_actionManager.ProcessActions());
            }
        }
    }
}