namespace Spearhead;

/// <summary>
/// A default phase manager that runs turn phases in a round-robin order, i.e.
/// A -> B -> C -> A -> B -> C, etc.
/// </summary>
/// <typeparam name="TBattleContext">The context in which a battle takes place</typeparam>
public class RoundRobinPhaseManager<TBattleContext, TPhase> : PhaseManagerBase<TBattleContext, TPhase>
    where TPhase : IBattlePhase
{
    private readonly TPhase _endPhase;
    bool _startingBattle;

    int _currentPhaseIndex = 0;

    readonly IList<TPhase> _phaseList;
    /// <summary>
    /// The phases managed by this phase manager
    /// </summary>
    public IReadOnlyList<TPhase> Phases => _phaseList.AsReadOnly();
    private TPhase _currentPhase;

    public override IBattlePhase CurrentPhase => _currentPhase;

    public override bool IsBattleOver => _currentPhase.Equals(_endPhase);

    public RoundRobinPhaseManager(TPhase startPhase, IList<TPhase> phaseList, TPhase endPhase)
    {
        _phaseList = phaseList;
        _currentPhase = startPhase ?? phaseList[0];
        _endPhase = endPhase;
        _startingBattle = true;
    }

    public override void AdvancePhase()
    {
        if (_startingBattle)
        {
            _startingBattle = false;
        }
        else if (IsBattleOver)
            return;
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
