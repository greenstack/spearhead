using Spearhead;

namespace Spearhead.Tests.Dummy;

public class DummyPhase : IBattlePhase<int, DummyPhase, RoundRobinPhaseManager<int, DummyPhase>>
{
    public required int PhaseNumber;

    // TODO: Can I get this to accept the phase manager that the developer's creating themselves?
    public void BeginPhase(RoundRobinPhaseManager<int, DummyPhase> phaseManager, double deltaTime)
    {
    }

    public void EndPhase(RoundRobinPhaseManager<int, DummyPhase> phaseManager, double deltaTime)
    {
    }

    public void Update(RoundRobinPhaseManager<int, DummyPhase> phaseManager, double deltaTime)
    {
    }
}
