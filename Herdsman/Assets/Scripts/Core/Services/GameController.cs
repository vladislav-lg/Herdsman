using Core;
using Core.Services;
using UnityEngine;


public class GameController : MonoBehaviour, IService
{
  [SerializeField] private GameObject       _servicesContainer = null;
  [SerializeField] private LevelController  _levelController   = null;
  [SerializeField] private UIMainController _uiMainController  = null;
  [SerializeField] private AudioController  _audioController   = null;
  
  private ServiceLocator _serviceLocator = null;
  
  
  private void Awake()
  {
    Init();
  }

  private void OnDisable()
  {
    Deinit();
  }

  private void Init()
  {
    _serviceLocator = ServiceLocator.Instance;
    
    _serviceLocator.Register(this);
    
    _serviceLocator.Register(_levelController);
    _serviceLocator.Register(_uiMainController);
    _serviceLocator.Register(_audioController);

    _serviceLocator.Register(new EventBus());
    _serviceLocator.Register(new CatchController());
    _serviceLocator.Register(new Statistics());

    DontDestroyOnLoad(_servicesContainer.gameObject);
    
    _serviceLocator.InitAll();
  }

  private void Deinit()
  {
    _serviceLocator.DeInitAll();
    _serviceLocator.UnRegisterAll();
  }
}
