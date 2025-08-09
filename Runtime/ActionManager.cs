#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spearhead
{
    /// <summary>
    /// Base class for managing actions.
    /// </summary>
    public class ActionManager : MonoBehaviour, IActionManager
    {
        readonly Stack<IBattleAction> _activeActions = new();
        readonly Queue<IBattleAction> _pendingActions = new();

        public IBattleAction? CurrentAction => _activeActions.TryPeek(out var action) ? action : null;

        public event ActionEvent? OnActionComplete;
        public event ActionEvent? OnActionBegun;

        public void RequestPendingAction(IBattleAction action)
        {
            if (_activeActions.Count > 0)
            {
                _pendingActions.Enqueue(action);
            }
            else
            {
                RequestImmediateAction(action);
            }
        }

        public void RequestImmediateAction(IBattleAction action) => PushAction(action);

        public IEnumerator ProcessActions()
        {
            while (CurrentAction != null)
            {
                yield return StartCoroutine(CurrentAction.Process());
                // The action has completed execution. Time to move on to the next.
                var oldAction = _activeActions.Pop();
                if (oldAction.CanCompletionBeReactedTo)
                    OnActionComplete?.Invoke(this, new ActionCompleteArgs(oldAction, ActionStatus.Complete));
                if (_activeActions.Count == 0 && _pendingActions.TryDequeue(out IBattleAction? nextAction))
                    RequestImmediateAction(nextAction);
            }
        }

        private void PushAction(IBattleAction action)
        {
            _activeActions.Push(action);
            if (action.CanBeginningBeReactedTo)
                OnActionBegun?.Invoke(this, new ActionCompleteArgs(action, ActionStatus.Running));
        }
    }
}