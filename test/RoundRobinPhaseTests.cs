using Spearhead.Tests.Dummy;

namespace Spearhead.Tests;

public class RoundRobinPhaseTests
{
    const int BEGINNING_PHASE = 0;
    const int PHASE_A = 1;
    const int PHASE_B = 2;
    const int ENDING_PHASE = 3;

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestPhaseAdvancement()
    {
        RoundRobinPhaseManager<int, DummyPhase> roundRobinPhaseManager = new
        (
            new DummyPhase() { PhaseNumber = BEGINNING_PHASE },
            [
                new DummyPhase() { PhaseNumber = PHASE_A },
                new DummyPhase() { PhaseNumber = PHASE_B },
            ],
            new DummyPhase() { PhaseNumber = ENDING_PHASE }
        );

        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(BEGINNING_PHASE));
        roundRobinPhaseManager.AdvancePhase();
        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(PHASE_A));
        roundRobinPhaseManager.AdvancePhase();
        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(PHASE_B));
        roundRobinPhaseManager.AdvancePhase();
        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(PHASE_A));
        roundRobinPhaseManager.AdvancePhase();
        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(PHASE_B));
        roundRobinPhaseManager.EndBattle();
        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(ENDING_PHASE));
        roundRobinPhaseManager.AdvancePhase();
        Assert.That(roundRobinPhaseManager.CurrentPhase.PhaseNumber, Is.EqualTo(ENDING_PHASE));
    }
}