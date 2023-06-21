using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Core.Services
{
  public class EventBus : IService
  {
    private Dictionary<string, List<Signal>> _signalCallbacks = new Dictionary<string, List<Signal>>();

    public void Subscribe<T>(Action<T> callback, int priority = 0)
    {
      string key = typeof(T).Name;

      if (_signalCallbacks.TryGetValue(key, out List<Signal> callbacks))
      {
        callbacks.Add(new Signal(callback, priority));

        _signalCallbacks[key] = _signalCallbacks[key].OrderByDescending(x => x.priority).ToList();
      }

      _signalCallbacks.Add(key, new List<Signal> {new Signal( callback, priority )});
    }

    public void Unsubscribe<T>(Action<T> callback)
    {
      string key = typeof(T).Name;

      if (_signalCallbacks.TryGetValue(key, out List<Signal> callbacks))
      {
        Signal callbackToDelete = callbacks.FirstOrDefault(x => x.callback.Equals(callback));

        if (callbackToDelete != null)
        {
          _signalCallbacks[key].Remove(callbackToDelete);
        }
      }
      else
      {
        Debug.LogWarningFormat("Trying to unsubscribe for not existing key! {0} ", key);
      }
    }

    public void Invoke<T>(T signal)
    {
      string key = typeof(T).Name;

      if (_signalCallbacks.TryGetValue(key, out List<Signal> callbacks))
      {
        foreach (Signal obj in callbacks)
        {
          Action<T> callback = obj.callback as Action<T>;

          callback?.Invoke( signal );
        }
      }
    }
  }
}