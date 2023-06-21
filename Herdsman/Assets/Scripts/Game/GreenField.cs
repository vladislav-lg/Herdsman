using Core;
using Core.Services;

using Pool;
using ScriptableObjects.Settings;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Game
{
  public class GreenField : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField] private BoxCollider2D     _collider2d        = null;
    [SerializeField] private Animal            _prefabAnimal      = null;
    [SerializeField] private GeneratorSettings _generatorSettings = null;
    [SerializeField] private float             _fenceOffset       = 0;
    [SerializeField] private IntervalGenerator _generator         = null;
    [SerializeField] private Transform         _container         = null;

    private Pool<Animal> _pool = null;
    
    public void Init()
    {
      GenerateAnimals();
    }

    public void Deinit()
    {
      if ( _generator != null ) 
        _generator.Stop();

      _pool = null;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
      ServiceLocator.Instance.Get<LevelController>().OnClickGreenField(eventData);
    }
    
    private void GenerateAnimals()
    {
       _pool = new Pool<Animal>(_prefabAnimal, _generatorSettings.PreparedObjects, _container);
        
       _generator.StartGenerate(_generatorSettings, () => _pool.activeItemsCount, OnGenerate);
    }
    
    private void OnGenerate()
    {
      Animal animal = _pool.Get();
      
      Bounds bounds = _collider2d.bounds;

      float minX = bounds.min.x + _fenceOffset;
      float minY = bounds.min.y + _fenceOffset;
      float maxX = bounds.max.x - _fenceOffset;
      float maxY = bounds.max.y - _fenceOffset;

      float randomX = Random.Range(minX, maxX);
      float randomY = Random.Range(minY, maxY);
      
      animal.transform.position = new Vector3(randomX, randomY);
    }
  }
}