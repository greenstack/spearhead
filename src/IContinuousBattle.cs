namespace Spearhead;

/// <summary>
/// Represents a battle that is processed in realtime, or continuously. You
/// want to use this kind of battle if the battle is responsible for handling
/// all input or if the battle requires continuous input processing, like in
/// games that use action commands as a part of their battle loop.
/// </summary>
public interface IContinuousBattle : IBattle, IEvaluateContinuously
{

}
