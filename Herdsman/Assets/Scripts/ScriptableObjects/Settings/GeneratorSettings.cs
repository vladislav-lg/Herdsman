using UnityEngine;


namespace ScriptableObjects.Settings
{
  [CreateAssetMenu(fileName = "GeneratorSettings", menuName = "ScriptableObjects/GeneratorSettings", order = 1)]
  public class GeneratorSettings : ScriptableObject
  {
    [Header("Generator Settings")]
    [SerializeField] private float _minTime             = 0;          
    [SerializeField] private float _maxTime             = 0;         
    [SerializeField] private int   _preparedObjects     = 0;
    [SerializeField] private int   _maxObjects          = 0;
    
    
    #region Generator Settings
    public float MinTime         => _minTime;
    public float MaxTime         => _maxTime;
    public int   PreparedObjects => _preparedObjects;
    public int   MaxObjects      => _maxObjects;
    #endregion
  }
}