using System.Collections.Generic;
using Game;
using UnityEngine;


namespace Core.Services
{
  public class CatchController : IService
  {
    private List<Animal> _caughtAnimals    = new List<Animal>();
    private       int    _caughtCount      = 0;
    private const int    MAX_CATCH_ANIMALS = 5;
    
    public const string  ANIMAL_LAYER       = "Animal";
    
    
    public void Catch(HerdsMan herdsMan, GameObject gameObject)
    {
      Animal animal = gameObject.GetComponent<Animal>();
      
      if (animal == null)
        Debug.LogErrorFormat("Missing type on GameObject '{0}' with layer '{1}'", gameObject.name, gameObject.layer);
      
      if (_caughtAnimals.Contains(animal))
        return;

      if (_caughtCount > MAX_CATCH_ANIMALS - 1)
        return;
      
      _caughtCount++;
      
      animal.Follow(herdsMan.transform);
      
      _caughtAnimals.Add(animal);
      
      ServiceLocator.Instance.Get<AudioController>().Catch();
    }

    public void PutToYardAnimal(GameObject gameObject)
    {
      Animal animal = gameObject.GetComponent<Animal>();

      if (animal != null)
      {
        animal.Release();
        
        _caughtCount--;
        
        _caughtAnimals.Remove(animal);
        
        ServiceLocator.Instance.Get<Statistics>().CurrentScore++;
        ServiceLocator.Instance.Get<AudioController>().PutToYard();
      }
      else
        Debug.LogErrorFormat("Missing type on GameObject '{0}' with layer '{1}'", gameObject.name, gameObject.layer);
    }
  }
}