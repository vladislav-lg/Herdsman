using Herdsman.UI;
using UnityEngine;


namespace Core.Services
{
  public class UIMainController : MonoBehaviour, IService, IInitiable
  {
    [SerializeField] private UITopPanel _topPanel = null;

    
    public void Init()
    {
      _topPanel.gameObject.SetActive(true);
    }
    
    public void DeInit()
    {
      if ( _topPanel != null )
        _topPanel.gameObject.SetActive( false );
    }
  }
}

