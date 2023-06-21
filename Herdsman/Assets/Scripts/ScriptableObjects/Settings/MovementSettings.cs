using UnityEngine;


namespace ScriptableObjects.Settings
{
  [CreateAssetMenu(fileName = "MovementSettings", menuName = "ScriptableObjects/MovementSettings", order = 1)]
  public class MovementSettings : ScriptableObject
  {
    [Header("Movement Settings")]
    [SerializeField] private float          _speed          = 0;
    [SerializeField] private float          _distance       = 0;
    [SerializeField] private float          _rotateSpeed    = 0;
    [SerializeField] private AnimationCurve _animationCurve = null;
    
    
    #region MovementSettings
    public float          Speed          => _speed;
    public float          Distance       => _distance;
    public float          RotateSpeed    => _rotateSpeed;
    public AnimationCurve AnimationCurve => _animationCurve;
    #endregion
  }
}