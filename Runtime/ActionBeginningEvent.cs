#if !UNITY_6000
namespace Spearhead;
#else
using System;

namespace Spearhead {
#endif // !UNITY

public class ActionBeginningEvent : IBattleEvent
{
    public int ReactionsRemaining => throw new NotImplementedException();

    public bool CanBeginningBeReactedTo => throw new NotImplementedException();

    public bool CanCompletionBeReactedTo => throw new NotImplementedException();

    public ActionStatus Process(double deltaTime)
    {
        throw new NotImplementedException();
    }
}

#if UNITY_6000
}
#endif // UNITY
