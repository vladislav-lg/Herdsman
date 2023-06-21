namespace Core.Services
{
  public class Signal
  {
    public readonly int    priority;
    public readonly object callback;

    public Signal(object callback, int priority)
    {
      this.callback = callback;
      this.priority = priority;
    }
  }
}