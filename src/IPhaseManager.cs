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

    /// <summary>
    /// Updates this phase.
    /// </summary>
    /// <param name="deltaTime">The amount of time elapsed since the last frame.</param>
    void Update(float deltaTime);
}
