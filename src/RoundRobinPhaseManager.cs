namespace Spearhead;

/// <summary>
/// A default phase manager that runs turn phases in a round-robin order, i.e.
/// A -> B -> C -> A -> B -> C, etc.
/// </summary>
/// <typeparam name="TBattleContext">The context in which a battle takes place</typeparam>
public class RoundRobinPhaseManager<TBattleContext> : PhaseManagerBase<TBattleContext>
{
    private readonly IBattlePhase<TBattleContext> _endPhase;

    bool _startingBattle;

    int _currentPhaseIndex = 0;

    readonly IList<IBattlePhase<TBattleContext>> _phaseList;
    private IBattlePhase<TBattleContext> _currentPhase;

    public override IBattlePhase<TBattleContext> CurrentPhase => _currentPhase;

    public override bool IsBattleOver => _currentPhase == _endPhase;

    public RoundRobinPhaseManager(IList<IBattlePhase<TBattleContext>> phaseList, IBattlePhase<TBattleContext> startPhase, IBattlePhase<TBattleContext> endPhase)
    {
        _phaseList = phaseList;
        _currentPhase = startPhase;
        _endPhase = endPhase;
        _startingBattle = true;
    }

    public override void AdvancePhase()
    {
        if (_startingBattle)
        {
            _startingBattle = false;
        }
        else if (++_currentPhaseIndex >= _phaseList.Count)
        {
            _currentPhaseIndex = 0;
        }
        _currentPhase = _phaseList[_currentPhaseIndex];
        // TODO: Raise an event that the phase has changed
    }

    public override void EndBattle()
    {
        _currentPhase = _endPhase;
    }
}