using System;
using System.Collections;
using ScriptableObjects.Settings;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Core.Services
{
  public class IntervalGenerator : MonoBehaviour
  {
    private Coroutine _currentCoroutine = null;
    
    
    public void StartGenerate(GeneratorSettings settings, Func<int> itemsCount, Action callback)
    {
      _currentCoroutine = StartCoroutine(GenerateLoop(settings, itemsCount, callback ));
    }

    public void Stop()
    {
      if ( _currentCoroutine != null )
        StopCoroutine( _currentCoroutine );
    }
    
    private IEnumerator GenerateLoop(GeneratorSettings settings, Func<int> itemsCount, Action callback)
    {
      while (true)
      {
        if (itemsCount() >= settings.MaxObjects)
        {
          yield return null;
          continue;
        }
          
        float delay = Random.Range(settings.MinTime, settings.MaxTime);
        
        yield return new WaitForSecondsRealtime(delay);
        
        callback?.Invoke();
      }
    }
  }
}