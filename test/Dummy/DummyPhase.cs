using Spearhead;

namespace Spearhead.Tests.Dummy;

public class DummyPhase : IBattlePhase<int, DummyPhase>
{
    public required int PhaseNumber;

    // TODO: Can I get this to accept the phase manager that the developer's creating themselves?
    public void BeginPhase(IPhaseManager<int, DummyPhase> phaseManager, double deltaTime)
    {
    }

    public void EndPhase(IPhaseManager<int, DummyPhase> phaseManager, double deltaTime)
    {
    }

    public void Update(IPhaseManager<int, DummyPhase> phaseManager, double deltaTime)
    {
    }
}
