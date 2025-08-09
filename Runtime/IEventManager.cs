namespace Spearhead
{
    /// <summary>
    /// Manages all the events of the game.
    /// </summary>
    public interface IEventManager
    {
        void RegisterEvent<T>(IEventDispatcher dispatcher) where T : IBattleEvent;

        /// <summary>
        /// Raises the event, dispatching it to the event manager for processing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RaiseEvent<T>(T battleEvent) where T : IBattleEvent;
    }
}