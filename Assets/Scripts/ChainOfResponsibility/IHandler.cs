
namespace ChainOfResponsibility
{
    public interface IHandler
    {
        // The default chaining behavior can be implemented inside a base handler
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }
}
