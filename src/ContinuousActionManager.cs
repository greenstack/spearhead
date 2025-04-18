namespace Spearhead;

/// <summary>
/// Base class for managing actions.
/// </summary>
public class ContinuousActionManager : IActionManager<IContinuousAction>, IEvaluateContinuously
{
    readonly Stack<IContinuousAction> _activeActions = new();
    readonly Queue<IContinuousAction> _pendingActions = new();

    private IContinuousAction? _currentAction => _activeActions.TryPeek(out var action) ? action : null;
    public IBattleAction? CurrentAction => _currentAction;
    public bool IsActive => CurrentAction != null;

    public event ActionEvent? OnActionComplete;
    public event ActionEvent? OnActionBegun;

    public void RequestPendingAction(IContinuousAction action)
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

    public void RequestImmediateAction(IContinuousAction action) => PushAction(action);

    public void Evaluate(float deltaTime)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        // This won't be null because of the way the default action manager decides to process actions or not.
        var processResult = _currentAction.Process(deltaTime);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (processResult != ActionStatus.Running)
        {
            // The action has completed execution. Time to move on to the next.
            var oldAction = _activeActions.Pop();
            if (oldAction.CanCompletionBeReactedTo)
                OnActionComplete?.Invoke(this, new ActionCompleteArgs(oldAction, processResult));
            // We only 
            if (_activeActions.Count == 0 && _pendingActions.TryDequeue(out IContinuousAction? nextAction))
            {
                RequestImmediateAction(nextAction);
            }
        }
    }

    private void PushAction(IContinuousAction action)
    {
        _activeActions.Push(action);
        if (action.CanBeginningBeReactedTo)
            OnActionBegun?.Invoke(this, new ActionCompleteArgs(action, ActionStatus.Running));
    }
}