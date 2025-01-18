namespace Spearhead;

/// <summary>
/// An interface for phase managers in battles.
/// </summary>
/// <typeparam name="TBattleContext"></typeparam>
public interface IPhaseManager<TBattleContext>
{
    /// <summary>
    /// Retrieves the battle's current phase.
    /// </summary>
    IBattlePhase<TBattleContext> CurrentPhase { get; }

    /// <summary>
    /// Has the battle ended?
    /// </summary>
    bool IsBattleOver { get; }

    /// <summary>
    /// Causes the phase manager to advance to the next phase.
    /// </summary>
    void AdvancePhase();

    /// <summary>
    /// Initializes this phase manager with the battle.
    /// </summary>
    /// <param name="battle">The battle to initialize with.</param>
    void Initialize(Battle<TBattleContext> battle);

    /// <summary>
    /// Immediately ends the battle.
    /// </summary>
    void EndBattle();
}
