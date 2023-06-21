namespace Core.Services
{
  public class Statistics : IService
  {
    private long _currentScore = 0;
    
    
    public long CurrentScore
    {
      get => _currentScore;
      set
      {
        _currentScore = value;
        OnScoreChanged(_currentScore);
      }
    }
    
    private void OnScoreChanged(long totalScore)
    {
       ServiceLocator.Instance.Get<EventBus>().Invoke(new ScoreChangedSignal(totalScore));
    }
  }
}