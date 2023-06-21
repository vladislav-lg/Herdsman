using Core;
using Core.Services;
using UnityEngine;
using UnityEngine.UI;


namespace Herdsman.UI
{
  public class UITopPanel : MonoBehaviour
  {
    [SerializeField] private Text _score = null;
    
    private EventBus EventBus => ServiceLocator.Instance.Get<EventBus>();

    private void OnEnable()
    {
      EventBus?.Subscribe<ScoreChangedSignal>(OnScoreChanged);
    }
    
    public void OnDisable()
    {
      EventBus?.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
    }

    private void OnScoreChanged(ScoreChangedSignal signal)
    {
      _score.text = $"Score: {signal.score}";
    }
  }
}