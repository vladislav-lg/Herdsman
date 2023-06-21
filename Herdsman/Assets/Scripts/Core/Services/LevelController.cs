using Game;
using UnityEngine;
using UnityEngine.EventSystems;


public class LevelController : MonoBehaviour, IService, IInitiable
{
    [SerializeField] private HerdsMan   _herdsMan   = null;
    [SerializeField] private GreenField _greenField = null;
    [SerializeField] private Yard       _yard       = null;
    [SerializeField] private Camera     _mainCamera = null;

    
    public void Init()
    {
        _greenField.Init();
    }
    
    public void DeInit()
    {
        _greenField.Deinit();
    }

    public void OnClickGreenField(PointerEventData eventData)
    {
        Vector3 clickPosition = _mainCamera.ScreenToWorldPoint(eventData.pressPosition);

        _herdsMan.Move( new Vector2( clickPosition.x, clickPosition.y ) );
    }

    public void OnClickYard()
    {
        _herdsMan.Move( new Vector2( _yard.transform.position.x, _yard.transform.position.y ) );
    }
}
