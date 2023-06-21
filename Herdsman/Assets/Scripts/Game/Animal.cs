using Core;
using Core.Services;
using UnityEngine;


namespace Game
{
  public class Animal : MonoBehaviourPoolable
  {
    [SerializeField] private MovementController _movementController;
    
    
    public void Follow( Transform leader )
    {
      _movementController.FollowMove( transform, leader );
    }
  }
}