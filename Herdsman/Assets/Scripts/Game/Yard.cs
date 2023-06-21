using Core;
using Core.Services;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Game
{
  public class Yard : MonoBehaviour, IPointerClickHandler
  {
    public void OnPointerClick( PointerEventData eventData )
    {
      ServiceLocator.Instance.Get<LevelController>().OnClickYard();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
      int layer = LayerMask.NameToLayer(CatchController.ANIMAL_LAYER);
      
      if (collider.gameObject.layer != layer)
        return;
      
      ServiceLocator.Instance.Get<CatchController>().PutToYardAnimal(collider.gameObject);
    }
  }
}