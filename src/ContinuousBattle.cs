namespace Spearhead;

public class ContinuousBattle<TContext> : BattleBase<TContext, IContinuousAction>
{
    public new ContinuousActionManager ActionManager => (ContinuousActionManager)base.ActionManager;

    public ContinuousBattle(TContext context, IPhaseManager phaseManager, IEventManager eventManager)
        : base(context, new ContinuousActionManager(), phaseManager, eventManager)
    {
    }

    public override void Update(float deltaTime)
    {
        if (ActionManager.IsActive)
        {
            ActionManager.Evaluate(deltaTime);
        }
        else
        {
            base.Update(deltaTime);
        }
    }
}
