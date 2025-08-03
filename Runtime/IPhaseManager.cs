#if !UNITY_6000
namespace Spearhead;
#else
namespace Spearhead {
#endif // !UNITY

public interface IPhaseManager
{
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
}

public interface IPhaseManager<TBattleContext> : IPhaseManager
{
    void Update(Battle<TBattleContext> battle, double deltaTime);

    /// <summary>
    /// Initializes this phase manager with the battle.
    /// </summary>
    /// <param name="battle">The battle to initialize with.</param>
    void Initialize(Battle<TBattleContext> battle);
}

/// <summary>
/// An interface for phase managers in battles.
/// </summary>
/// <typeparam name="TBattleContext"></typeparam>
public interface IPhaseManager<TBattleContext, TPhase> : IPhaseManager<TBattleContext>
    where TPhase : IBattlePhase<TBattleContext, TPhase>
{
    /// <summary>
    /// Retrieves the battle's current phase.
    /// </summary>
    TPhase CurrentPhase { get; }
}

#if UNITY_6000
}
#endif // UNITY