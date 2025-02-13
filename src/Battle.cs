namespace Spearhead;

/// <summary>
/// Manages the update logic for a battle.
/// </summary>
/// <typeparam name="TContext">The type that provides context to the battle. This can be whatever you need it to be - a grid, etc.</typeparam>
public class Battle<TContext>
{
    private readonly TContext _context;
    /// <summary>
    /// The context this battle occurs in.
    /// </summary>
    public TContext Context => _context;

    private readonly IPhaseManager<TContext> _phaseManager;
    public IPhaseManager<TContext> PhaseManager => _phaseManager;
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
    public Battle(TContext context, IActionManager actionManager, IPhaseManager<TContext> phaseManager, IEventManager eventManager)
    {
        _context = context;
        _actionManager = actionManager;
        _phaseManager = phaseManager;
        _eventManager = eventManager;
        _phaseManager.Initialize(this);
    }

    /// <summary>
    /// Creates a new Battle using the default ActionManager class.
    /// </summary>
    /// <param name="context">The context in which this battle is taking place.</param>
    /// <param name="phaseManager">The manager for your battle's phases.</param>
    public Battle(TContext context, IPhaseManager<TContext> phaseManager) : this(context, new ActionManager(), phaseManager, new EventManager()) {}

    /// <summary>
    /// Updates the battlefield.<br/><br/>If the action manager isn't processing an action, then the phase manager will be updated instead.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since last frame.</param>
    public void Update(double deltaTime)
    {
        if (_actionManager.IsActive)
            _actionManager.Update(deltaTime);
        else
            _phaseManager.Update(this, deltaTime);
    }
}