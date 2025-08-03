#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

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
    /// <summary>
    /// The action was invalid and not performed.
    /// </summary>
    Invalid,
}

#if UNITY_6000
}
#endif // UNITY