using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Core
{
  public class ServiceLocator
  {
    private Dictionary<string, IService> _services = new Dictionary<string, IService>();

    private static ServiceLocator _instance = null;
    
    
    private ServiceLocator() { }

    public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());

    public T Get<T>() where T : IService
    {
      string key = typeof(T).Name;
      
      if (_services.TryGetValue(key, out IService service))
      {
        return (T)service;
      }
      
      Debug.LogError($"Service {key} is missing!");
      
      throw new KeyNotFoundException();
    }
    
    public void Register<T>(T service) where T : IService
    {
      string key = typeof(T).Name;

      if (_services.ContainsKey(key))
      {
        //TODO DebugError
        return;
      }
      
      _services.Add(key, service);
    }
    
    public void UnRegister<T>() where T : IService
    {
      string key = typeof(T).Name;

      if (!_services.ContainsKey(key))
      {
        //TODO DebugError
        return;
      }
      
      _services.Remove(key);
    }

    public void UnRegisterAll()
    {
      _services.Clear();
    }
    
    public void InitAll()
    {
      foreach ( IInitiable initiable in _services.Values.OfType<IInitiable>() )
        initiable.Init();
    }

    public void DeInitAll()
    {
      foreach ( IInitiable initiable in _services.Values.OfType<IInitiable>() )
        initiable.DeInit();
    }
  }
}

public interface IService
{
}


public interface IInitiable
{
  void Init();
  void DeInit();
}

