using Features.Animal.Factory.Data;
using UnityEngine;

namespace Features.Animal.SpawnAnimalBox.Data
{
  [CreateAssetMenu(fileName = "AnimalBoxSettings", menuName = "Static Data/Animal/Box/Settings", order = 52)]
  public class AnimalBoxSettings : ScriptableObject
  {
    public float SpawnTime;
    public int SpawnCount;
    public AnimalType Type;
  }
}