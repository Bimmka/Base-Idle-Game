using UnityEngine;
using Zenject;

namespace Features.Animal.SpawnAnimalBox.Scripts
{
  public class AnimalBoxView : MonoBehaviour
  {
    private AnimalBox box;

    [Inject]
    public void Construct(AnimalBox box)
    {
      this.box = box;
      box.StartSpawn();
    }
  }
}