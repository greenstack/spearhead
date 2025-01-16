namespace Spearhead;

public enum ActionStatus
{
    /// <summary>
    /// The action is still processing.
    /// </summary>
    Running,
    /// <summary>
    /// The action has been completed.
    /// </summary>
    Complete,
    /// <summary>
    /// The action was cancelled for some reason.
    /// </summary>
    Aborted,
}
