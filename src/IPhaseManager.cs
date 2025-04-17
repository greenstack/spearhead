namespace Spearhead;

public interface IPhaseManager
{
    IBattlePhase CurrentPhase { get; }

    /// <summary>
    /// Has the battle ended?
    /// </summary>
    bool IsBattleOver { get; }

    /// <summary>
    /// Causes the phase manager to advance to the next phase.
    /// </summary>
    void AdvancePhase();

    /// <summary>
    /// Immediately ends the battle.
    /// </summary>
    void EndBattle();

    /// <summary>
    /// Initializes this phase manager with the battle.
    /// </summary>
    /// <param name="battle">The battle to initialize with.</param>
    void Initialize(IBattle battle);

    void Update(float deltaTime);
}

/// <summary>
/// An interface for phase managers in battles.
/// </summary>
/// <typeparam name="TBattleContext"></typeparam>
public interface IPhaseManager<TPhase> : IPhaseManager
    where TPhase : IBattlePhase
{
    /// <summary>
    /// Retrieves the battle's current phase.
    /// </summary>
    new TPhase CurrentPhase { get; }
}
