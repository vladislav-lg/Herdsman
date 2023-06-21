using System;
using UnityEngine;


namespace Core
{
  public class MonoBehaviourPoolable : MonoBehaviour
  {
    public Action Release { get; set; }
  }
}