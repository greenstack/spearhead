using System;
using System.Collections.Generic;

namespace Spearhead {
    public class ActionBeginningEvent : IBattleEvent
    {
        public int ReactionsRemaining => throw new NotImplementedException();

        public bool CanBeginningBeReactedTo => throw new NotImplementedException();

        public bool CanCompletionBeReactedTo => throw new NotImplementedException();

        public IEnumerator<ActionStatus> Process()
        {
            throw new NotImplementedException();
        }
    }
}
