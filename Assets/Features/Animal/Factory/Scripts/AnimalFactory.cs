using System.Collections.Generic;
using Features.Animal.Factory.Data;
using Features.Services.Assets;
using UnityEngine;
using Zenject;
using Quaternion = UnityEngine.Quaternion;

namespace Features.Animal.Factory.Scripts
{
  public class AnimalFactory : IAnimalFactory
  {
    private readonly IAssetProvider assetProvider;
    private readonly AnimalFactorySettings settings;

    private Dictionary<AnimalType, Queue<GameObject>> animalsPool;

    [Inject]
    public AnimalFactory(IAssetProvider assetProvider, AnimalFactorySettings settings)
    {
      this.assetProvider = assetProvider;
      this.settings = settings;
      
      animalsPool = new Dictionary<AnimalType, Queue<GameObject>>(5);
    }

    public void Spawn(AnimalType type, Vector3 at, Quaternion rotation, Transform parent)
    {
      if (IsContainsInPool(type))
        Respawn(PooledAnimal(type), at, rotation, parent);
      else
        Spawn(NewAnimal(type), at, rotation, parent);
    }

    private void Respawn(GameObject spawnAnimal, Vector3 at, Quaternion rotation, Transform parent)
    {
      spawnAnimal.transform.position = at;
      spawnAnimal.transform.rotation = rotation;
      spawnAnimal.transform.SetParent(parent, true);
    }

    private void Spawn(GameObject spawnAnimal, Vector3 at, Quaternion rotation, Transform parent)
    {
      GameObject spawnedAnimal = assetProvider.Instantiate(spawnAnimal, at, rotation, parent);
    }


    private GameObject PooledAnimal(AnimalType type) => 
      animalsPool[type].Dequeue();

    private GameObject NewAnimal(AnimalType type) => 
      settings.Animals[type];

    private bool IsContainsInPool(AnimalType type) => 
      animalsPool.ContainsKey(type) && animalsPool[type] != null && animalsPool[type].Count > 0;
  }
}