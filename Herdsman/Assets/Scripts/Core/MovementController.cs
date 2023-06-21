using System.Collections;
using ScriptableObjects.Settings;
using UnityEngine;


namespace Core.Services
{
  public class MovementController : MonoBehaviour
  {
    [SerializeField] private MovementSettings _movementSettings = null;
    [SerializeField] private Rigidbody2D      _rigidbody2D      = null;
    
    private Coroutine _coroutine = null;
    
    
    public void MoveToPosition(Transform transform, Vector3 toPosition)
    {
      if (_coroutine != null) 
        StopCoroutine(_coroutine);
      
      _coroutine = StartCoroutine(MoveToPos(transform, toPosition));
    }
    
    public void FollowMove(Transform transform, Transform target)
    { 
      if (_coroutine != null) 
        StopCoroutine(_coroutine);
      
      _coroutine = StartCoroutine(MoveToTarget(transform, target, true));
    }
    
    private IEnumerator MoveToPos(Transform transform, Vector3 position)
    { 
      float time = 0f;
   
      while (Vector3.Distance(transform.position, position) > _movementSettings.Distance)
      {
        Looking(transform, position);
        
        Moving(transform, position, ref time);
   
        yield return null;
      }
    }
       
    private IEnumerator MoveToTarget(Transform transform, Transform target, bool infinityMove)
    {
      float time = 0f;
   
      while (infinityMove)
      {
        float currentDistance = Vector3.Distance(transform.position, target.position);

        if (currentDistance > _movementSettings.Distance) 
          Moving(transform, target.position, ref time);

        yield return null;
      }
    }
   
    private void Moving(Transform transform, Vector3 position, ref float time)
    {
      float speedMultiplier = _movementSettings.AnimationCurve.Evaluate(time);
      float step            = _movementSettings.Speed * Time.deltaTime * speedMultiplier;
       
      Vector2 targetPosition = Vector2.MoveTowards(transform.position, position, step);
     
      _rigidbody2D.MovePosition(targetPosition);
     
      time += Time.deltaTime;
    }

    private void Looking(Transform transform, Vector3 targetPos)
    {
      Vector3    direction      = targetPos - transform.position;
      float      angle          = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
      Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

      transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _movementSettings.RotateSpeed * Time.deltaTime);
    }
  }
}