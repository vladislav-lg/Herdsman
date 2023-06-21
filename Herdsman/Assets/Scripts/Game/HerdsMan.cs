using Core;
using Core.Services;
using UnityEngine;


namespace Game
{
  public class HerdsMan : MonoBehaviour
  {
    [SerializeField] private MovementController _movementController  = null;
    
    public void Move(Vector3 position)
    {
      _movementController.MoveToPosition(transform, position);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
      int layer = LayerMask.NameToLayer(CatchController.ANIMAL_LAYER);
      
      if (collider.gameObject.layer != layer)
        return;
      
      ServiceLocator.Instance.Get<CatchController>().Catch(this, collider.gameObject);
    }
  }
}