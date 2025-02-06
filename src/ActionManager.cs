namespace Spearhead;

/// <summary>
/// Base class for managing actions.
/// </summary>
public class ActionManager : IActionManager
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
            _activeActions.Push(action);
        }
    }

    public void RequestImmediateAction(IBattleAction action)
    {
        _activeActions.Push(action);
        OnActionBegun?.Invoke(this, new ActionCompleteArgs(action, ActionStatus.Running));
    }

    public void Update(double deltaTime)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        // This won't be null because of the way the default action manager decides to process actions or not.
        var processResult = CurrentAction.Process(deltaTime);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (processResult != ActionStatus.Running)
        {
            // The action has completed execution. Time to move on to the next.
            var oldAction = _activeActions.Pop();
            OnActionComplete?.Invoke(this, new ActionCompleteArgs(oldAction, processResult));
            // We only 
            if (_activeActions.Count == 0 && _pendingActions.TryDequeue(out IBattleAction? nextAction))
            {
                RequestImmediateAction(nextAction);
            }
        }
    }
}