namespace Spearhead;

/// <summary>
/// Manages the update logic for a battle.
/// </summary>
/// <typeparam name="TContext">The type that provides context to the battle. This can be whatever you need it to be - a grid, etc.</typeparam>
public abstract class BattleBase<TContext> : IBattle
{
    private readonly TContext _context;
    /// <summary>
    /// The context this battle occurs in.
    /// </summary>
    public TContext Context => _context;

    private readonly IPhaseManager _phaseManager;
    public IPhaseManager PhaseManager => _phaseManager;
    private readonly IActionManager _actionManager;
    public IActionManager ActionManager => _actionManager;

    private readonly IEventManager _eventManager;
    /// <summary>
    /// This batttle's event manager.
    /// </summary>
    public IEventManager EventManager => _eventManager;

    /// <summary>
    /// Creates a new battle using a custom action manager.
    /// </summary>
    /// <param name="context">The context in which this battle takes place.</param>
    /// <param name="actionManager">The action manager responsible for handling your actions.</param>
    /// <param name="phaseManager">The phase manager responsible for handling your phases.</param>
    /// <param name="eventManager">The event manager.</param>
    public BattleBase(TContext context, IActionManager actionManager, IPhaseManager phaseManager, IEventManager eventManager)
    {
        _context = context;
        _actionManager = actionManager;
        _phaseManager = phaseManager;
        _eventManager = eventManager;
        _phaseManager.Initialize(this);
    }

    public virtual void Update(float deltaTime)
    {
        _phaseManager.Update(deltaTime);
    }

    /// <summary>
    /// Creates a new Battle using the default ActionManager class.
    /// </summary>
    /// <param name="context">The context in which this battle is taking place.</param>
    /// <param name="phaseManager">The manager for your battle's phases.</param>
    public BattleBase(TContext context, IPhaseManager phaseManager) : this(context, new ActionManager(), phaseManager, new EventManager()) {}

    public void RequestPendingAction(IBattleAction action)
        => ActionManager.RequestPendingAction(action);

    public void RequestImmediateAction(IBattleAction action)
        => ActionManager.RequestPendingAction(action);
}