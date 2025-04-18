namespace Spearhead;

/// <summary>
/// An interface for battle actions that require continuous evaluation.
/// </summary>
public interface IContinuousAction : IBattleAction
{
    /// <summary>
    /// Processes the action in real time.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since the last update.</param>
    /// <returns>The current status of the action.</returns>
    ActionStatus Process(double deltaTime);
}
