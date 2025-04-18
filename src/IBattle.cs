namespace Spearhead;

public interface IBattle
{
    IActionManager ActionManager { get; }
}

public interface IBattle<TBattleAction> : IBattle where TBattleAction : IBattleAction
{
    void RequestPendingAction(TBattleAction action);

    void RequestImmediateAction(TBattleAction action);
}
