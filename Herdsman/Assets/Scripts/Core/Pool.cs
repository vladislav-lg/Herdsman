using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;


namespace Pool
{
  public class Pool<T> where T : MonoBehaviourPoolable
  {
    private T         _prefab    = null;
    private List<T>   _objects   = null;
    private Transform _container = null;

    public int activeItemsCount = 0;

    
    public Pool(T prefab, int preparedItems, Transform container)
    {
      _prefab = prefab;
      _container = container;
      _objects = new List<T>(preparedItems);
      
      for (int i = 0; i < preparedItems; i++)
      {
        T obj = Create();
        
        obj.gameObject.SetActive(false);
        
        _objects.Add(obj);
      }
    }

    public T Get()
    {
      T obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

      if (obj == null)
        obj = Create();

      obj.gameObject.SetActive(true);
      
      activeItemsCount++;

      return obj;
    }

    private T Create()
    {
      T obj = Object.Instantiate(_prefab, _container);
      
      _objects.Add(obj);

      obj.Release = ()=> Realise(obj);

      return obj;
    }

    public void Realise(T obj)
    {
      obj.gameObject.SetActive(false);
      activeItemsCount--;
    }
  }
}