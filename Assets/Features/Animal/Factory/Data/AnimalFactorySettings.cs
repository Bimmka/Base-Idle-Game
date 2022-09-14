using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Animal.Factory.Data
{
  [CreateAssetMenu(fileName = "AnimalFactorySettings", menuName = "Static Data/Animal/Factory/Settings", order = 52)]
  public class AnimalFactorySettings : SerializedScriptableObject
  {
    public Dictionary<AnimalType, GameObject> Animals;
  }
}