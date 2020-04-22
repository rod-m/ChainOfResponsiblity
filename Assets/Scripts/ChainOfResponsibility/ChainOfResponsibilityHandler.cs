using UnityEngine;
namespace ChainOfResponsibility
{
    public abstract class ChainOfResponsibilityHandler : MonoBehaviour, IHandler
    {
        private IHandler _nextHandler = null;
        public IHandler SetNext(IHandler handler)
        {
            if(handler != this)
                _nextHandler = handler;
            // Returning a handler from here will let us link handlers in a
            // convenient way like this:
            // doorLock.SetNext(newKey.doorKey);
            return handler;
        }
        
        public virtual object Handle(object request)
        {
            /*
              if (_nextHandler != null)
            {
                return _nextHandler.Handle(request);
            }

            return null;
             */
            // short version of above if else
            // the ? means it returns null if is null or calls Handle
            return _nextHandler?.Handle(request);
        }
    }
}