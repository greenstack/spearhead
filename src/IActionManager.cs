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
    IBattleAction? CurrentAction { get; }

    /// <summary>
    /// Triggered when an action's processing is completed.
    /// </summary>
    event ActionEvent OnActionComplete;
    event ActionEvent OnActionBegun;

    /// <summary>
    /// Is there an action currently being processed?<br/>
    /// TODO: Check if this is really necessary or should only be in Continuous
    /// objects.
    /// </summary>
    public bool IsActive {get; }
}

public interface IActionManager<TBattleAction> : IActionManager where TBattleAction : IBattleAction
{
    /// <summary>
    /// Requests an action to be performed.
    /// </summary>
    /// <param name="action">The action to request.</param>
    void RequestPendingAction(TBattleAction action);

    /// <summary>
    /// Requests an action for immediate processing.
    /// </summary>
    /// <param name="action">The action to process.</param>
    void RequestImmediateAction(TBattleAction action);
}
