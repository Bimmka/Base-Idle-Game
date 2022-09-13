using UnityEngine;

namespace Features.SpawnAnimalBox.Data
{
  [CreateAssetMenu(fileName = "AnimalBoxSettings", menuName = "Static Data/Animal Box/Settings", order = 52)]
  public class AnimalBoxSettings : ScriptableObject
  {
    public float SpawnTime;
    public int SpawnCount;
    public GameObject Prefab;
  }
}