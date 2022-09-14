using Features.Animal.Factory.Data;
using Features.Services;
using UnityEngine;

namespace Features.Animal.Factory.Scripts
{
  public interface IAnimalFactory : IService
  {
    void Spawn(AnimalType type, Vector3 at, Quaternion rotation, Transform parent);
  }
}