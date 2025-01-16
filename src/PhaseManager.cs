namespace Spearhead;

/// <summary>
/// Manages the phases of a battle.
/// </summary>
public class PhaseManager<TBattleContext>
{
    int _currentPhaseIndex = 0;

    readonly IList<IBattlePhase<TBattleContext>> _phaseList;
    private IBattlePhase<TBattleContext> _currentPhase;
    private readonly IBattlePhase<TBattleContext> _endPhase;
    public IBattlePhase<TBattleContext> CurrentPhase => _currentPhase;

    public bool IsBattleOver => _currentPhase == _endPhase;

    /// <summary>
    /// Creates a phase manager.
    /// </summary>
    /// <param name="phaseList"></param>
    /// <param name="startPhase"></param>
    /// <param name="endPhase"></param>
    public PhaseManager(IList<IBattlePhase<TBattleContext>> phaseList, IBattlePhase<TBattleContext> startPhase, IBattlePhase<TBattleContext> endPhase)
    {
        _phaseList = phaseList;
        _currentPhase = startPhase;
        _endPhase = endPhase;
    }

    public void AdvancePhase()
    {
        if (++_currentPhaseIndex >= _phaseList.Count)
        {
            _currentPhaseIndex = 0;
        }
        _currentPhase = _phaseList[_currentPhaseIndex];
        // TODO: Raise an event that the phase has changed
    }

    public void Update(Battle<TBattleContext> battle, double deltaTime)
    {
        CurrentPhase.Update(this, deltaTime);
    }

    /// <summary>
    /// Propels the battle to the end phase.
    /// </summary>
    public void EndBattle()
    {
        _currentPhase = _endPhase;
    }
}
