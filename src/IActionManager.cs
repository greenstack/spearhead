namespace Spearhead;

public class ActionCompleteArgs(IBattleAction action, ActionStatus result)
{
    public readonly ActionStatus Result = result;
    public readonly IBattleAction Action = action;
}

public delegate void ActionEvent(IActionManager actionManager, ActionCompleteArgs context);

/// <summary>
/// Interface for managing battle actions.
/// </summary>
public interface IActionManager
{
    /// <summary>
    /// The action currently being processed.
    /// </summary>
    IBattleAction CurrentAction { get; }

    /// <summary>
    /// Triggered when an action's processing is completed.
    /// </summary>
    event ActionEvent OnActionComplete;
    event ActionEvent OnActionBegun;

    /// <summary>
    /// Is there an action currently being processed?
    /// </summary>
    bool IsActive => CurrentAction != null;

    /// <summary>
    /// Updates the current action.
    /// </summary>
    /// <param name="deltaTime"></param>
    void Update(double deltaTime);

    /// <summary>
    /// Requests an action to be performed.
    /// </summary>
    /// <param name="action">The action to request.</param>
    void RequestPendingAction(IBattleAction action);

    /// <summary>
    /// Requests an action for immediate processing.
    /// </summary>
    /// <param name="action">The action to process.</param>
    void RequestImmediateAction(IBattleAction action);
}