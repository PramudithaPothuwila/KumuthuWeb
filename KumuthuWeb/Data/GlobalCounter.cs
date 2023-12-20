namespace KumuthuWeb.Data;

public class GlobalCounter
{
    private int _counter = 0;
    public event EventHandler CounterUpdated;


    public GlobalCounter()
    {
    }

    public int Counter
    {
        get { return _counter; }
        set
        {
            _counter = value;
            OnCounterUpdated();
        }
    }

    protected virtual void OnCounterUpdated()
    {
        CounterUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void Increment()
    {
        _counter++;
        OnCounterUpdated();
    }
    
    public void Decrement()
    {
        _counter--;
        OnCounterUpdated();
    }
}