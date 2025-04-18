namespace Spearhead;

/// <summary>
/// An object in Spearhead that processes in realtime.<br/>
/// Battles that manage all events, including input, should largely implement
/// this interface. If events are evaluated discretely instead of continuously,
/// battles should not implement this interface.
/// </summary>
public interface IEvaluateContinuously
{
    void Evaluate(float deltaTime);
}
