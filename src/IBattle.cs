namespace Spearhead;

public interface IBattle
{
    IActionManager ActionManager { get; }

    void RequestPendingAction(IBattleAction action);

    void RequestImmediateAction(IBattleAction action);
}
